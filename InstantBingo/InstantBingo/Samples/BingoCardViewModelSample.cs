using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine;
using Caliburn.Micro;
using InstantBingo.ViewModels;

namespace InstantBingo.Samples
{
    public class BingoCardViewModelSample
    {
        public BingoCardViewModelSample()
        {
            Squares = new BingoCard.BingoSquare[][]
            {
                new BingoCard.BingoSquare[]
                {
                    new BingoCard.BingoSquare(7, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(18, BingoEngine.BingoCard.NumberStatus.Called),
                    new BingoCard.BingoSquare(34, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(58, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(69, BingoEngine.BingoCard.NumberStatus.InPattern),
                },
                new BingoCard.BingoSquare[]
                {
                    new BingoCard.BingoSquare(1, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(29, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(38, BingoEngine.BingoCard.NumberStatus.Called),
                    new BingoCard.BingoSquare(60, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(65, BingoEngine.BingoCard.NumberStatus.InPattern),
                },
                new BingoCard.BingoSquare[]
                {
                    new BingoCard.BingoSquare(4, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(19, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(44, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(48, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(75, BingoEngine.BingoCard.NumberStatus.InPattern),
                },
                new BingoCard.BingoSquare[]
                {
                    new BingoCard.BingoSquare(14, BingoEngine.BingoCard.NumberStatus.Called),
                    new BingoCard.BingoSquare(23, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(31, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(51, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(66, BingoEngine.BingoCard.NumberStatus.NotCalled),
                },
                new BingoCard.BingoSquare[]
                {
                    new BingoCard.BingoSquare(5, BingoEngine.BingoCard.NumberStatus.Called),
                    new BingoCard.BingoSquare(16, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(45, BingoEngine.BingoCard.NumberStatus.InPattern),
                    new BingoCard.BingoSquare(52, BingoEngine.BingoCard.NumberStatus.NotCalled),
                    new BingoCard.BingoSquare(70, BingoEngine.BingoCard.NumberStatus.NotCalled),
                },
            };

            PatternName = "Goal Post";
        }

        public BingoCard.BingoSquare[][] Squares { get; set; }

        public string PatternName { get; set; }

        public bool HasPatternName
        {
            get
            {
                return !string.IsNullOrEmpty(PatternName);
            }
        }
    }
}
