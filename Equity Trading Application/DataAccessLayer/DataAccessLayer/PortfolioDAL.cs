using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class PortfolioDAL
    {
        public void InsertIntoStock(Stock stock)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Stocks.AddObject(stock);
                ctx.SaveChanges();
            }
        }

        public void InsertOrder(Order order)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Orders.AddObject(order);
                ctx.SaveChanges();
            }
        }

        public void UpdateStock(Stock stockToUpdate)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Stocks.Attach(stockToUpdate);
                ctx.ObjectStateManager.ChangeObjectState(stockToUpdate, System.Data.EntityState.Modified);
                ctx.SaveChanges();
                ctx.Stocks.Detach(stockToUpdate);
            }
        }

        public void UpdateUser(User userToUpdate)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Users.Attach(userToUpdate);
                ctx.ObjectStateManager.ChangeObjectState(userToUpdate, System.Data.EntityState.Modified);
                ctx.SaveChanges();
                ctx.Users.Detach(userToUpdate);
            }
        }

        public void UpdateBlock(Block stockToUpdate)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Blocks.Attach(stockToUpdate);
                ctx.ObjectStateManager.ChangeObjectState(stockToUpdate, System.Data.EntityState.Modified);
                ctx.SaveChanges();
                ctx.Blocks.Detach(stockToUpdate);
            }
        }

        public int GetStockIdFromBlockId(int blockId)
        {
            string orders = GetOrdersStringFromBlockID(blockId);

            string[] Orders = orders.Split(' ');

            int orderID = int.Parse(Orders[0]);

            return (int)GetStockIDFromOrderID(orderID);
        }

        public int GetStockIdFromSymbol(string symbol)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var id = (from c in ctx.Stocks
                          where c.StockSymbol == symbol
                          select c.StockID).FirstOrDefault();
                return id;
            }
        }

        public int? GetStockIDFromOrderID(int orderId)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.OrderID == orderId
                           select c.StockID).First();
                return res;
            }
        }

        public int GetQuantityFromStockSymbol(string symbol)
        {

            return 100;
        }

        public void DeleteBlock(Block blockToDelete)
        {

            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = from c in ctx.Orders
                          where c.BlockID == blockToDelete.BlockID
                          select c;
                foreach (var item in res)
                {
                    ctx.Orders.Detach(item);
                    DeleteOrder(item);
                }
            }
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Blocks.Attach(blockToDelete);
                ctx.DeleteObject(blockToDelete);
                ctx.SaveChanges();
            }
        }

        public void DeleteOrder(Order orderToDelete)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Orders.Attach(orderToDelete);
                ctx.DeleteObject(orderToDelete);
                ctx.SaveChanges();
            }
        }

        public decimal? GetMarketPriceBySymbol(string symbol)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Stocks
                           where c.StockSymbol == symbol
                           select c.MarketPrice).First();
                decimal? mp = res;
                return mp;
            }
        }

        public decimal? GetMarketPriceById(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Stocks
                           where c.StockID == id
                           select c.MarketPrice).First();
                decimal? mp = res;
                return mp;
            }
        }

        public string GetStockNameByOrderID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.OrderID == id
                           select c.StockID).First();

                var stockName = (from c in ctx.Stocks
                                 where c.StockID == res
                                 select c.StockName).First();

                return stockName;
            }
        }

        public List<Order> GetAllOrders()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = from c in ctx.Orders
                          select c;
                return res.ToList();
            }
        }

        public string GetStockNameByID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var stockName = (from c in ctx.Stocks
                                 where c.StockID == id
                                 select c.StockName).First();

                return stockName;
            }
        }

        public string GetStockSymbolByID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var stockName = (from c in ctx.Stocks
                                 where c.StockID == id
                                 select c.StockSymbol).First();

                return stockName;
            }
        }

        public Stock GetStockById(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var stock = (from c in ctx.Stocks
                             where c.StockID == id
                             select c).First();
                return stock;
            }
        }

        public decimal GetStockMarketPriceByID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var stockName = (from c in ctx.Stocks
                                 where c.StockID == id
                                 select c.MarketPrice).First();

                return (decimal)stockName;
            }
        }

        public List<Stock> GetAllStocks()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var stocks = from stock in ctx.Stocks
                             select stock;
                return stocks.ToList();
            }
        }

        public List<Block> GetAllBlocks()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var stocks = from stock in ctx.Blocks
                             select stock;
                return stocks.ToList();
            }
        }

        public string GetStatusByStatusId(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var statusName = (from st in ctx.Status
                                  where st.StatusID == id
                                  select st.StatusName).First();
                return statusName;
            }
        }

        public List<string> GetAllSymbols()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var symbols = from st in ctx.Stocks
                              select st.StockSymbol;
                return symbols.ToList();
            }
        }

        public void InsertBlock(Block blockToInsert)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Blocks.AddObject(blockToInsert);
                ctx.SaveChanges();
            }
        }

        public int GetMaxBlockID()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = from c in ctx.Blocks
                          select c;
                if (res.Count() == 0)
                    return 1;
                else
                    return res.Count() + 1;
            }
        }

        public int GetMaxOrderID()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = from c in ctx.Orders
                          select c;
                if (res.Count() == 0)
                    return 1;
                else
                    return res.Count() + 1;
            }
        }

        public string GetSideByOrderID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.OrderID == id
                           select c.Side).First();
                return res;
            }
        }

        public void UpdateOrder(Order orderToUpdate)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                ctx.Orders.Attach(orderToUpdate);
                ctx.ObjectStateManager.ChangeObjectState(orderToUpdate, System.Data.EntityState.Modified);
                ctx.SaveChanges();
                ctx.Orders.Detach(orderToUpdate);
            }
        }

        public Order GetOrderByOrderId(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.OrderID == id
                           select c).First();
                return res;
            }
        }

        public Block GetBlockByBlockId(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Blocks
                           where c.BlockID == id
                           select c).First();
                return res;
            }
        }

        public decimal? GetLimitPriceByOrderId(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.OrderID == id
                           select c.LimitPrice).First();
                return res;
            }
        }

        public decimal? GetStopPriceByOrderId(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.OrderID == id
                           select c.StopPrice).First();
                return res;
            }
        }

        public string GetSymbolFromBlockID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Orders
                           where c.BlockID == id
                           select c.StockID).First();

                var s = (from c in ctx.Stocks
                         where c.StockID == res
                         select c.StockSymbol).First();
                return s;


            }

        }

        public string GetOrdersStringFromBlockID(int id)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Blocks
                           where c.BlockID == id
                           select c.Orders).First();
                return res;
            }

        }

        //LOGIN

        public string GetPasswordFromUserName(string userName)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Users
                           where c.UserName == userName
                           select c.Password).First();
                return res;
            }
        }

        public List<string> GetAllClients()
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = from c in ctx.Clients
                          select c.ClientName;
                return res.ToList();
            }

        }

        public int GetRoleIdFromPassword(string password)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var res = (from c in ctx.Users
                           where c.Password == password
                           select c.RoleID).First();
                return (int)res;
            }
        }

        public string GetKeyFromUserName(string userName)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var key = (from c in ctx.Users
                           where c.UserName == userName
                           select c.VerificationKey).FirstOrDefault();
                return key;
            }
        }

        public User GetUserFromUserName(string userName)
        {
            using (MockProjectDBEntities ctx = new MockProjectDBEntities())
            {
                var key = (from c in ctx.Users
                           where c.UserName == userName
                           select c).First();
                return key;
            }
        }



    }
}