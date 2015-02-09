using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EquityTradingApplication
{
    
    public class SecurityModel
    {
       
        public int SecurityID
        {
            get;
            set;
        }

       
        public string SecurityName
        {
            get;
            set;
        }


       
        public string SecuritySymbol
        {
            get;
            set;
        }


       
        public Nullable<decimal> LastTradedPrice
        {
            get;
            set;
        }

    }
}
