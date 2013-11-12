using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using BingoEngine;

namespace InstantBingo.Converters
{
    public class CalledBallCallStatusToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var ballCallStatus = value as BallCaller.BallCallStatus;
            if (ballCallStatus != null)
            {                
                if (ballCallStatus.Equals(BallCaller.BallCallStatus.Called))
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
