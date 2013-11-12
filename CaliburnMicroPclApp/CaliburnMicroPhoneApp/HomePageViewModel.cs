using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaliburnMicroPcl;

namespace CaliburnMicroPhoneApp
{
    public class HomePageViewModel : HomePagePclViewModel
    {
        public override void GetApp()
        {
            Message += " from Windows Phone!";
        }
    }
}
