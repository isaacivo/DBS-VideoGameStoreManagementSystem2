using System.Collections.Generic;
using VideoGameRentalManagementSystem.Models;
using VideoGameRentalManagementSystem.DAL.IRepositories;
using VideoGameRentalManagementSystem.BLL.Algorithms;

// Optional alias to make calls super clear
using Algo = VideoGameRentalManagementSystem.BLL.Algorithms.Algorithms;

namespace VideoGameRentalManagementSystem.BLL.Services
{
    public class VideoGameStoreService
    {
        private readonly IRepository<Game> _gameRepository;

        public VideoGameStoreService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void AddGame(Game game) => _gameRepository.Add(game);

        public void UpdateGame(Game game) => _gameRepository.Update(game);

        public void DeleteGame(int id) => _gameRepository.Delete(id);

        public bool DeleteGameByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            var games = _gameRepository.GetAll();
            Algo.BubbleSort(games);

            var game = Algo.BinarySearch(games, title);
            if (game == null)
                return false;

            _gameRepository.Delete(game.Id);
            return true;
        }

        public List<Game> GetAllGames()
        {
            var games = _gameRepository.GetAll();
            Algo.BubbleSort(games);
            return games;
        }

        public Game? FindGameByTitle(string title)
        {
            var games = _gameRepository.GetAll();
            Algo.BubbleSort(games);
            return Algo.BinarySearch(games, title);
        }

        // 🔹 Check out by title
        public bool CheckOutGameByTitle(string title)
        {
            var games = _gameRepository.GetAll();
            Algo.BubbleSort(games);

            var game = Algo.BinarySearch(games, title);
            if (game == null) return false;
            if (game.CopiesAvailable <= 0) return false;

            game.CopiesAvailable--;
            game.TimesCheckedOut++;
            _gameRepository.Update(game);

            return true;
        }

        // 🔹 Return by title
        public bool ReturnGameByTitle(string title)
        {
            var games = _gameRepository.GetAll();
            Algo.BubbleSort(games);

            var game = Algo.BinarySearch(games, title);
            if (game == null) return false;
            if (game.CopiesAvailable >= game.CopiesTotal) return false;

            game.CopiesAvailable++;
            _gameRepository.Update(game);

            return true;
        }

        // 🔹 Top 5 games
        public List<Game> GetTop5Games()
        {
            var games = _gameRepository.GetAll();
            return Algo.GetTop5Games(games);
        }

        // 🔹 Top 5 platforms
        public List<(string Platform, int TotalCheckouts)> GetTop5Platforms()
        {
            var games = _gameRepository.GetAll();
            return Algo.GetTop5Platforms(games);
        }
    }
}
