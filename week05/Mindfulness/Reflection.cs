using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _rng = new Random();

        public ReflectionActivity() : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        { }

        protected override void DoActivity(int durationInSeconds)
        {
            string prompt = _prompts[_rng.Next(_prompts.Count)];
            Console.WriteLine();
            Console.WriteLine("Reflect on the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.Write("When you are ready to begin reflecting, ");
            Console.Write("you will be shown questions. Starting in ");
            Countdown(5);
            Console.WriteLine();
            Console.WriteLine();

            DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

            while (TimeRemaining(endTime))
            {
                string question = _questions[_rng.Next(_questions.Count)];
                Console.WriteLine("Consider:");
                Console.WriteLine(question);

                int spinnerCycles = 3;
                for (int i = 0; i < spinnerCycles && TimeRemaining(endTime); i++)
                {
                    Spinner(1, 600);
                }

                Console.WriteLine();
            }
        }
    }
}
