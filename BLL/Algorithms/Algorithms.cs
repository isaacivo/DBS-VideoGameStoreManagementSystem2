using System.Collections.Generic;
using VideoGameRentalManagementSystem.Models;

namespace VideoGameRentalManagementSystem.BLL.Algorithms
{
    public static class Algorithms
    {
        // 🔹 Bubble sort by Title
        public static void BubbleSort(List<Game> games)
        {
            for (int i = 0; i < games.Count - 1; i++)
            {
                for (int j = 0; j < games.Count - i - 1; j++)
                {
                    if (string.Compare(games[j].Title, games[j + 1].Title) > 0)
                    {
                        var temp = games[j];
                        games[j] = games[j + 1];
                        games[j + 1] = temp;
                    }
                }
            }
        }

        // 🔹 Binary Search by Title (requires sorted list)
        public static Game? BinarySearch(List<Game> games, string title)
        {
            int low = 0, high = games.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int compare = string.Compare(games[mid].Title, title, true);

                if (compare == 0)
                    return games[mid];
                else if (compare < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return null;
        }

        // 🔹 Top 5 most-checked-out games
        public static List<Game> GetTop5Games(List<Game> games)
        {
            // Selection sort descending by TimesCheckedOut
            for (int i = 0; i < games.Count - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < games.Count; j++)
                {
                    if (games[j].TimesCheckedOut > games[maxIndex].TimesCheckedOut)
                        maxIndex = j;
                }

                // Swap
                var temp = games[i];
                games[i] = games[maxIndex];
                games[maxIndex] = temp;
            }

            // Return top 5 (or fewer if <5 exist)
            return games.GetRange(0, games.Count < 5 ? games.Count : 5);
        }

        // 🔹 Top 5 platforms by total checkouts
        public static List<(string Platform, int TotalCheckouts)> GetTop5Platforms(List<Game> games)
        {
            var platformTotals = new Dictionary<string, int>();

            foreach (var game in games)
            {
                string platform = game.Platform ?? "Unknown";

                if (!platformTotals.ContainsKey(platform))
                    platformTotals[platform] = 0;

                platformTotals[platform] += game.TimesCheckedOut;
            }

            // Convert dictionary → list
            var list = new List<(string Platform, int TotalCheckouts)>();

            foreach (var pair in platformTotals)
                list.Add((pair.Key, pair.Value));

            // Selection sort descending
            for (int i = 0; i < list.Count - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].TotalCheckouts > list[maxIndex].TotalCheckouts)
                        maxIndex = j;
                }

                var temp = list[i];
                list[i] = list[maxIndex];
                list[maxIndex] = temp;
            }

            // Return top 5
            int count = list.Count < 5 ? list.Count : 5;
            return list.GetRange(0, count);
        }
    }
}
