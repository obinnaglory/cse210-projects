namespace YouTubeVideos
{
    /// <summary>
    /// Represents a comment with the commenter's name and text.
    /// </summary>
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}
