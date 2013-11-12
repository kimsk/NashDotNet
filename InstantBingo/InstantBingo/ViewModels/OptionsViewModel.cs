using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InstantBingo.Messages;
using InstantBingo.Result;
using Action = Caliburn.Micro.Action;

namespace InstantBingo.ViewModels
{
    public class OptionsViewModel
    {
        static readonly ILog Log = LogManager.GetLog(typeof(Action));

        private readonly IEventAggregator _eventAggregator;        
        private int _selectedBallNumber;
        private bool _soundEnabled;

        public OptionsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;            

            BallNumbers = new BindableCollection<int> { 40, 50, 60, 75 };
            SelectedBallNumber = 50;
            SoundEnabled = true;
        }

        public IEnumerable<IResult> AddCredits()
        {
            return AddCredits(10);
        }

        public IEnumerable<IResult> AddCredits(int credits)
        {           
            Log.Info("{0} Credits Added.", credits);
            _eventAggregator.PublishOnCurrentThread(new UpdateCredits(credits));            

            yield return new AddCreditsResult();
        }

        public BindableCollection<int> BallNumbers { get; private set; }

        public int SelectedBallNumber
        {
            get { return _selectedBallNumber; }
            set
            {
                _selectedBallNumber = value;
                Log.Info("Ball Number changed to {0}.", _selectedBallNumber);
                _eventAggregator.PublishOnCurrentThread(new UpdateBallCallNumber(_selectedBallNumber));
            }
        }

        public bool SoundEnabled
        {
            get { return _soundEnabled; }
            set
            {
                _soundEnabled = value;
                Log.Info("Sound Enabled set to {0}.", _soundEnabled);
                _eventAggregator.PublishOnCurrentThread(new SoundSetting(_soundEnabled));
            }
        }
    }
}
