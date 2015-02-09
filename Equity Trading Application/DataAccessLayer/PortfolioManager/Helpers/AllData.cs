using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioManager.Helpers
{
  public class AllData
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal? MarketPrice { get; set; }

        public decimal? PreviousClose { get; set; }

        public decimal? Volume { get; set; }

        public decimal? ChangePercent { get; set; }

        public decimal? Change { get; set; }
  }
}
