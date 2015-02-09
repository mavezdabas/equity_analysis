using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTraderMainWindow.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int SecurityId { get; set; }
        public String Side { get; set; }
        public decimal StopPrice { get; set; }
        public decimal LimitPrice { get; set; }
        public int? BlockId { get; set; }

    }
}
