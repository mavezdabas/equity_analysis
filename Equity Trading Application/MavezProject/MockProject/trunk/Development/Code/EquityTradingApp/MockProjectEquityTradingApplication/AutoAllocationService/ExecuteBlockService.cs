using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.Threading;

namespace AutoAllocationService
{
    public delegate void BackgroundUpdateDelegate();
    public delegate void ExpireOpenBlockThreadExecutionDelegate();
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExecuteBlockService" in both code and config file together.
    public class ExecuteBlockService : IExecuteBlockService
    {
        public ConfirmationMessage ExecuteBlock(List<Block> blockList)
        {

            ConfirmationMessage classObject = new ConfirmationMessage();
            Console.WriteLine("Confirmation Message");
            if (blockList != null)
            {
                foreach (var block in blockList)
                {
                    classObject.Id = block.BlockID;
                    classObject.TimeStamp = DateTime.Now;
                    classObject.Message = "Blocks Successfully Recieved";
                }

            }
            ExecutionOfBlock(blockList);
            return classObject;

        }
        public void Polling()
        {
            SecurityMarketPrice securityMarketPrice = new SecurityMarketPrice();
            securityMarketPrice.BackgroundUpdateAsync();

            ExpireOpenBlock.ExpireOpenBlockThreadExecutionAsync();

            //ThreadStart ts1 = new ThreadStart(RecieveBlocksFromTable);
            //Thread ExpireOpenBlockThread = new Thread(ts1);
            //ExpireOpenBlockThread.IsBackground = true;
            //ExpireOpenBlockThread.Start();
            //ExpireOpenBlockThread.Join();

            TimeSpan EndOfDayExpireThread = DateTime.Now.TimeOfDay;

            while (EndOfDayExpireThread.Hours > 17 && EndOfDayExpireThread.Hours < 9)
            {
                //RecieveBlocksFromTable();
                Thread.SpinWait(60000);
                EndOfDayExpireThread = DateTime.Now.TimeOfDay;
            }
            //ExpireOpenBlockThread.Start();
        }
        //public void RecieveBlocksFromTable()
        //{
        //    IBlockDAL blockDAL = new BlockDAL();
        //    List<Block> blockList = new List<Block>();
        //    blockList = blockDAL.GetAllPartiallyExecutedBlock();
        //    ExecutionOfBlock(blockList);
        //}

        public void ExecutionOfBlock(List<Block> blockListToExecute)
        {

            CalculatingTradePrice CalculatingTradePriceObject = new CalculatingTradePrice();

            List<ParameterToSend> ParameterObject = new List<ParameterToSend>();
            try
            {
                ParameterObject = CalculatingTradePriceObject.BlockExecution(blockListToExecute);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Ocurred:" + e.Message);
            }

            //ProcessOrderExecution processOrderExecutionObject = new ProcessOrderExecution();
            //processOrderExecutionObject.BeginBlockExecutionProcess(ParameterObject);


            #region MyRegion
            foreach (var block in blockListToExecute)
            {
                if (block.Orders.Count != 0)
                {
                    foreach (var order in block.Orders)
                    {
                        ISecuritiesDAL securityDAL = new SecuritiesDAL();
                        Security security = securityDAL.GetAvailableSecurityExecutionQuantity(order.SecurityID);
                        if (order.TransactionPrice == null)
                            order.TransactionPrice = security.MarketPrice;
                        OrderAllocation allocatedOrder = new OrderAllocation()
                                       {
                                           ExecutionID = 4,
                                           BlockID = order.BlockID.Value,
                                           OrderID = order.OrderID,
                                           AllocatedQuantity = order.OpenQuantity,
                                           TransactionPrice = order.TransactionPrice.Value,
                                           Status = 4  //Completed
                                       };
                        IOrderAllocationDAL orderAllocationDAL = new OrderAllocationDAL();
                        orderAllocationDAL.InsertAllocatedOrder(allocatedOrder);
                        order.AllocatedQuantity = order.OpenQuantity;
                        order.OpenQuantity = order.TotalQuantity - order.AllocatedQuantity;
                        order.Status.StatusID = 4;
                        block.ExecutedQuantity += order.AllocatedQuantity;
                        block.OpenQuantity -= order.AllocatedQuantity;
                        security.ExecutionQuantity -= order.AllocatedQuantity;
                        securityDAL.UpdateSecurity(security);
                        IOrderDAL orderDAL = new OrderDAL();
                        orderDAL.UpdateOrder(order);
                    }
                    if (block.OpenQuantity == 0)
                        block.BlockStatus = 4;
                    else
                        block.BlockStatus = 5;
                }
                IProcessOrderExecutionDAL updateObject = new ProcessOrderExecutionDAL();
                decimal transactionPrice = (from c in block.Orders
                                            select c.TransactionPrice.Value).Sum();
                int orderCount = block.Orders.Count();
                int blockExecutionQuantity = block.ExecutedQuantity;
                ExecutedBlock blockExecuted = new ExecutedBlock()
                {
                    BlockID = block.BlockID,
                    ExecutedQuantity = blockExecutionQuantity,
                    TransactionPrice = transactionPrice / (decimal)orderCount,
                    Status = 4,  //Allocated
                    TransactionTime = System.DateTime.Now

                };

                //updateObject.UpdateExecutedBlockInTable(blockExecuted);
                updateObject.InsertExecutedBlockInTable(blockExecuted);
            }
            #endregion
        }
    }
}
