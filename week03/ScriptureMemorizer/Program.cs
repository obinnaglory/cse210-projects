using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptureMemorizer
{
    /*
     * Program.cs
     *
     * Changes for this request:
     *  - Built-in list of scriptures (10 public-domain KJV passages).
     *  - Program picks one scripture at random at startup and displays only that scripture.
     *  - Then repeatedly prompts Enter (hide words) or 'quit' (exit).
     *
     * Stretch / creativity:
     *  - Hides only words not already hidden so user sees steady progress.
     *  - Preserves punctuation when hiding (letters -> underscores).
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Built-in scripture library
            var library = new List<(Reference reference, string text)>
            {
                (new Reference("Nahum", 1, 7),
                    "The Lord is good, a strong hold in the day of trouble; and he knoweth them that trust in him."),
                (new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                (new Reference("Philippians", 4, 13),
                    "I can do all things through Christ which strengtheneth me."),
                (new Reference("Psalm", 23, 1),
                    "The Lord is my shepherd; I shall not want."),
                (new Reference("Psalm", 46, 1),
                    "God is our refuge and strength, a very present help in trouble."),
                (new Reference("Isaiah", 41, 10),
                    "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness."),
                (new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                (new Reference("Matthew", 5, 14),
                    "Ye are the light of the world. A city that is set on a hill cannot be hid."),
                (new Reference("Psalm", 119, 105),
                    "Thy word is a lamp unto my feet, and a light unto my path."),
                (new Reference("Romans", 8, 28),
                    "And we know that all things work together for good to them that love God, to them who are the called according to his purpose.")
            };

            // Pick one scripture at random (so program displays just one scripture)
            var rand = new Random();
            var pick = library[rand.Next(library.Count)];
            var scripture = new Scripture(pick.reference, pick.text);

            // Main loop: display scripture, prompt Enter or quit, hide words on Enter
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Display());
                Console.WriteLine();
                Console.WriteLine($"Visible words remaining: {scripture.VisibleWordCount()}");
                Console.WriteLine();

                if (scripture.IsFullyHidden)
                {
                    Console.WriteLine("--- All words are hidden. Press Enter to finish ---");
                    Console.ReadLine();
                    break;
                }

                Console.Write("Press Enter to hide a few words or type 'quit' to exit: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Hide a few words each round (1-3)
                int toHide = rand.Next(1, 4);
                scripture.HideRandomWords(toHide, rand);
            }
        }
    }
}
