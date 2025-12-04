using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private static readonly char[] _spinnerChars = new char[] { '|', '/', '-', '\\' };

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Public method to start the activity flow
        public void Run()
        {
            Console.Clear();
            ShowStartingMessage();
            int duration = AskForDuration();
            PrepareToBegin();
            DoActivity(duration);
            ShowEndingMessage(duration);
        }

        // Derived classes implement this
        protected abstract void DoActivity(int durationInSeconds);

        private void ShowStartingMessage()
        {
            Console.WriteLine($"=== {_name} ===");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        private int AskForDuration()
        {
            int seconds;
            while (true)
            {
                Console.Write("Enter the duration for this activity in seconds (e.g., 30): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out seconds) && seconds > 0)
                {
                    return seconds;
                }
                Console.WriteLine("Please enter a positive whole number of seconds.");
            }
        }

        private void PrepareToBegin()
        {
            Console.WriteLine();
            Console.Write("Get ready");
            Spinner(3, 400);
            Console.WriteLine();
        }

        private void ShowEndingMessage(int durationInSeconds)
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the activity: {GetType().Name.Replace("Activity", " Activity")}");
            Console.WriteLine($"Duration: {durationInSeconds} seconds");
            Console.Write("Finishing up");
            Spinner(3, 400);
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the main menu...");
            Console.ReadLine();
        }

        // Reusable helpers for derived classes
        protected void Spinner(int cycles, int msPerStep)
        {
            for (int c = 0; c < cycles; c++)
            {
                for (int i = 0; i < _spinnerChars.Length; i++)
                {
                    Console.Write(_spinnerChars[i]);
                    Thread.Sleep(msPerStep);
                    Console.Write("\b \b");
                }
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        protected bool TimeRemaining(DateTime endTime)
        {
            return DateTime.Now < endTime;
        }
    }
}
