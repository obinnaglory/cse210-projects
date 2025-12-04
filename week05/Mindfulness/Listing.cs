using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _rng = new Random();

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void DoActivity(int durationInSeconds)
        {
            string prompt = _prompts[_rng.Next(_prompts.Count)];
            Console.WriteLine();
            Console.WriteLine("Listing prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.Write("You will have ");
            Console.Write(durationInSeconds);
            Console.Write(" seconds to list as many items as you can. Begin after ");
            Countdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing items (press ENTER after each).");

            List<string> entries = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

            StringBuilder currentLine = new StringBuilder();
            Console.Write("> ");
            while (TimeRemaining(endTime))
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        string item = currentLine.ToString().Trim();
                        Console.WriteLine();
                        if (!string.IsNullOrEmpty(item))
                        {
                            entries.Add(item);
                        }
                        currentLine.Clear();
                        Console.Write("> ");
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (currentLine.Length > 0)
                        {
                            currentLine.Length--;
                            Console.Write("\b \b");
                        }
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        currentLine.Append(keyInfo.KeyChar);
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else
                {
                    Thread.Sleep(50);
                }
            }

            if (currentLine.Length > 0)
            {
                string finalItem = currentLine.ToString().Trim();
                if (!string.IsNullOrEmpty(finalItem))
                {
                    entries.Add(finalItem);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {entries.Count} items.");
            if (entries.Count > 0)
            {
                Console.WriteLine("Here are the items you entered:");
                for (int i = 0; i < entries.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {entries[i]}");
                }
            }
        }
    }
}
