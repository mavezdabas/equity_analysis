using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioManager.Helpers
{
  public class ErrorCodeHashMap
    {

     public IDictionary<string, string> errorCodesHashMap;
     public static ErrorCodeHashMap obj;

     private ErrorCodeHashMap()
     {
         errorCodesHashMap = new Dictionary<string, string>();
         errorCodesHashMap.Add("WrongPassword", "The password you entered is wrong..!!");
         errorCodesHashMap.Add("WrongKey", "The key you entered is wrong..!!");
         errorCodesHashMap.Add("Overflow", "Owned Quantity cannot be less than the entered quantity ");

     }
      public static ErrorCodeHashMap getInstance()
      {
          if (obj == null)
              obj = new ErrorCodeHashMap();
          return obj;
      
      }

    }
}
