using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using EquityTradingApplication.ViewModels;

namespace EquityTradingApplication.Helpers
{
    class ObjectToBoolConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is string)
                {
                    string orderType = value as String;

                    switch (orderType)
                    {
                        case "Market": return 0;
                        case "Stop": return 1;
                        case "Limit": return 2;
                        case "StopLimit": return 3;
                        default: return 0;

                    }
                }

               
            }
            return 0;

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
