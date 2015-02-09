using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExecutionTraderMainWindow.Model;
using ExecutionTraderDataAccessLayer;
using System.Collections.ObjectModel;


namespace ExecutionTraderMainWindow.Helpers
{
    public class Converter
    {
        internal static BlockModel ConvertBlockToBlockModel(ExecutionTraderDataAccessLayer.Block block)
        {
            BlockModel newBlockModel = new BlockModel()
            {

                BlockId = block.BlockID,
                BlockSide = block.BlockSide,
                BlockStatus = ((BlockStatusEnum)block.BlockStatus).ToString(),
                ExecutedQuantity = block.ExecutedQuantity,
                TotalQuantity = block.TotalQuantity,
                OpenQuantity = block.OpenQuantity,
                LimitPrice = block.LimitPrice,
                StopPrice = block.StopPrice,
                TraderId = block.TraderID,
                SecurityId = block.SecurityID,
                security=Converter.ConvertSecurityToSecurityModel( block.Security),
                Orders = new ObservableCollection<OrderModel>(Converter.ConvertOrderListToOrderModelList(block.Orders.ToList())),
                //ExecutedBlocks=(ObservableCollection<ExecutedBlocksModel>)block.ExecutedBlocks,
                //AllocatedOrders=(ObservableCollection<AllocatedOrdersModel>)block.OrderAllocations,
            };
            return newBlockModel;
        }
        internal static BlockModel ConvertBlockToBlockModelWithoutOrders(ExecutionTraderDataAccessLayer.Block block)
        {
            BlockModel newBlockModel = new BlockModel()
            {

                BlockId = block.BlockID,
                BlockSide = block.BlockSide,
                BlockStatus = ((BlockStatusEnum)block.BlockStatus).ToString(),
                ExecutedQuantity = block.ExecutedQuantity,
                TotalQuantity = block.TotalQuantity,
                OpenQuantity = block.OpenQuantity,
                LimitPrice = block.LimitPrice,
                StopPrice = block.StopPrice,
                TraderId = block.TraderID,
                SecurityId = block.SecurityID,
                security = Converter.ConvertSecurityToSecurityModel( block.Security),
                //Orders = new ObservableCollection<OrderModel>(Converter.ConvertOrderListToOrderModelList(block.Orders.ToList())),
                //ExecutedBlocks=(ObservableCollection<ExecutedBlocksModel>)block.ExecutedBlocks,
                //AllocatedOrders=(ObservableCollection<AllocatedOrdersModel>)block.OrderAllocations,
            };
            return newBlockModel;
        }

        internal static Block ConvertBlockModelToBlock(BlockModel blockModel)
        {
            return new Block
            {
                BlockID = blockModel.BlockId,
                BlockSide = blockModel.BlockSide,
                BlockStatus = (int)(Enum.Parse(typeof(BlockStatusEnum), blockModel.BlockStatus)),
                ExecutedQuantity = blockModel.ExecutedQuantity,
                TotalQuantity = blockModel.TotalQuantity,
                OpenQuantity = blockModel.OpenQuantity,
                LimitPrice = blockModel.LimitPrice,
                StopPrice = blockModel.StopPrice,
                TraderID = blockModel.TraderId,
                SecurityID = blockModel.SecurityId,
                Orders = (ICollection<Order>)blockModel.Orders,
                ExecutedBlocks = (ICollection<ExecutedBlock>)blockModel.ExecutedBlocks,
                OrderAllocations = (ICollection<OrderAllocation>)blockModel.AllocatedOrders,
            };
        }

