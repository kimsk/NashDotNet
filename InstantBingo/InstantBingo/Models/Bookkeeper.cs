using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine;
using Caliburn.Micro;
using InstantBingo.Messages;
using InstantBingo.ViewModels;

namespace InstantBingo.Models
{
    public class Bookkeeper : PropertyChangedBase, IHandle<MatchingPattern>
    {
        private IDictionary<string, PatternCountViewModel> _patternsCount;

        public Bookkeeper(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
            PatternsCount = new Dictionary<string, PatternCountViewModel>();
        }

        private IDictionary<string, PatternCountViewModel> PatternsCount
        {
            get { return _patternsCount; }
            set
            {
                _patternsCount = value;
                NotifyOfPropertyChange(() => PatternCountList);
            }
        }


        public void Handle(MatchingPattern matchingPattern)
        {
            if (!matchingPattern.ValidMatchingPattern())
            {
                return;
            }

            var name = matchingPattern.Name;
            var pattern = matchingPattern.Pattern;
            
            if (PatternsCount.ContainsKey(name))
            {
                PatternsCount[name].Count++;
            }
            else
            {
                PatternsCount[name] = new PatternCountViewModel(pattern.Name, BingoPatterns.PatternsToBools(pattern.Positions)) { Count = 1};
            }
            NotifyOfPropertyChange(() => PatternCountList);
        }

        public IEnumerable<PatternCountViewModel> PatternCountList
        {
            get
            {
                return PatternsCount.Values;
            }
        }
    }
}
