using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace PortfolioManager.Converters
{
   public class PositiveNegativeAllSecurities:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           if (value != null)
           {
               decimal val = (decimal)value;
              
               if (val > 0)
                   return Brushes.LightGreen;
               else
                   return Brushes.Red;
           }
           return Brushes.Red;
       }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
