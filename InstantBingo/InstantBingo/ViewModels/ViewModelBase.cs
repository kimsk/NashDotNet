using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace InstantBingo.ViewModels
{
    /// <summary>
    /// PropertyChangeBase with NavigationService baked in for GoBack
    /// (Don't need screen for this app yet)
    /// </summary>
    public abstract class ViewModelBase : PropertyChangedBase
    {
        protected readonly INavigationService NavigationService;

        public bool CanGoBack
        {
            get
            {
                return NavigationService.CanGoBack;
            }
        }

        protected ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        public void GoBack()
        {
            NavigationService.GoBack();
        }        
    }
}