        internal static OrderModel ConvertOrderToOrderModel(Order order)
        {
            OrderModel orderModel = new OrderModel()
            {
                AccountType = order.AccountType,
                AllocatedQuantity = order.AllocatedQuantity,
                BlockId = order.BlockID,
                BookTime = order.BookTime,
                ClientId = order.ClientID,
                LimitPrice = order.LimitPrice,
                ManagerId = order.ManagerID,
                Notes = order.Notes,
                Notify = order.Notify,
                OpenQuantity = order.OpenQuantity,
                OrderId = order.OrderID,
                OrderQualifier = order.OrderQualifier,
                OrderType = order.OrderType,
                PortfolioId = order.PortfolioID,
                SecurityId = order.SecurityID,
                Side = order.Side,
                StatusId = order.StatusID,
                StopPrice = order.StopPrice,
                TotalQuantity = order.TotalQuantity,
                TraderId = order.TraderID,
                TransactionPrice = order.TransactionPrice,
                TransactionTime = order.TransactionTime,
                //Block=Converter.ConvertBlockToBlockModel(order.Block),
                //Client=Converter.ConvertClientToClientModel(order.Client),
                //Portfolio=Converter.ConvertPortfolioToPortfolioModel(order.Portfolio),
                Manager=Converter.ConvertUserToUserModel(order.User),
                //Trader = Converter.ConvertUserToUserModel(order.User1),
                Security=Converter.ConvertSecurityToSecurityModel(order.Security),
                Status=Converter.ConvertStatusToStatusModel(order.Status)
            };

            return orderModel;


        }
        internal static List<OrderModel> ConvertOrderListToOrderModelList(List<Order> orderList)
        {
            List<OrderModel> orderModelList = new List<OrderModel>();
            foreach (var order in orderList)
            {
                
           orderModelList.Add(new OrderModel()
            {
                AccountType = order.AccountType,
                AllocatedQuantity = order.AllocatedQuantity,
                BlockId = order.BlockID,
                BookTime = order.BookTime,
                ClientId = order.ClientID,
                LimitPrice = order.LimitPrice,
                ManagerId = order.ManagerID,
                Notes = order.Notes,
                Notify = order.Notify,
                OpenQuantity = order.OpenQuantity,
                OrderId = order.OrderID,
                OrderQualifier = order.OrderQualifier,
                OrderType = order.OrderType,
                PortfolioId = order.PortfolioID,
                SecurityId = order.SecurityID,
                Side = order.Side,
                StatusId = order.StatusID,
                StopPrice = order.StopPrice,
                TotalQuantity = order.TotalQuantity,
                TraderId = order.TraderID,
                TransactionPrice = order.TransactionPrice,
                TransactionTime = order.TransactionTime,
                //Block = Converter.ConvertBlockToBlockModel(order.Block),
                //Client = Converter.ConvertClientToClientModel(order.Client),
                //Portfolio = Converter.ConvertPortfolioToPortfolioModel(order.Portfolio),
                Manager = Converter.ConvertUserToUserModel(order.User),
                //Trader = Converter.ConvertUserToUserModel(order.User1),
                Security = Converter.ConvertSecurityToSecurityModel(order.Security),
                Status = Converter.ConvertStatusToStatusModel(order.Status)
            }
            );
               

            }

            return orderModelList;


        }
        internal static List<Order> ConvertOrderModelListToOrderList(List<OrderModel> orderModelList)
        {
            List<Order> orderList = new List<Order>();
            foreach (var orderModel in orderModelList)
            {

                orderList.Add(new Order()
                {
                    AccountType = orderModel.AccountType,
                    AllocatedQuantity = orderModel.AllocatedQuantity,
                    BlockID = orderModel.BlockId,
                    BookTime = orderModel.BookTime,
                    ClientID = orderModel.ClientId,
                    LimitPrice = orderModel.LimitPrice,
                    ManagerID = orderModel.ManagerId,
                    Notes = orderModel.Notes,
                    Notify = orderModel.Notify,
                    OpenQuantity = orderModel.OpenQuantity,
                    OrderID = orderModel.OrderId,
                    OrderQualifier = orderModel.OrderQualifier,
                    OrderType = orderModel.OrderType,
                    PortfolioID = orderModel.PortfolioId,
                    SecurityID = orderModel.SecurityId,
                    Side = orderModel.Side,
                    StatusID = orderModel.StatusId,
                    StopPrice = orderModel.StopPrice,
                    TotalQuantity = orderModel.TotalQuantity,
                    TraderID = orderModel.TraderId,
                    TransactionPrice = orderModel.TransactionPrice,
                    TransactionTime = orderModel.TransactionTime,
                    //Block = Converter.ConvertBlockToBlockModel(order.Block),
                    //Client = Converter.ConvertClientToClientModel(order.Client),
                    //Portfolio = Converter.ConvertPortfolioToPortfolioModel(order.Portfolio),
                    User = Converter.ConvertUserModelToUser(orderModel.Manager),
                    //Trader = Converter.ConvertUserToUserModel(order.User1),
                    Security = Converter.ConvertSecurityModelToSecurity(orderModel.Security),
                    Status = Converter.ConvertStatusModelToStatus(orderModel.Status)
                }
                 );


            }

            return orderList;


        }

