using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManager.Helpers;

namespace PortfolioManager.Models
{
  public  class OrderModel
    {
        public int OrderID { get; set; }

        public int StockID { get; set; }
        
        public string Side { get; set; }

        public int StatusID { get; set; }

        public int BlockID { get; set; }

        public string Qualifier { get; set; }

        public EnumOrderType OrderType { get; set; }

        public int OwnedQuantity { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

        public bool IsSelected { get; set; }
  }
}
