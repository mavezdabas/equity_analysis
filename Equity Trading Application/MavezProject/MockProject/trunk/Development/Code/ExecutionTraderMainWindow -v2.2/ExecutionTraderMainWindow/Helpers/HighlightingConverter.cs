using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ExecutionTraderMainWindow.Helpers
{
    public class HighlightingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((string)value == ("New"))
                return Brushes.LawnGreen;
            else if ((string)value == ("Sent_For_Execution"))
                return Brushes.Aqua;
            else return Brushes.White;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
