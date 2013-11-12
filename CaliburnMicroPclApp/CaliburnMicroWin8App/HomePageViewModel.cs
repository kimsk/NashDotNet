using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaliburnMicroPcl;

namespace CaliburnMicroWin8App
{
    public class HomePageViewModel : HomePagePclViewModel
    {       
        public override void GetApp()
        {
            Message += " from WinRT!";            
        }
    }
}
