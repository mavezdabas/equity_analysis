using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EquityTradingService
{
    [DataContract]
    public class OrderContract
    {
         [DataMember]
         public int OrderID
        {
            get;
            set;
        }
        [DataMember]
         public int SecurityID
         {
             get;
             set;
         }
        [DataMember]
         public string Side
         {
             get;
             set;
         }
        [DataMember]
         public string OrderType
         {
             get;
             set;
         }
        [DataMember]
         public string OrderQualifier
         {
             get;
             set;
         }
        [DataMember]
         public Nullable<int> TraderID
         {
             get;
             set;
         }

        [DataMember]
         public int ManagerID
         {
             get;
             set;
         }

        [DataMember]
         public int TotalQuantity
         {
             get;
             set;
         }

        [DataMember]
         public int OpenQuantity
         {
             get;
             set;
         }


        [DataMember]
         public int AllocatedQuantity
         {
             get;
             set;
         }

        [DataMember]
         public Nullable<decimal> StopPrice
         {
             get;
             set;
         }


        [DataMember]
         public Nullable<decimal> LimitPrice
         {
             get;
             set;
         }


        [DataMember]
         public string Notes
         {
             get;
             set;
         }


        [DataMember]
         public Nullable<bool> Notify
         {
             get;
             set;
         }


        [DataMember]
         public int ClientID
         {
             get;
             set;
         }


        [DataMember]
         public int PortfolioID
         {
             get;
             set;
         }


        [DataMember]
         public int StatusID
         {
             get;
             set;
         }


        [DataMember]
         public Nullable<int> BlockID
         {
             get;
             set;
         }


        [DataMember]
         public byte[] BookTime
         {
             get;
             set;
         }


        [DataMember]
         public Nullable<decimal> TransactionPrice
         {
             get;
             set;
         }


        [DataMember]
         public Nullable<System.DateTime> TransactionTime
         {
             get;
             set;
         }


        [DataMember]
         public string AccountType
         {
             get;
             set;
         }



            
    }
}