        internal static Order ConvertOrderModelToOrder(OrderModel orderModel)
        {
            Order order = new Order()
            {
                AccountType = orderModel.AccountType,
                AllocatedQuantity = orderModel.AllocatedQuantity,
                BlockID = orderModel.BlockId,
                BookTime = orderModel.BookTime,
                ClientID = orderModel.ClientId,
                LimitPrice = orderModel.LimitPrice,
                ManagerID = orderModel.ManagerId,
                Notes = orderModel.Notes,
                Notify = orderModel.Notify,
                OpenQuantity = orderModel.OpenQuantity,
                OrderID = orderModel.OrderId,
                OrderQualifier = orderModel.OrderQualifier,
                OrderType = orderModel.OrderType,
                PortfolioID = orderModel.PortfolioId,
                SecurityID = orderModel.SecurityId,
                Side = orderModel.Side,
                StatusID = orderModel.StatusId,
                StopPrice = orderModel.StopPrice,
                TotalQuantity = orderModel.TotalQuantity,
                TraderID = orderModel.TraderId,
                TransactionPrice = orderModel.TransactionPrice,
                TransactionTime = orderModel.TransactionTime,
                Block = Converter.ConvertBlockModelToBlock(orderModel.Block),
                Client = Converter.ConvertClientModelToClient(orderModel.Client),
                Portfolio = Converter.ConvertPortfolioModelToPortfolio(orderModel.Portfolio),
                User = Converter.ConvertUserModelToUser(orderModel.Manager),
                User1 = Converter.ConvertUserModelToUser(orderModel.Trader),
                Security = Converter.ConvertSecurityModelToSecurity(orderModel.Security),
                Status = Converter.ConvertStatusModelToStatus(orderModel.Status)
            };

            return order;


        }
        internal static ClientModel ConvertClientToClientModel(Client client)
        {
            ClientModel clientModel = new ClientModel
            {
                ClientID=client.ClientID,
                ClientName=client.ClientName

            };
            return clientModel;
        }

        internal static Client ConvertClientModelToClient(ClientModel clientModel)
        {
            Client client = new Client
            {
                ClientID = clientModel.ClientID,
                ClientName = clientModel.ClientName

            };
            return client;
        }

        internal static PortfolioModel ConvertPortfolioToPortfolioModel(Portfolio portfolio)
        {
            PortfolioModel portfolioModel = new PortfolioModel
            {
                PortfolioID = portfolio.PortfolioID,
                PortfolioName = portfolio.PortfolioName,
                ClientID = portfolio.ClientID
            };
            return portfolioModel;
        }

        internal static Portfolio ConvertPortfolioModelToPortfolio(PortfolioModel portfolioModel)
        {
            Portfolio portfolio= new Portfolio
            {
                PortfolioID = portfolioModel.PortfolioID,
                PortfolioName = portfolioModel.PortfolioName,
                ClientID = portfolioModel.ClientID
            };
            return portfolio;
        }

        internal static Status ConvertStatusModelToStatus(StatusModel statusModel)
        {
            Status status = new Status()
            {
                StatusID = statusModel.StatusID,
                StatusName = statusModel.StatusName
            };
            return status;
        }

        internal static StatusModel ConvertStatusToStatusModel(Status status)
        {
            StatusModel statusModel = new StatusModel()
            {
                StatusID = status.StatusID,
                StatusName = status.StatusName
            };
            return statusModel;
        }

