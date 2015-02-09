using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace EquityTradingApplication.Helpers
{
  public  interface IModelWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        event EventHandler Closed;
        void Close();
        void Show();
        bool? ShowDialog();
      

    }
}
