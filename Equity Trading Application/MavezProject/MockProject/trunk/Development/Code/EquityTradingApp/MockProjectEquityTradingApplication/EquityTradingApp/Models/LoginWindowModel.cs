using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquityTradingApp.Models
{
    public class LoginWindowModel
    {
        public int MaxPriceSpread { get; set; }
        public int MaxExecutionNumber { get; set; }
        public byte[] MaxExecutionInterval { get; set; }
        public int FullyExecutedOrderProbability { get; set; }
        public int SecurityID { get; set; }
    }
}
