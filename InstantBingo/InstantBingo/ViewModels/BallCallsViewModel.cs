using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine;
using Caliburn.Micro;
using InstantBingo.Messages;

namespace InstantBingo.ViewModels
{
    public class BallCallsViewModel : PropertyChangedBase, IHandle<UpdateBallCallNumber>
    {
        private const int DEFAULT_BALLNUMBER = 50;
        private int _ballNumber = DEFAULT_BALLNUMBER;
        private BallCaller.BallCall[] _ballCalls;

        public BallCallsViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public bool HasBallCalls
        {
            get { return BallCalls != null; }
        }

        public BallCaller.BallCall[] BallCalls
        {
            get { return _ballCalls; }
            private set
            {
                _ballCalls = value;
                NotifyOfPropertyChange(() => BallCalls);
                NotifyOfPropertyChange(() => HasBallCalls);
            }
        }

        public void CallBalls()
        {
            BallCalls = BallCaller.CallBalls(_ballNumber);            
        }

        public void MarkBallCallsWithCardInPattern(BingoCard.BingoSquare[][] squaresWithPattern)
        {
            BallCalls = PatternMatcher.MarkBallCallsWithCardInPattern(squaresWithPattern, BallCalls.ToArray());            
        }
        
        public void Handle(UpdateBallCallNumber message)
        {
            _ballNumber = message.BallCallNumber;
        }
    }

}
