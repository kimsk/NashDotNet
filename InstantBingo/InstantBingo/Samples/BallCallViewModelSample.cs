using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine;

namespace InstantBingo.Samples
{
    public class BallCallViewModelSample
    {
        public BallCallViewModelSample()
        {
            BallCalls = new BallCaller.BallCall[75];
            for (int i = 0; i < 75; i++)
            {
                var status = BallCaller.BallCallStatus.NotCalled;
                if (i%7 == 0)
                {
                    status = BallCaller.BallCallStatus.InPattern;
                }
                else if(i%3 == 0)
                {
                    status = BallCaller.BallCallStatus.Called;
                }

                BallCalls[i] = new BallCaller.BallCall(i + 1, status);
            }
        }
        public BallCaller.BallCall[] BallCalls { get; set; }
    }

    //public class BallCall
    //{
    //    public int Number { get; set; }
    //    public BallCaller.BallCallStatus BallCallStatus { get; set; }
    //}
}
