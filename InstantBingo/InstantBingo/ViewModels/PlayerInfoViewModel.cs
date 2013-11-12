using Caliburn.Micro;
using InstantBingo.Messages;

namespace InstantBingo.ViewModels
{
    public class PlayerInfoViewModel : PropertyChangedBase, IHandle<UpdateCredits>
    {
        private int _credits;
        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                NotifyOfPropertyChange(() => PlayerName);
            }
        }
        public int Credits
        {
            get { return _credits; }
            private set
            {
                _credits = value;
                NotifyOfPropertyChange(() => Credits);
            }
        }        

        public PlayerInfoViewModel(IEventAggregator eventAggregator)
        {
            Credits = 100;
            PlayerName = "Master Chief";

            eventAggregator.Subscribe(this);
        }        

        public void Handle(UpdateCredits message)
        {            
            UpdateCredits(message.Credits);
        }

        public void UpdateCredits(int credits)
        {
            Credits += credits;
        }        
    }
}