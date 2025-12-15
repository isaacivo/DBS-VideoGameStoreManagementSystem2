using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace VideoGameRentalManagementSystem.DAL
{
    public static class DatabaseInitializer
    {
        private const string ConnectionString = "Data Source=VideoGames.sqlite";

        public static void Initialize()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            // 1. Create VideoGames table
            var createVideoGamesSql = @"
                CREATE TABLE IF NOT EXISTS VideoGames (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title           TEXT    NOT NULL,
                    Developer       TEXT    NOT NULL,
                    Platform        TEXT    NOT NULL,
                    ReleaseYear     INTEGER NOT NULL,
                    CopiesTotal     INTEGER NOT NULL,
                    CopiesAvailable INTEGER NOT NULL,
                    TimesCheckedOut INTEGER NOT NULL DEFAULT 0
                );
            ";

            // 2. Create Admins table
            var createAdminsSql = @"
                CREATE TABLE IF NOT EXISTS Admins (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL
                );
            ";

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = createVideoGamesSql;
                cmd.ExecuteNonQuery();

                cmd.CommandText = createAdminsSql;
                cmd.ExecuteNonQuery();
            }

            // 3. Ensure there is at least one admin (optional default admin)
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Admins (Username, Password)
                    SELECT 'admin', 'password'
                    WHERE NOT EXISTS (SELECT 1 FROM Admins WHERE Username = 'admin');
                ";
                cmd.ExecuteNonQuery();
            }

            // 4. Load and execute Script/data.sql
            var baseDir = AppContext.BaseDirectory;
            var scriptPath = Path.GetFullPath(
                Path.Combine(baseDir, "..", "..", "..", "Script", "data.sql"));

            if (!File.Exists(scriptPath))
            {
                Console.WriteLine($"⚠️ Seed script not found at: {scriptPath}");
                return;
            }

            var scriptText = File.ReadAllText(scriptPath);
            var statements = scriptText.Split(';');

            foreach (var raw in statements)
            {
                var sql = raw.Trim();
                if (string.IsNullOrWhiteSpace(sql))
                    continue;

                using var cmd = connection.CreateCommand();
                cmd.CommandText = sql + ";";
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("✅ Database initialized and seed data applied (if needed).");
        }
    }
}
