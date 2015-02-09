using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquityTradingApp.Helpers
{
    public interface IModalWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        event EventHandler Closed;
        void Close();
        void Show();
        bool? ShowDialog();
    }
}
