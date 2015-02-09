using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyService : IMyService
    {
        PortfolioDAL dalObject;

        public string GetData()
        {
            dalObject = new PortfolioDAL();
            List<Block> blocks = dalObject.GetAllBlocks();

            foreach (var item in blocks)
            {
                if (item.Side == "BUY")
                {

                    int stockId = dalObject.GetStockIdFromBlockId(item.BlockID);

                    if (dalObject.GetMarketPriceById(stockId) <= item.LimitPrice + 2 ||
                        dalObject.GetMarketPriceById(stockId) >= item.StopPrice - 2)
                    {
                        item.StatusId = 4;
                        dalObject.UpdateBlock(item);
                        string orders = dalObject.GetOrdersStringFromBlockID(item.BlockID);
                        string[] Orders = orders.Split(' ');

                        for (int i = 0; i < Orders.Length - 1; i++)
                        {
                            int orderID = int.Parse(Orders[i]);
                            Order order = dalObject.GetOrderByOrderId(orderID);
                            order.StatusID = 4;
                            dalObject.UpdateOrder(order);

                        }
                    }
                }
                else if (item.Side == "SELL")
                {
                    int stockId = dalObject.GetStockIdFromBlockId(item.BlockID);

                    if (dalObject.GetMarketPriceById(stockId) <= item.LimitPrice - 2 ||
                        dalObject.GetMarketPriceById(stockId) >= item.StopPrice + 2)
                    {
                        item.StatusId = 4;

                        string orders = dalObject.GetOrdersStringFromBlockID(item.BlockID);
                        string[] Orders = orders.Split(' ');

                        for (int i = 0; i < Orders.Length - 1; i++)
                        {
                            int orderID = int.Parse(Orders[i]);
                            Order order = dalObject.GetOrderByOrderId(orderID);
                            order.StatusID = 4;
                            dalObject.UpdateOrder(order);

                        }
                    }
                }
            }
            return dalObject.GetMarketPriceBySymbol("AAPL").ToString() + "helo";
        }
    }
}
