using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EquityTradingApplication.Helpers
{
    public interface IUserControlViewModel
    {
        string SecuritySymbol { get; set; }
        ICommand LookupCommand { get; }
        string SecurityName { get; set; }
        //ICommand SideBuyCommand { get;}
        //ICommand SideSellCommand { get;}
        List<string> ListOrderTypes { get; }
        //ICommand OrderQualifierGTCCommand { get; }
        //ICommand OrderQualifierGTDCommand { get; }
        List<string> ListTraders { get; }
        //ICommand AccountTypeCashCommand { get;}
        //ICommand AccountTypeMarginCommand { get;}
        int OpenQuantity { get; set; }
        Nullable<decimal> StopPrice { get; set; }
        Nullable<decimal> LimitPrice { get; set; }
        string Notes { get; set; }
        Nullable<bool> Notify { get; set; }
        string OrderType { get; set; }
        ICommand SaveCommand { get; }
        ICommand CancelCommand { get; }
        string SelectedTraderName { get; set; }
        string Status { get; }

        int OrderId { get; }
    }
}
