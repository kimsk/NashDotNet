using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using BingoEngine;

namespace InstantBingo.Converters
{
    class NumberStatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var numberStatus = value as BingoCard.NumberStatus;
            if (numberStatus != null)
            {
                if (numberStatus.Equals(BingoCard.NumberStatus.InPattern))
                {
                    return Visibility.Visible;
                }

                if (numberStatus.Equals(BingoCard.NumberStatus.Called))
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
