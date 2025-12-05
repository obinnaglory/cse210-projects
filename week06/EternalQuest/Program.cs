using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GoalManager();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Eternal Quest ===");
                Console.WriteLine($"Score: {manager.Score}");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        CreateGoalMenu(manager);
                        break;
                    case "2":
                        Console.Clear();
                        manager.ShowGoals();
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                        RecordEventMenu(manager);
                        break;
                    case "4":
                        Console.Write("Filename to save to: ");
                        var saveFile = Console.ReadLine();
                        try
                        {
                            manager.SaveToFile(saveFile);
                            Console.WriteLine("Saved.");
                        }
                        catch (Exception ex) { Console.WriteLine($"Error saving: {ex.Message}"); }
                        Console.WriteLine("Press ENTER...");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Filename to load from: ");
                        var loadFile = Console.ReadLine();
                        try
                        {
                            manager.LoadFromFile(loadFile);
                            Console.WriteLine("Loaded.");
                        }
                        catch (Exception ex) { Console.WriteLine($"Error loading: {ex.Message}"); }
                        Console.WriteLine("Press ENTER...");
                        Console.ReadLine();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press ENTER...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CreateGoalMenu(GoalManager manager)
        {
            Console.Clear();
            Console.WriteLine("Create a new goal:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (complete N times for bonus)");
            Console.Write("Choose type: ");
            var t = Console.ReadLine()?.Trim();
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();
            Console.Write("Points awarded per record (integer): ");
            int.TryParse(Console.ReadLine(), out int points);

            switch (t)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(title, desc, points));
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(title, desc, points));
                    break;
                case "3":
                    Console.Write("Target number of times to complete: ");
                    int.TryParse(Console.ReadLine(), out int target);
                    Console.Write("Bonus points when target reached: ");
                    int.TryParse(Console.ReadLine(), out int bonus);
                    manager.AddGoal(new ChecklistGoal(title, desc, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Unknown type; returning to menu.");
                    Console.ReadLine();
                    return;
            }

            Console.WriteLine("Goal created. Press ENTER...");
            Console.ReadLine();
        }

        static void RecordEventMenu(GoalManager manager)
        {
            Console.Clear();
            Console.WriteLine("Record an event for which goal?");
            manager.ShowGoals();
            if (manager.Goals.Count == 0)
            {
                Console.WriteLine("No goals to record. Press ENTER...");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter goal number: ");
            if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > manager.Goals.Count)
            {
                Console.WriteLine("Invalid number. Press ENTER...");
                Console.ReadLine();
                return;
            }

            int gained = manager.RecordEvent(idx - 1);
            Console.WriteLine($"Recorded. You earned {gained} points.");
            Console.WriteLine($"New total: {manager.Score}");
            Console.WriteLine("Press ENTER...");
            Console.ReadLine();
        }
    }
}
