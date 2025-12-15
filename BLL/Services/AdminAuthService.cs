using Dapper;
using Microsoft.Data.Sqlite;
using VideoGameRentalManagementSystem.Models;

namespace VideoGameRentalManagementSystem.BLL.Services
{
    public class AdminAuthService
    {
        // Same DB as your GameSqlRepository + DatabaseInitializer
        private readonly string _connectionString = "Data Source=VideoGames.sqlite";

        /// <summary>
        /// Returns true if a matching admin username/password exists in SQLite.
        /// </summary>
        public bool ValidateAdmin(string username, string password)
        {
            using var connection = new SqliteConnection(_connectionString);

            var admin = connection.QuerySingleOrDefault<Admin>(
                "SELECT * FROM Admins WHERE Username = @Username AND Password = @Password;",
                new { Username = username, Password = password });

            return admin != null;
        }
    }
}
