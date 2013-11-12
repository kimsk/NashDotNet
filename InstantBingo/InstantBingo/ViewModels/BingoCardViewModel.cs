using System;
using System.Linq;
using BingoEngine;
using Caliburn.Micro;

namespace InstantBingo.ViewModels
{
    public class BingoCardViewModel : PropertyChangedBase
    {
        private string _patternName;
        private BingoCard.BingoSquare[][] _squares;

        public BingoCard.BingoSquare[][] Squares
        {
            get { return _squares; }
            private set
            {
                _squares = value;
                NotifyOfPropertyChange(() => Squares);
                NotifyOfPropertyChange(() => HasSquares);
            }
        }

        public bool HasSquares
        {
            get { return Squares != null && Squares.Any(); }
        }

        public string PatternName
        {
            get { return _patternName; }
            private set
            {
                _patternName = value;
                NotifyOfPropertyChange(() => PatternName);
                NotifyOfPropertyChange(() => HasPatternName);
            }
        }

        public bool HasPatternName
        {
            get
            {
                return !string.IsNullOrEmpty(PatternName);
            }
        }

        public void GetNewCard()
        {
            PatternName = string.Empty;
            Squares = BingoCard.GetNewCard();            
        }

        public void MarkCardWithBallCalls(BallCaller.BallCall[] ballCalls)
        {
            Squares = PatternMatcher.MarkCardWithBallCalls(Squares, ballCalls);            
        }

        public void MarkCardWithPattern(BingoPatterns.BingoPattern pattern)
        {
            if (pattern == null)
                return;

            PatternName = pattern.Name;
            Squares = PatternMatcher.MarkCardWithPattern(Squares, pattern.Positions);
        }
    }
}