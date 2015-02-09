using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EquityTradingService
{
    [DataContract]
    public class ClientContract
    {
       [DataMember]
        public int ClientID
        {
            get;
            set;
        }

        [DataMember]
        public string ClientName
        {
            get;
            set;
        }
    }
}
