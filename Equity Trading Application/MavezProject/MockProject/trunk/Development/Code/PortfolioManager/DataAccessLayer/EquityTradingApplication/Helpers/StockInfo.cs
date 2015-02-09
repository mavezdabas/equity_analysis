using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquityTradingApplication.Helpers
{
    public class StockInfo
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int MarketPrice { get; set; }
    }
}
