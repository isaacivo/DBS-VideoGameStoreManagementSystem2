using System;
using VideoGameRentalManagementSystem.BLL.Services;
using VideoGameRentalManagementSystem.DAL;
using VideoGameRentalManagementSystem.DAL.SqlRepositories;
using VideoGameRentalManagementSystem.Models;

namespace VideoGameRentalManagementSystem.UI
{
    public class Program
    {
        static void Main()
        {
            // Initialize DB + seed games + admin
            DatabaseInitializer.Initialize();

            var repo = new VideoGamesSqlRepository();
            var service = new VideoGameStoreService(repo);
            var authService = new AdminAuthService();

            // 🔐 Admin login
            Console.WriteLine("=== Admin Login Required ===");
            const int maxAttempts = 3;
            var authenticated = false;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("Password: ");
                var password = ReadPassword(); // small helper below

                if (authService.ValidateAdmin(username ?? string.Empty, password))
                {
                    authenticated = true;
                    Console.WriteLine("\n✅ Login successful.\n");
                    break;
                }

                Console.WriteLine("\n❌ Invalid credentials.");
                if (attempt < maxAttempts)
                {
                    Console.WriteLine($"Attempts remaining: {maxAttempts - attempt}\n");
                }
            }

            if (!authenticated)
            {
                Console.WriteLine("Too many failed attempts. Exiting...");
                return;
            }

            Console.WriteLine("Welcome to the Video Games Management System\n");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n******* Choose an option *******");
                Console.WriteLine("1. Add a Game");
                Console.WriteLine("2. View All Games");
                Console.WriteLine("3. Delete a Game");
                Console.WriteLine("4. Search Game by Title");
                Console.WriteLine("5. Check Out a Game");
                Console.WriteLine("6. Return a Game");
                Console.WriteLine("7. View Analytics");
                Console.WriteLine("8. Exit");
                Console.Write("******* Your choice: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // 🔹 Add a new game
                        Console.Write("Title: ");
                        var newTitle = Console.ReadLine();

                        Console.Write("Developer: ");
                        var newDeveloper = Console.ReadLine();

                        Console.Write("Platform (e.g., NES, PS1, PC): ");
                        var newPlatform = Console.ReadLine();

                        Console.Write("Release Year: ");
                        if (!int.TryParse(Console.ReadLine(), out var newYear))
                        {
                            Console.WriteLine("❌ Invalid year.");
                            break;
                        }

                        Console.Write("Total Copies: ");
                        if (!int.TryParse(Console.ReadLine(), out var totalCopies))
                        {
                            Console.WriteLine("❌ Invalid number of copies.");
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(newTitle) ||
                            string.IsNullOrWhiteSpace(newDeveloper) ||
                            string.IsNullOrWhiteSpace(newPlatform))
                        {
                            Console.WriteLine("❌ Title, Developer, and Platform cannot be empty.");
                            break;
                        }

                        var newGame = new Game
                        {
                            Title = newTitle!,
                            Developer = newDeveloper!,
                            Platform = newPlatform!,
                            ReleaseYear = newYear,
                            CopiesTotal = totalCopies,
                            CopiesAvailable = totalCopies, // start with full stock
                            TimesCheckedOut = 0
                        };

                        service.AddGame(newGame);
                        Console.WriteLine("✅ Game added successfully.");
                        break;

                    case "2":
                        var allGames = service.GetAllGames();
                        if (allGames.Count == 0)
                            Console.WriteLine("No games in the store yet.");
                        else
                            allGames.ForEach(Console.WriteLine);
                        break;

                    case "3":
                        Console.Write("Enter Game Title to delete: ");
                        var deleteTitle = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(deleteTitle))
                        {
                            Console.WriteLine("❌ Title cannot be empty.");
                            break;
                        }

                        var deleted = service.DeleteGameByTitle(deleteTitle);
                        Console.WriteLine(deleted
                            ? "🗑️ Game deleted successfully."
                            : "❌ Game not found.");
                        break;

                    case "4":
                        Console.Write("Enter title to search: ");
                        var search = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(search))
                        {
                            Console.WriteLine("❌ Title cannot be empty.");
                            break;
                        }
                        var found = service.FindGameByTitle(search);
                        Console.WriteLine(found != null ? $"✅ Found: {found}" : "❌ Game not found.");
                        break;

                    case "5":
                        Console.Write("Enter Customer ID: ");
                        var customerIdCheckout = Console.ReadLine();

                        Console.Write("Enter Game Title to check out: ");
                        var title = Console.ReadLine();
                        var success = service.CheckOutGameByTitle(title!);
                        Console.WriteLine(success
                            ? $"✅ Game checked out successfully for Customer ID: {customerIdCheckout}."
                            : "❌ Unable to check out game (maybe no copies available or title not found).");
                        break;

                    case "6":
                        Console.Write("Enter Customer ID: ");
                        var customerIdReturn = Console.ReadLine();

                        Console.Write("Enter Game Title to return: ");
                        var returnTitle = Console.ReadLine();
                        var returned = service.ReturnGameByTitle(returnTitle!);
                        Console.WriteLine(returned
                            ? $"✅ Game returned successfully for Customer ID: {customerIdReturn}."
                            : "❌ Unable to return game (title not found or all copies already in store).");
                        break;

                    case "7":
                        var topGames = service.GetTop5Games();
                        var topPlatforms = service.GetTop5Platforms();

                        if (topGames.Count == 0)
                        {
                            Console.WriteLine("📊 No games available for analytics yet.");
                            break;
                        }

                        Console.WriteLine("📊 Analytics:");

                        Console.WriteLine("\nTop 5 Games by Checkouts:");
                        int rank = 1;
                        foreach (var g in topGames)
                        {
                            Console.WriteLine($"{rank}. {g.Title} ({g.Platform}) - {g.TimesCheckedOut} checkouts");
                            rank++;
                        }

                        Console.WriteLine("\nTop 5 Platforms by Total Checkouts:");
                        rank = 1;
                        foreach (var p in topPlatforms)
                        {
                            Console.WriteLine($"{rank}. {p.Platform} - {p.TotalCheckouts} total checkouts");
                            rank++;
                        }
                        break;

                    case "8":
                        running = false;
                        Console.WriteLine("👋 Goodbye!");
                        break;

                    default:
                        Console.WriteLine("❌ Invalid option. Try again.");
                        break;
                }
            }
        }

        // Optional: nicer password input (no echo)
        private static string ReadPassword()
        {
            var pwd = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pwd.Length > 0)
                {
                    pwd = pwd[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    pwd += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);

            return pwd;
        }
    }
}
