using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTraderMainWindow.Models
{
    public class Block
    {
        public int? BlockId { get; set; }
        public int SecurityId { get; set; }
        public string Side { get; set; }
        public string Status { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal StopPrice { get; set; }
        public int TotalQuantity { get; set; }
        public int ExecutedQuantity { get; set; }
        public int OpenQuantity { get; set; }
        public int TraderId { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
