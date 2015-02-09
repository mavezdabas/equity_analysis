using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trader.Helpers
{
   public class GridDetailsBLock
    {
        public int BlockID { get; set; }

        public string Symbol { get; set; }

        public decimal? LimitPrice { get; set; }

        public bool IsSelected { get; set; }
        
        public decimal? StopPrice { get; set; }
    }
}
