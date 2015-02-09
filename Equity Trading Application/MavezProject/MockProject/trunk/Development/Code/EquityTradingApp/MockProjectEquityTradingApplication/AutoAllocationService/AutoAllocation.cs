using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DataAccessLayer;
//using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.Transactions;

using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.Runtime.Remoting.Messaging;

namespace AutoAllocationService
{
    public delegate void AutoAllocateCompletedHandler(AutoAllocateCompletedEventArgs e);

    public class AutoAllocateCompletedEventArgs
    {
        public Block Result { get; set; }
    }

    public class AutoAllocation
    {
        public event AutoAllocateCompletedHandler AutoAllocateCompleted;

        public void AutoAllocateAsync(Block blockToExecute, decimal currentTradingPrice, int ordersToExecute, int executionsPerOrder)
        {
            AutoAllocateDelegate del = new AutoAllocateDelegate(AutoAllocate);//Associating the method with the delegate
            var aRes = del.BeginInvoke(blockToExecute, currentTradingPrice, ordersToExecute, executionsPerOrder, new AsyncCallback(AutoAllocateCallback), null);
        }

        private void AutoAllocateCallback(IAsyncResult aRes)
        {
            AsyncResult ar = aRes as AsyncResult;
            var d = ar.AsyncDelegate as AutoAllocateDelegate;
            var r = d.EndInvoke(aRes);
            if (AutoAllocateCompleted != null)
                AutoAllocateCompleted(new AutoAllocateCompletedEventArgs() { Result = r });
        }



        public Block AutoAllocate(Block blockToExecute, decimal currentTradingPrice, int ordersToExecute, int executionsPerOrder)
        {
            Object lockObject = new Object();

            lock (this)
            {




                decimal transactionPrice = 0;
                int orderCount = 0;
                List<Order> orderList = blockToExecute.Orders.ToList();
                orderList.RemoveAll(order => order.StatusID == 4 || order.StatusID == 6);    //1 => order with status completed or expired

                //Get the Allocation Method
                //IAllocationMethodDAL allocationDAL = new AllocationMethodDAL();
                //allocationDAL.GetAllocationMethod();

                //Sort the list based on timestamp
                //orderList.OrderBy(order => order.BookTime);

                IOrderAllocationDAL orderAllocationDAL = new OrderAllocationDAL();
                ISecuritiesDAL securityDAL = new SecuritiesDAL();
                IExecutedBlockDAL executedBlockDAL = new ExecutedBlockDAL();
                IOrderDAL orderDAL = new OrderDAL();
                try
                {
                    //using (TransactionScope scope = new TransactionScope())
                    //{

                    foreach (var order in orderList)
                    {
                        int totalAllocatedQty = orderAllocationDAL.GetAllocatedQtySum(order);
                        order.OpenQuantity = order.TotalQuantity - totalAllocatedQty;
                        Security security = securityDAL.GetAvailableSecurityExecutionQuantity(order.SecurityID);
                        int availableExecutionQuantity = security.ExecutionQuantity;

                        if (availableExecutionQuantity >= order.OpenQuantity)
                        {
                            if(order.TransactionPrice != null)
                            transactionPrice += order.TransactionPrice.Value;
                            orderCount++;
                            OrderAllocation allocatedOrder = new OrderAllocation()
                            {
                                ExecutionID = 1,
                                BlockID = order.BlockID.Value,
                                OrderID = order.OrderID,
                                AllocatedQuantity = order.OpenQuantity,
                                TransactionPrice = transactionPrice,
                                Status = 4  //Completed
                            };

                            security.ExecutionQuantity -= order.OpenQuantity;

                            orderAllocationDAL.InsertAllocatedOrder(allocatedOrder);
                            securityDAL.UpdateSecurity(security);
                            blockToExecute.ExecutedQuantity += order.OpenQuantity;
                            blockToExecute.OpenQuantity -= availableExecutionQuantity;
                        }

                        if (availableExecutionQuantity < order.OpenQuantity)
                        {
                            if (order.TransactionPrice != null)
                            transactionPrice += order.TransactionPrice.Value;
                            orderCount++;
                            OrderAllocation allocatedOrder = new OrderAllocation()
                            {
                                ExecutionID = 1,
                                BlockID = order.BlockID.Value,
                                OrderID = order.OrderID,
                                AllocatedQuantity = availableExecutionQuantity,
                                TransactionPrice = transactionPrice,
                                Status = 5        //Partially Executed
                            };
                            orderAllocationDAL.InsertAllocatedOrder(allocatedOrder);
                            securityDAL.UpdateSecurity(security);
                            blockToExecute.ExecutedQuantity += availableExecutionQuantity;
                            blockToExecute.OpenQuantity -= availableExecutionQuantity;
                            break;
                        }
                    }
                    if (blockToExecute.OpenQuantity == 0)
                        blockToExecute.BlockStatus = 4;
                    else
                        blockToExecute.BlockStatus = 5;
                    //scope.Complete();




                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                try
                {
                    //using (TransactionScope scope = new TransactionScope())
                    //{

                        foreach (var order in orderList)
                        {
                            OrderAllocation orderAllocated = orderAllocationDAL.GetAllocatedOrderByID(order);
                            order.AllocatedQuantity = orderAllocationDAL.GetAllocatedQtySum(order);
                            order.OpenQuantity = order.TotalQuantity - order.AllocatedQuantity;
                            if (order.OpenQuantity == 0)
                                order.StatusID = 4;
                            else
                                order.StatusID = 5;
                            order.TransactionPrice = currentTradingPrice;
                            order.TransactionTime = DateTime.Now;

                            orderDAL.UpdateOrder(order);
                        }
                    //    scope.Complete();
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return blockToExecute;
            }

        }
    }
}