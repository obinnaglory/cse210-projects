using System.Collections.Generic;

namespace YouTubeVideos
{
    /// <summary>
    /// Represents a YouTube video with title, author, length, and comments.
    /// </summary>
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        /// <summary>
        /// Adds a comment to this video.
        /// </summary>
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        /// <summary>
        /// Returns the number of comments.
        /// </summary>
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        /// <summary>
        /// Returns the list of comments.
        /// </summary>
        public List<Comment> GetComments()
        {
            return _comments;
        }
    }
}
