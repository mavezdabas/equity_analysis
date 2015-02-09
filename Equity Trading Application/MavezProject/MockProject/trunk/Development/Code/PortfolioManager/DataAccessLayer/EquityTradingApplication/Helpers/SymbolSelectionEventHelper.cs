using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquityTradingApplication.Helpers
{
    class SymbolSelectionEventHelper
    {
        public delegate void SymbolSelectionEventHandler(SymbolSelectionEventArgs symbolSelectedEventArgs);
        public class SymbolSelectionEventArgs
        {
            public  string SecuritySymbol { get; set; }
            public SymbolSelectionEventArgs(string symbolName)
            {
                SecuritySymbol = symbolName;
            }
        }
    }
}
