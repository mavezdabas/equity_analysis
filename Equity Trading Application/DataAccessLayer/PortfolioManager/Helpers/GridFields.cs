using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioManager.Helpers
{
    public class GridFields
    {
        public int OrderID { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal? MarketPrice { get; set; }

        public string Status { get; set; }

        public bool IsSelected { get; set; }

    }
}
