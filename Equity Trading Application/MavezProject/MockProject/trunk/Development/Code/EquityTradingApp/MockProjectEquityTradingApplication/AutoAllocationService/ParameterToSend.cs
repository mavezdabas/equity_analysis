using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace AutoAllocationService
{
    public class ParameterToSend
    {
        //public Block BlockToSend;
        public Block BlockToSend { get; set; }
        //   public int OrderToExecute;
        public int OrderToExecute { get; set; }
        // int executionsPerOrder;
        public int executionsPerOrder { get; set; }
        // decimal currentTradingPrice;
        public decimal currentTradingPrice { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
