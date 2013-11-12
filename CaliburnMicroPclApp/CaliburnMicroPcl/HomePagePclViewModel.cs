using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace CaliburnMicroPcl
{
    public abstract class HomePagePclViewModel : PropertyChangedBase
    {
        private string _message = "Thank you NashDotNet";

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value; 
                NotifyOfPropertyChange(() => Message);                
            }
        }

        public abstract void GetApp();
    }
}
