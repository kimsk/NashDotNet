using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantBingo.Samples
{
    public class PlayerInfoViewModelSample
    {
        public PlayerInfoViewModelSample()
        {
            Credits = 50;
            PlayerName = "Master Cheif";
        }
        public int Credits { get; set; }
        public string PlayerName { get; set; }
        public int BallNumber { get; set; }
    }
}
