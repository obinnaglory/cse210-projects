namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture reference like "John 3:16" or "Proverbs 3:5-6".
    /// Multiple constructors handle single verse and verse range.
    /// </summary>
    public class Reference
    {
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _startVerse;
        private readonly int _endVerse;

        public string Book => _book;
        public int Chapter => _chapter;
        public int StartVerse => _startVerse;
        public int EndVerse => _endVerse;

        // Single-verse constructor
        public Reference(string book, int chapter, int verse)
        {
            _book = book ?? string.Empty;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
        }

        // Verse-range constructor
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book ?? string.Empty;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse >= startVerse ? endVerse : startVerse;
        }

        public override string ToString()
        {
            if (_startVerse == _endVerse) return $"{_book} {_chapter}:{_startVerse}";
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
