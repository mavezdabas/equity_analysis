using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EquityTradingService
{
    [DataContract]
    public class SecurityContract
    {
        [DataMember]
        public int SecurityID
        {
            get;
            set;
        }

        [DataMember]
        public string SecurityName
        {
            get;
            set;
        }


        [DataMember]
        public string SecuritySymbol
        {
            get;
            set;
        }


        [DataMember]
        public Nullable<decimal> LastTradedPrice
        {
            get;
            set;
        }

    }
}
