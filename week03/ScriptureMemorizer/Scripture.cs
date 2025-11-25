using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture: a Reference and tokenized Words.
    /// Methods: Display, VisibleWordCount, IsFullyHidden, HideRandomWords.
    /// </summary>
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;

        public Reference Reference => _reference;
        public bool IsFullyHidden => _words.All(w => w.IsHidden);

        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            if (text == null) throw new ArgumentNullException(nameof(text));
            _words = Tokenize(text);
        }

        private List<Word> Tokenize(string text)
        {
            var tokens = Regex.Split(text.Trim(), @"\s+")
                              .Where(t => t.Length > 0)
                              .Select(t => new Word(t))
                              .ToList();
            return tokens;
        }

        public string Display()
        {
            var displayed = string.Join(" ", _words.Select(w => w.Display()));
            return $"{_reference}: {displayed}";
        }

        public int VisibleWordCount() => _words.Count(w => !w.IsHidden);

        /// <summary>
        /// Hide up to 'count' random words chosen only from those not already hidden.
        /// Uses provided Random instance for testability.
        /// </summary>
        public void HideRandomWords(int count, Random rand)
        {
            if (count <= 0) return;
            if (rand == null) rand = new Random();

            var notHidden = _words.Where(w => !w.IsHidden).ToList();
            if (notHidden.Count == 0) return;

            int toHide = Math.Min(count, notHidden.Count);

            // Shuffle indices (Fisher-Yates)
            int n = notHidden.Count;
            var indices = Enumerable.Range(0, n).ToArray();
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int tmp = indices[i];
                indices[i] = indices[j];
                indices[j] = tmp;
            }

            for (int k = 0; k < toHide; k++)
            {
                notHidden[indices[k]].Hide();
            }
        }
    }
}
