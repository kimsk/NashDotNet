using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantBingo.Samples
{
    public class PatternCountViewModelSample
    {
        public PatternCountViewModelSample()
        {
            Name = "Lucky 7";
            Patterns = new bool[][]
            {
                new bool[] {true, true, true, true, true},
                new bool[] {false, false, false, true, false},
                new bool[] {false, false, true, false, false},
                new bool[] {false, true, false, false, false},
                new bool[] {true, false, false, false, false},
            };
            Count = 14;

        }
        public string Name { get; set; }
        public bool[][] Patterns { get; set; }
        public int Count { get; set; }
    }
}