        internal static SecurityModel ConvertSecurityToSecurityModel(Security security)
        {
            SecurityModel securityModel = new SecurityModel()
            {
                SecurityID = security.SecurityID,
                SecurityName = security.SecurityName,
                SecuritySymbol = security.SecuritySymbol,
                LastTradedPrice = security.LastTradedPrice
            };
            return securityModel;
        }

        internal static Security ConvertSecurityModelToSecurity(SecurityModel securityModel)
        {
            Security security = new Security()
            {
                SecurityID = securityModel.SecurityID,
                SecurityName = securityModel.SecurityName,
                SecuritySymbol = securityModel.SecuritySymbol,
                LastTradedPrice = securityModel.LastTradedPrice
            };
            return security;
        }

        internal static User ConvertUserModelToUser(UserModel userModel)
        {
            User user = new User()
            {
                UserID = userModel.UserID,
                UserName = userModel.UserName,
                Name = userModel.Name,
                RoleID = userModel.RoleID,
                Password = userModel.Password
            };
            return user;
        }

        internal static UserModel ConvertUserToUserModel(User user)
        {
            UserModel userModel = new UserModel()
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Name = user.Name,
                RoleID = user.RoleID,
                Password = user.Password
            };
            return userModel;
        }

        internal static AllocatedOrdersModel ConvertAllocatedOrdersToAllocatedOrdersModel(OrderAllocation allocatedOrder)
        {
            AllocatedOrdersModel allocatedOrderModel = new AllocatedOrdersModel()
            {
                AllocationId = allocatedOrder.AllocationID,
                ExecutionId = allocatedOrder.ExecutionID,
                BlockId = allocatedOrder.BlockID,
                Status = allocatedOrder.Status,
                AllocatedQuantity = allocatedOrder.AllocatedQuantity,
                TransactionFee = allocatedOrder.TransactionFee,
                TransactionPrice = allocatedOrder.TransactionPrice,
                Order=Converter.ConvertOrderToOrderModel(allocatedOrder.Order)
                //Block = Converter.ConvertBlockToBlockModel(allocatedOrder.Block),
                //ExecutedBlock=Converter.
            };
            return allocatedOrderModel;
        }


        internal static List<AllocatedOrdersModel> ConvertAllocatedOrdersListToAllocatedOrdersModelList(List<OrderAllocation> allocatedOrderList)
        {
            List<AllocatedOrdersModel> allocatedOrderModelList=new List<AllocatedOrdersModel>();
            foreach (var allocatedOrder in allocatedOrderList)
            {
                allocatedOrderModelList.Add(new AllocatedOrdersModel()
                {
                    AllocationId = allocatedOrder.AllocationID,
                    ExecutionId = allocatedOrder.ExecutionID,
                    BlockId = allocatedOrder.BlockID,
                    Status = allocatedOrder.Status,
                    AllocatedQuantity = allocatedOrder.AllocatedQuantity,
                    TransactionFee = allocatedOrder.TransactionFee,
                    TransactionPrice = allocatedOrder.TransactionPrice,
                    Block = Converter.ConvertBlockToBlockModel(allocatedOrder.Block),
                    Order=Converter.ConvertOrderToOrderModel(allocatedOrder.Order)
                    //ExecutedBlock=Converter.
                });
            };
            return allocatedOrderModelList;
        }
        internal static ExecutedBlocksModel ConvertExecutedBlockToExecutedBlockModel(ExecutedBlock executedBlock)
        {
            ExecutedBlocksModel executedBlockModel = new ExecutedBlocksModel()
            {
                ExecutedBlockId = executedBlock.ExecutedBlockID,
                BlockId = executedBlock.BlockID,
                ExecutedQuantity = executedBlock.ExecutedQuantity,
                TransactionPrice = executedBlock.TransactionPrice,
                TransactionTime = executedBlock.TransactionTime,
                Status = executedBlock.Status,
                Block = Converter.ConvertBlockToBlockModel(executedBlock.Block),
                AllocatedOrders = new ObservableCollection<AllocatedOrdersModel>
                    (Converter.ConvertAllocatedOrdersListToAllocatedOrdersModelList(executedBlock.OrderAllocations.ToList()))
            };

            return executedBlockModel;
        }
    }
}
