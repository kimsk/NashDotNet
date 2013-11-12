using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using BingoEngine;

namespace InstantBingo.Converters
{
    public class NumberStatusToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var numberStatus = value as BingoCard.NumberStatus;
            if (numberStatus != null)
            {
                if (numberStatus.Equals(BingoCard.NumberStatus.InPattern))
                {
                    return new SolidColorBrush(Colors.Red);
                }

                if (numberStatus.Equals(BingoCard.NumberStatus.Called))
                {
                    return new SolidColorBrush(Colors.PowderBlue);
                }
            }

            return new SolidColorBrush(Colors.Azure);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
