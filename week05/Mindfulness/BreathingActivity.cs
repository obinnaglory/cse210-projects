using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        private readonly int _inhaleSeconds = 4;
        private readonly int _exhaleSeconds = 6;

        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        protected override void DoActivity(int durationInSeconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);
            bool inhaleNext = true;

            Console.WriteLine();
            while (TimeRemaining(endTime))
            {
                if (inhaleNext)
                {
                    Console.Write("Breathe in... ");
                    for (int s = _inhaleSeconds; s >= 1 && TimeRemaining(endTime); s--)
                    {
                        Console.Write(s + " ");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("\b \b");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Breathe out... ");
                    for (int s = _exhaleSeconds; s >= 1 && TimeRemaining(endTime); s--)
                    {
                        Console.Write(s + " ");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("\b \b");
                    }
                    Console.WriteLine();
                }

                inhaleNext = !inhaleNext;

                if (TimeRemaining(endTime))
                {
                    Spinner(1, 250);
                }
            }
        }
    }
}
