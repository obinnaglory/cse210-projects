using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        // Simple session log for extra-credit: counts how many times each activity run this session
        private static Dictionary<string, int> sessionCounts = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Mindfulness Program ===");
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Session Summary");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunActivity(new BreathingActivity());
                        break;
                    case "2":
                        RunActivity(new ReflectionActivity());
                        break;
                    case "3":
                        RunActivity(new ListingActivity());
                        break;
                    case "4":
                        ShowSessionSummary();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press ENTER to try again.");
                        Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine("Thanks for using the Mindfulness Program. Take care!");
            Thread.Sleep(600);
        }

        static void RunActivity(Activity activity)
        {
            activity.Run();

            string key = activity.GetType().Name;
            if (!sessionCounts.ContainsKey(key)) sessionCounts[key] = 0;
            sessionCounts[key] += 1;
        }

        static void ShowSessionSummary()
        {
            Console.Clear();
            Console.WriteLine("=== Session Summary ===");
            if (sessionCounts.Count == 0)
            {
                Console.WriteLine("No activities run yet this session.");
            }
            else
            {
                foreach (var kvp in sessionCounts)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value} time(s)");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the main menu...");
            Console.ReadLine();
        }
    }
}
