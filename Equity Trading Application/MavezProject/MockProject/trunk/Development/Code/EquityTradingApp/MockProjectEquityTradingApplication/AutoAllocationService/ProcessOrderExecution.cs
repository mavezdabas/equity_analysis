using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;

namespace AutoAllocationService
{
    public delegate Block AutoAllocateDelegate(Block blockToExecute, decimal currentTradingPrice, int ordersToExecute, int executionsPerOrder);

    public class ProcessOrderExecution
    {
        IProcessOrderExecutionDAL executionDALObject;
        IProcessOrderExecutionDAL updateObject;

        List<Block> blocksForExecution;
        public void ReceivedExecutionBlock(List<ParameterToSend> paramObject)
        {

            //blocksForExecution = new List<Block>();
            //foreach (var item in paramObject)
            //{
            //    blocksForExecution.Add(item.BlockToSend);

            //    decimal currentTradePrice = item.currentTradingPrice;
            //    BeginBlockExecutionProcess(blocksForExecution, currentTradePrice);
            //}
        }

        public void c_AddCompleted(AutoAllocateCompletedEventArgs e)
        {
            updateObject = new ProcessOrderExecutionDAL();
            var transactionPrice = (from c in e.Result.Orders
                                    select c.TransactionPrice).Sum();
            var orderCount = e.Result.Orders.Count();
            int blockExecutionQuantity = e.Result.ExecutedQuantity;
            ExecutedBlock blockExecuted = new ExecutedBlock()
            {
                BlockID = e.Result.BlockID,
                ExecutedQuantity = blockExecutionQuantity,
                TransactionPrice = transactionPrice.Value / (decimal)orderCount,
                Status = 4,  //Allocated
                TransactionTime = System.DateTime.Now

            };

            //updateObject.UpdateExecutedBlockInTable(blockExecuted);
            updateObject.InsertExecutedBlockInTable(blockExecuted);
        }

