using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create videos
            var video1 = new Video("Learning C# Basics", "Alice", 600);
            video1.AddComment(new Comment("Bob", "Great explanation!"));
            video1.AddComment(new Comment("Charlie", "Very helpful, thanks."));
            video1.AddComment(new Comment("Dana", "I finally understand classes now."));

            var video2 = new Video("Top 10 YouTube Tricks", "Eve", 420);
            video2.AddComment(new Comment("Frank", "Awesome tips!"));
            video2.AddComment(new Comment("Grace", "This is so useful."));
            video2.AddComment(new Comment("Heidi", "Loved it!"));
            video2.AddComment(new Comment("Ivan", "Can't wait to try these."));

            var video3 = new Video("Meditation for Beginners", "Judy", 900);
            video3.AddComment(new Comment("Kyle", "This really calmed me."));
            video3.AddComment(new Comment("Laura", "Great guide for beginners."));
            video3.AddComment(new Comment("Mia", "Perfect length."));

            // Add videos to a list
            var videos = new List<Video> { video1, video2, video3 };

            // Display each video with its comments
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"\t{comment.Name}: {comment.Text}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
