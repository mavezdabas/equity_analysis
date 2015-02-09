using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace EquityTradingApplication.Helpers
{
  public class ExceptionHandler
    {
      public ExceptionHandler(string s)
      {
          HandleException(s);
      }

      public ExceptionHandler(codes code)
      {
          ErrorCodeHashMap hashMap = ErrorCodeHashMap.GetInstance();
          string s = hashMap.hash[code];
          HandleException(s);
      }

      private void HandleException(string e)
      {
          MessageBox.Show(e);
      }


  }

}