        public void BeginBlockExecutionProcess(List<ParameterToSend> paramObject)
        {
            blocksForExecution = new List<Block>();
            foreach (var item in paramObject)
            {
                blocksForExecution.Add(item.BlockToSend);

                decimal currentTradePrice = item.currentTradingPrice;

            }


            AutoAllocation autoAllocate = new AutoAllocation();
            autoAllocate.AutoAllocateCompleted += new AutoAllocateCompletedHandler(c_AddCompleted);

            foreach (var block in blocksForExecution)
            {
                decimal curTradPrice = paramObject.Where(param => param.BlockToSend.BlockID == block.BlockID).Select(param => param.currentTradingPrice).FirstOrDefault();
                int orderToExecute = paramObject.Where(param => param.BlockToSend.BlockID == block.BlockID).Select(param => param.OrderToExecute).FirstOrDefault();
                int executionsPerOrder = paramObject.Where(param => param.BlockToSend.BlockID == block.BlockID).Select(param => param.executionsPerOrder).FirstOrDefault();

                if (block.LimitPrice == 0 && block.StopPrice == 0 && block.BlockSide.Equals("BUY", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (block.TotalQuantity == block.ExecutedQuantity)
                    {
                        block.OpenQuantity = 0;
                        block.BlockStatus = 4;
                    }

                    else if (block.TotalQuantity > block.ExecutedQuantity)
                    {
                        block.OpenQuantity = block.TotalQuantity - block.ExecutedQuantity;
                        block.BlockStatus = 5;
                    }

                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
            //       #region MyRegion
            //        Block receivedBlock = autoAllocate.AutoAllocate(block, curTradPrice, orderToExecute, executionsPerOrder);
            //        updateObject = new ProcessOrderExecutionDAL();
            //        var transactionPrice = (from c in receivedBlock.Orders
            //                        select c.TransactionPrice).Sum();
            //        var orderCount = receivedBlock.Orders.Count();

            //ExecutedBlock blockExecuted = new ExecutedBlock()
            //{
            //    BlockID = receivedBlock.BlockID,
            //    ExecutedQuantity = receivedBlock.ExecutedQuantity,
            //    TransactionPrice = transactionPrice.Value / (decimal)orderCount,
            //    Status = 4,  //Allocated
            //    TransactionTime = System.DateTime.Now

            //};

            ////updateObject.UpdateExecutedBlockInTable(blockExecuted);
            //updateObject.InsertExecutedBlockInTable(blockExecuted);
            //       #endregion


                }

                else if (block.LimitPrice == 0 && block.StopPrice == 0 && block.BlockSide.Equals("SELL", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (block.TotalQuantity == block.ExecutedQuantity)
                    {
                        block.OpenQuantity = 0;
                        block.BlockStatus = 4;
                    }

                    else if (block.TotalQuantity > block.ExecutedQuantity)
                    {
                        block.OpenQuantity = block.TotalQuantity - block.ExecutedQuantity;
                        block.BlockStatus = 5;
                    }

                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
                }

                else if (block.LimitPrice == curTradPrice && block.StopPrice == 0 && block.BlockSide.Equals("BUY", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (block.TotalQuantity == block.ExecutedQuantity)
                    {
                        block.OpenQuantity = 0;
                        block.BlockStatus = 4;
                    }

                    else if (block.TotalQuantity > block.ExecutedQuantity)
                    {
                        block.OpenQuantity = block.TotalQuantity - block.ExecutedQuantity;
                        block.BlockStatus = 5;
                    }

                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
                }

                else if (block.LimitPrice == curTradPrice && block.StopPrice == 0 && block.BlockSide.Equals("SELL", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (block.TotalQuantity == block.ExecutedQuantity)
                    {
                        block.OpenQuantity = 0;
                        block.BlockStatus = 4;
                    }

                    else if (block.TotalQuantity > block.ExecutedQuantity)
                    {
                        block.OpenQuantity = block.TotalQuantity - block.ExecutedQuantity;
                        block.BlockStatus = 5;
                    }

                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
                }

                else if (block.StopPrice == curTradPrice && block.LimitPrice == 0 && block.BlockSide.Equals("BUY", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (block.TotalQuantity == block.ExecutedQuantity)
                    {
                        block.OpenQuantity = 0;
                        block.BlockStatus = 4;
                    }

                    else if (block.TotalQuantity > block.ExecutedQuantity)
                    {
                        block.OpenQuantity = block.TotalQuantity - block.ExecutedQuantity;
                        block.BlockStatus = 5;
                    }
                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
                }

                else if (block.StopPrice == curTradPrice && block.LimitPrice == 0 && block.BlockSide.Equals("SELL", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (block.TotalQuantity == block.ExecutedQuantity)
                    {
                        block.OpenQuantity = 0;
                        block.BlockStatus = 4;
                    }

                    else if (block.TotalQuantity > block.ExecutedQuantity)
                    {
                        block.OpenQuantity = block.TotalQuantity - block.ExecutedQuantity;
                        block.BlockStatus = 5;
                    }
                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
                }


                executionDALObject = new ProcessOrderExecutionDAL();
                executionDALObject.UpdateInBlockTable(block);
            }
        }
    }
}


//namespace AutoAllocationService
//{
//    public delegate Block AutoAllocateDelegate(Block blockToExecute, decimal currentTradingPrice, int ordersToExecute, int executionsPerOrder);

//    public class ProcessOrderExecution
//    {
//        IProcessOrderExecutionDAL executionDALObject;
//        IProcessOrderExecutionDAL updateObject;

//        List<Block> blocksForExecution;
//        public void ReceivedExecutionBlock(List<ParameterToSend> paramObject)
//        {

//            //blocksForExecution = new List<Block>();
//            //foreach (var item in paramObject)
//            //{
//            //    blocksForExecution.Add(item.BlockToSend);

//            //    decimal currentTradePrice = item.currentTradingPrice;
//            //    BeginBlockExecutionProcess(blocksForExecution, currentTradePrice);
//            //}
//        }

//        public void c_AddCompleted(AutoAllocateCompletedEventArgs e)
//        {
//            updateObject = new ProcessOrderExecutionDAL();
//            var transactionPrice = (from c in e.Result.Orders
//                                    select c.TransactionPrice).Sum();
//            var orderCount = e.Result.Orders.Count();

//            ExecutedBlock blockExecuted = new ExecutedBlock()
//            {
//                BlockID = e.Result.BlockID,
//                ExecutedQuantity = e.Result.ExecutedQuantity,
//                TransactionPrice = transactionPrice.Value / (decimal)orderCount,
//                Status = 4,  //Allocated
//                TransactionTime = System.DateTime.Now

//            };

//            //updateObject.UpdateExecutedBlockInTable(blockExecuted);
//            updateObject.InsertExecutedBlockInTable(blockExecuted);
//        }

//        public void BeginBlockExecutionProcess(List<ParameterToSend> paramObject)
//        {
//            blocksForExecution = new List<Block>();
//            foreach (var item in paramObject)
//            {
//                blocksForExecution.Add(item.BlockToSend);

//                decimal currentTradePrice = item.currentTradingPrice;

//            }


//            AutoAllocation autoAllocate = new AutoAllocation();
//            autoAllocate.AutoAllocateCompleted += new AutoAllocateCompletedHandler(c_AddCompleted);

//            foreach (var block in blocksForExecution)
//            {
//                decimal curTradPrice = paramObject.Where(param => param.BlockToSend.BlockID == block.BlockID).Select(param => param.currentTradingPrice).FirstOrDefault();
//                int orderToExecute = paramObject.Where(param => param.BlockToSend.BlockID == block.BlockID).Select(param => param.OrderToExecute).FirstOrDefault();
//                int executionsPerOrder = paramObject.Where(param => param.BlockToSend.BlockID == block.BlockID).Select(param => param.executionsPerOrder).FirstOrDefault();
//                if (block.LimitPrice == curTradPrice && block.BlockSide == "BUY")
//                {
//                    if (block.TotalQuantity == block.ExecutedQuantity)
//                    {
//                        Block executeObject = new Block()
//                        {
//                            OpenQuantity = 0,
//                            BlockStatus = 4
//                        };
//                    }

//                    else if (block.TotalQuantity > block.ExecutedQuantity)
//                    {
//                        Block partiallyexecuteObject = new Block()
//                        {
//                            OpenQuantity = block.TotalQuantity - block.ExecutedQuantity,
//                            BlockStatus = 5

//                        };
//                    }

//                    autoAllocate.AutoAllocateAsync(block, curTradPrice, orderToExecute, executionsPerOrder);
//                }

//                else
//                {
//                    if (block.StopPrice == curTradPrice && block.BlockSide == "Sell")
//                    {
//                        if (block.TotalQuantity == block.ExecutedQuantity)
//                        {
//                            Block executeObject = new Block()
//                            {
//                                OpenQuantity = 0,
//                                BlockStatus = 4
//                            };
//                        }

//                        else if (block.TotalQuantity > block.ExecutedQuantity)
//                        {
//                            Block partiallyexecuteObject = new Block()
//                            {
//                                OpenQuantity = block.TotalQuantity - block.ExecutedQuantity,
//                                BlockStatus = 5

//                            };
//                        }
//                    }
//                }

//                executionDALObject = new ProcessOrderExecutionDAL();
//                executionDALObject.UpdateInBlockTable(block);
//            }
//        }
//    }
//}
