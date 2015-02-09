using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using EquityTradingApplication.Helpers;
using EquityTradingApplication.ViewModels;

namespace EquityTradingApplication.Converters
{
    class OrderViewBtnConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is ViewEquityOrderViewModel)
                {

                    var data = (ViewEquityOrderViewModel)value;
                        if (!(data.Status.Equals(EnumStatus.New.ToString()) || data.Status.Equals(EnumStatus.Open.ToString())))
                        return false;
                    else
                        return true;
                }

                
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
