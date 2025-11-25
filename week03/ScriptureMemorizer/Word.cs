using System.Text;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a token (word) in the scripture. Hiding replaces letters/digits with underscores,
    /// preserving punctuation characters attached to the token.
    /// </summary>
    public class Word
    {
        private readonly string _original;
        private bool _hidden;

        public string Original => _original;
        public bool IsHidden => _hidden;

        public Word(string token)
        {
            _original = token ?? string.Empty;
            _hidden = false;
        }

        public void Hide() => _hidden = true;
        public void Unhide() => _hidden = false;

        public string Display()
        {
            if (!_hidden) return _original;

            var sb = new StringBuilder(_original.Length);
            foreach (char c in _original)
            {
                sb.Append(char.IsLetterOrDigit(c) ? '_' : c);
            }
            return sb.ToString();
        }
    }
}
