using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine;
using InstantBingo.Models;
using InstantBingo.ViewModels;

namespace InstantBingo.Samples
{
    public class PatternsViewModelSample
    {
        public PatternsViewModelSample()
        {
            PatternCounts = new List<PatternCountViewModel>
            {
                new PatternCountViewModel("Lucky 7", new bool[][]
                {
                    new bool[]{true, true, true, true, true},
                    new bool[]{false, false, false, true, false},
                    new bool[]{false, false, true, false, false},
                    new bool[]{false, true, false, false, false},
                    new bool[]{true, false, false, false, false},                    
                }){Count = 14},
                new PatternCountViewModel("Goal Post", new bool[][]
                {
                    new bool[]{true, false, false, false, true},
                    new bool[]{true, false, false, false, true},
                    new bool[]{true, true, true, true, true},
                    new bool[]{false, false, true, false, false},
                    new bool[]{false, false, true, false, false},                    
                }){Count = 4},
                new PatternCountViewModel("Diamond", new bool[][]
                {
                    new bool[]{false, false, true, false, false},
                    new bool[]{false, true, false, true, false},
                    new bool[]{true, false, false, false, true},
                    new bool[]{false, true, false, true, false},
                    new bool[]{false, false, true, false, false},                    
                }){Count = 10},
            };
        }

        public IList<PatternCountViewModel> PatternCounts { get; private set; }
    }
}
