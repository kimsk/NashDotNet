using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using BingoEngine;
using InstantBingo.Messages;

namespace InstantBingo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private const int CREDITS_REMOVED_PER_PLAY = -5;

        private readonly IEventAggregator _eventAggregator;        
        private bool _isGameReady = true;
        private int _numberOfPatternsWon;        
        private const int DELAY = 500;

        public MainViewModel(INavigationService navigationService, IEventAggregator eventAggregator
            , BingoCardViewModel bingoCardViewModel, BallCallsViewModel ballCallViewModel, PlayerInfoViewModel playerInfoViewModel, SoundViewModel soundViewModel)
            : base(navigationService)
        {
            _eventAggregator = eventAggregator;
            SoundPlayer = soundViewModel; 
            BingoCard = bingoCardViewModel;
            BallCalls = ballCallViewModel;
            PlayerInfo = playerInfoViewModel;
            
            // listen to Credits change in PlayerInfo
            PlayerInfo.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Credits")
                {
                    NotifyOfPropertyChange(() => CanPlay);
                }
            };
        }

        public int NumberOfPatternWon
        {
            get { return _numberOfPatternsWon; }
            private set
            {
                _numberOfPatternsWon = value;
                NotifyOfPropertyChange(() => NumberOfPatternWon);
            }
        }

        public bool IsGameReady
        {
            get { return _isGameReady; }
            private set
            {
                _isGameReady = value;
                NotifyOfPropertyChange(() => CanPlay);
                NotifyOfPropertyChange(() => IsGameReady);
            }
        }

        public bool CanPlay
        {
            get { return IsGameReady && (PlayerInfo.Credits >= CREDITS_REMOVED_PER_PLAY); }
        }        

        public void NavigateToPatternsView()
        {
            NavigationService.NavigateToViewModel<PatternsViewModel>();
        }

        public async Task PlayBingo()
        {
            BeginPlayBingo();

            await PrepareNewCardAndBallCalls();
            await MarkCardAndBallCallsWithPatterns();

            EndPlayBingo();
        }

        private void BeginPlayBingo()
        {
            IsGameReady = false;
            _eventAggregator.PublishOnCurrentThread(new PlaySound(SoundType.ButtonSound, true));
            PlayerInfo.UpdateCredits(CREDITS_REMOVED_PER_PLAY);
        }

        private async Task PrepareNewCardAndBallCalls()
        {
            // Get new bingo card and ball calls            
            await Task.WhenAll(
                Task.Run(() => BingoCard.GetNewCard()),
                Task.Run(() => BallCalls.CallBalls())
                );
        }

        private async Task MarkCardAndBallCallsWithPatterns()
        {
            await Task.Run(() => BingoCard.MarkCardWithBallCalls(BallCalls.BallCalls.ToArray()));

            // check if card match with any patterns
            await Task.Run(() =>
            {
                var patterns = PatternMatcher.GetMatchingPatterns(BingoCard.Squares, BingoPatterns.Patterns);

                if (patterns.Any())
                {
                    NumberOfPatternWon = patterns.Length;

                    // think ahead a bit in case we change how sound is implemented in the future
                    _eventAggregator.PublishOnCurrentThread(new PlaySound(SoundType.WinningSound, true));

                    foreach (var pattern in patterns)
                    {
                        _eventAggregator.PublishOnBackgroundThread(new MatchingPattern(pattern.Name, pattern));

                        PlayerInfo.UpdateCredits(pattern.Credits);

                        // update bingocard and ballcalls viewmodels
                        BingoCard.MarkCardWithPattern(pattern);
                        BallCalls.MarkBallCallsWithCardInPattern(BingoCard.Squares);

                        // prevent pattern shown too quick
                        new ManualResetEvent(false).WaitOne(DELAY);
                    }

                    _eventAggregator.PublishOnCurrentThread(new PlaySound(SoundType.WinningSound, false));
                }
                else
                {
                    NumberOfPatternWon = 0;
                    // make sure button sound is right
                    new ManualResetEvent(false).WaitOne(DELAY);
                }
            });
        }


        private void EndPlayBingo()
        {
            _eventAggregator.PublishOnCurrentThread(new PlaySound(SoundType.ButtonSound, false));
            IsGameReady = true;
        }        

        public BallCallsViewModel BallCalls { get; private set; }
        public BingoCardViewModel BingoCard { get; private set; }
        public PlayerInfoViewModel PlayerInfo { get; private set; }
        public SoundViewModel SoundPlayer { get; private set; }

        
    }
}
