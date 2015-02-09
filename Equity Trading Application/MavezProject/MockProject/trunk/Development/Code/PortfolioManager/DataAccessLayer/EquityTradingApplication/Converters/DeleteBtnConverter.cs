using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using EquityTradingApplication.Helpers;

namespace EquityTradingApplication.Converters
{
    public class DeleteBtnConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value!=null)
            {
                if (value is OrderViewModel)
                {
                    
                    var data = (OrderViewModel)value;
                    if (data.IsSelected==true &&(data.StatusName=="NEW" || data.StatusName=="OPEN"))
                        return true;
                    else
                        return false;
                }

                
               
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
