using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using VideoGameRentalManagementSystem.Models;
using VideoGameRentalManagementSystem.DAL.IRepositories;

namespace VideoGameRentalManagementSystem.DAL.SqlRepositories
{
    // Data Access Layer for SQLite database
    public class VideoGamesSqlRepository : IRepository<Game>
    {
        // ✅ Use the same DB file name as DatabaseInitializer
        private readonly string _connectionString = "Data Source=VideoGames.sqlite";

        public void Add(Game game)
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Execute(
                @"INSERT INTO VideoGames 
                  (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
                  VALUES 
                  (@Title, @Developer, @Platform, @ReleaseYear, @CopiesTotal, @CopiesAvailable, @TimesCheckedOut);",
                game);
        }

        public void Delete(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Execute("DELETE FROM VideoGames WHERE Id = @Id;", new { Id = id });
        }

        public List<Game> GetAll()
        {
            using var connection = new SqliteConnection(_connectionString);
            return connection.Query<Game>("SELECT * FROM VideoGames;").ToList();
        }

        public Game? GetById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            return connection.QueryFirstOrDefault<Game>(
                "SELECT * FROM VideoGames WHERE Id = @Id;",
                new { Id = id });
        }

        public void Update(Game game)
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Execute(
                @"UPDATE VideoGames SET 
                      Title           = @Title,
                      Developer       = @Developer,
                      Platform        = @Platform,
                      ReleaseYear     = @ReleaseYear,
                      CopiesTotal     = @CopiesTotal,
                      CopiesAvailable = @CopiesAvailable,
                      TimesCheckedOut = @TimesCheckedOut
                  WHERE Id = @Id;",
                game);
        }
    }
}
