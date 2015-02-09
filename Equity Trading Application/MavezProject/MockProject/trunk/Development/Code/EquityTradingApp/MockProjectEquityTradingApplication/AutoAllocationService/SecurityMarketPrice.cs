using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.Threading;
using System.Timers;
using DataAccessLayer;
using System.Runtime.Remoting.Messaging;

namespace AutoAllocationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SecurityMarketPrice" in both code and config file together.
    public class SecurityMarketPrice : ISecurityMarketPrice
    {
        System.Timers.Timer timer;

        public SecurityMarketPrice()
        {
           
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
                        
            //App.Current.Dispatcher.Invoke((Action)(() =>
            //{
            //    //Call the method of the security and get the list of securities
               

            //}));
            
            Console.WriteLine("TIMER");
            CalculateMarketPrice();

        }

        public void GetMarketPrice()
        {
            SecuritiesDAL securityDAL = new SecuritiesDAL();
            var callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();

            List<Security> listOfSecurities = securityDAL.GetSecuritiesMarketPrice();
            List<SecurityForClient> listToSend = new List<SecurityForClient>();

            foreach (var item in listOfSecurities)
            {
                listToSend.Add(new SecurityForClient()
                {
                    SecurityID = item.SecurityID,
                    SecurityName = item.SecurityName,
                    SecuritySymbol = item.SecuritySymbol,
                    MarketPrice = item.MarketPrice,
                    LastTradedPrice = item.LastTradedPrice
                });

            }
            callback.SendResult(listToSend);
           // callback.SendResult(listOfSecurities);
       }

        [DataContract]
        public class SecurityForClient
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
            [DataMember]
            public Nullable<decimal> MarketPrice
            {
                get;
                set;
            }

        }

        public void BackgroundUpdateAsync()
        {

            //timer = new System.Timers.Timer(10000);
            //timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //timer.Enabled = true;

            //timer.Start();
            BackgroundUpdateDelegate del = new BackgroundUpdateDelegate(BackgroundUpdate);//Associating the method with the delegate
            var aRes = del.BeginInvoke(new AsyncCallback(BackgroundUpdateCallback), null);
        }
        private static readonly Random random = new Random();

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }
        private void BackgroundUpdateCallback(IAsyncResult aRes)
        {
            AsyncResult ar = aRes as AsyncResult;
            var d = ar.AsyncDelegate as BackgroundUpdateDelegate;
            d.EndInvoke(aRes);
            //if (AutoAllocateCompleted != null)
            //    AutoAllocateCompleted(new AutoAllocateCompletedEventArgs() { Result = r });
        }

        
        public void BackgroundUpdate()
        {
            //ThreadStart MP = new ThreadStart(CalculateMarketPrice);
            //Thread updateMarketPriceThread = new Thread(MP);
            //updateMarketPriceThread.Name = "MarketPriceUpdateThread";
            //updateMarketPriceThread.IsBackground = true;

            TimeSpan EndOfDayExpireThread = DateTime.Now.TimeOfDay;

            while (EndOfDayExpireThread.Hours != null)
            {
                EndOfDayExpireThread = DateTime.Now.TimeOfDay;
                //updateMarketPriceThread.Start();
                CalculateMarketPrice();
                Thread.SpinWait(10000);



            }
            //while (true)
            //{
            //    Thread.SpinWait(5000);
            //}
        }

        static void CalculateMarketPrice()
        {
            SecuritiesDAL securityDAL = new SecuritiesDAL();
            Console.WriteLine(  "Working");

            foreach (var security in securityDAL.GetSecuritiesMarketPrice())
            {
                security.MarketPrice = security.LastTradedPrice.Value + (decimal)random.Next(-50, 50); //(decimal)RandomNumberBetween(-50.0, 50.0);
                securityDAL.UpdateSecurity(security);
            }
        }

    }

}
