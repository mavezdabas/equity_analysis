using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DataAccessLayer;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLayer.DAL.ExecutionBrokerDAL;

namespace AutoAllocationService
{
    public static class ExpireOpenBlock
    {
        

        //Main will be replaced by Constructor which will be called by main service ExecuteBlockService
        public static void ExpireOpenBlockThreadExecutionAsync()
        {
            ExpireOpenBlockThreadExecutionDelegate del = new ExpireOpenBlockThreadExecutionDelegate(ExpireOpenBlockThreadExecution);//Associating the method with the delegate
            var aRes = del.BeginInvoke(null, null);
        }
        static void ExpireOpenBlockThreadExecution()
        {
            //Console.ReadLine();
            ThreadStart ts1 = new ThreadStart(GetBlockFromTable);
            Thread ExpireOpenBlockThread = new Thread(ts1);
            ExpireOpenBlockThread.IsBackground = true;
            //ExpireOpenBlockThread.Start();
            //ExpireOpenBlockThread.Join();

            TimeSpan EndOfDayExpireThread = DateTime.Now.TimeOfDay;

            while (EndOfDayExpireThread.Hours < 17)
            {
                EndOfDayExpireThread = DateTime.Now.TimeOfDay;
                Thread.SpinWait(1000);
            }
            ExpireOpenBlockThread.Start();

        }

        static void GetBlockFromTable()
        {
            IExecutedBlockDAL executedBlockDAL = new ExecutedBlockDAL();

            ExecutedBlock blockToExpire = executedBlockDAL.GetBlockFromTable();

            CheckOrderStatus(blockToExpire);

        }

        static void CheckOrderStatus(ExecutedBlock blockToExpire)
        {
            // Status MessageStatus= new Status();
            //int statusCheck= MessageStatus.StatusID;
            using (TransactionScope scope = new TransactionScope())
            {
                if (blockToExpire != null)
                {
                    //EquityTradingDBEntities ctx = new EquityTradingDBEntities();
                    var orderCheck = blockToExpire.OrderAllocations.ToList();
                    foreach (var order in orderCheck)
                    {
                        if (order.Status == 3)
                        {
                            IOrderAllocationDAL orderAllocationDAL = new OrderAllocationDAL();
                            orderAllocationDAL.ExpireOpenOrders(order);
                        }
                    }
                    scope.Complete();
                }


                //var expiredOrders = (from order in ctx.Orders
                //                     where order.StatusID==1 || order.StatusID==2
                //                     select order).ToList();
                //foreach (var status in expiredOrders)
                //{
                //    status.StatusID = 1;
                //}
            }

        }
    }

    }   
//    public static class ExpireOpenBlock
//    {
//         Timer timer;
 
//        //Main will be replaced by Constructor which will be called by main service ExecuteBlockService
//        public static void ExpireOpenBlockThreadExecutionAsync()
//        {
//            ExpireOpenBlockThreadExecutionDelegate del = new ExpireOpenBlockThreadExecutionDelegate(ExpireOpenBlockThreadExecution);//Associating the method with the delegate
//            var aRes = del.BeginInvoke(null, null);
//        }
//        static void ExpireOpenBlockThreadExecution()
//        {
//            //Console.ReadLine();
//            ThreadStart ts1 = new ThreadStart(GetBlockFromTable);
//            Thread ExpireOpenBlockThread = new Thread(ts1);
//            ExpireOpenBlockThread.IsBackground = true;
//            //ExpireOpenBlockThread.Start();
//            //ExpireOpenBlockThread.Join();

//            TimeSpan EndOfDayExpireThread = DateTime.Now.TimeOfDay;

//            while (EndOfDayExpireThread.Hours < 17)
//            {
//                EndOfDayExpireThread = DateTime.Now.TimeOfDay;
//                Thread.SpinWait(1000);
//            }
//            ExpireOpenBlockThread.Start();

//        }

//        static void GetBlockFromTable()
//        {
//            IExecutedBlockDAL executedBlockDAL = new ExecutedBlockDAL();

//            ExecutedBlock blockToExpire = executedBlockDAL.GetBlockFromTable();

//            CheckOrderStatus(blockToExpire);

//        }

//        static void CheckOrderStatus(ExecutedBlock blockToExpire)
//        {
//            // Status MessageStatus= new Status();
//            //int statusCheck= MessageStatus.StatusID;
//            using (TransactionScope scope = new TransactionScope())
//            {
//                if (blockToExpire != null)
//                {
//                    //EquityTradingDBEntities ctx = new EquityTradingDBEntities();
//                    var orderCheck = blockToExpire.OrderAllocations.ToList();
//                    foreach (var order in orderCheck)
//                    {
//                        if (order.Status == 3)
//                        {
//                            IOrderAllocationDAL orderAllocationDAL = new OrderAllocationDAL();
//                            orderAllocationDAL.ExpireOpenOrders(order);
//                        }
//                    }
//                    scope.Complete();
//                }


//                //var expiredOrders = (from order in ctx.Orders
//                //                     where order.StatusID==1 || order.StatusID==2
//                //                     select order).ToList();
//                //foreach (var status in expiredOrders)
//                //{
//                //    status.StatusID = 1;
//                //}
//            }

//        }

//    }   
//}