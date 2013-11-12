using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Caliburn.Micro;
using InstantBingo.Models;

namespace InstantBingo.ViewModels
{
    public class PatternsViewModel : ViewModelBase, ISupportSharing
    {
        private readonly Bookkeeper _bookkeeper;

        public IEnumerable<PatternCountViewModel> PatternCounts
        {
            get
            {
                return _bookkeeper.PatternCountList;
            }
        }

        public PatternsViewModel(INavigationService navigationService, Bookkeeper bookkeeper) : base(navigationService)
        {
            _bookkeeper = bookkeeper;            
        }        

        public void OnShareRequested(DataRequest dataRequest)
        {
            dataRequest.Data.Properties.Title = "Bingo Patterns Won!";
            
            var strBuilder = new StringBuilder();

            foreach (var patternCount in PatternCounts)
            {
                strBuilder.AppendFormat("<strong>{0}</strong>: {1}</br></br>", patternCount.Name, patternCount.Count);
            }

            var html = HtmlFormatHelper.CreateHtmlFormat(strBuilder.ToString());
            dataRequest.Data.SetHtmlFormat(html);            
        }        
    }
}
