using BingoEngine;

namespace InstantBingo.Messages
{
    public class MatchingPattern
    {
        public MatchingPattern(string name, BingoPatterns.BingoPattern pattern)
        {
            Name = name;
            Pattern = pattern;
        }

        public string Name { get; set; }
        public BingoPatterns.BingoPattern Pattern { get; set; }

        public bool ValidMatchingPattern()
        {
            return !string.IsNullOrEmpty(Name) && Pattern != null;
        }
    }
}
