using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
   public class OrderDAL : IOrderDAL
    {
       public int OrderCountPerBlock(Block block)
       {
           using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
           {

               var orderCount = ((from o in ctx.Blocks.Include("Orders")
                                  where block.BlockID == o.BlockID
                                  select o.Orders.Count()).FirstOrDefault());



               return orderCount;
           }
       }

       public void UpdateOrder(Order orderToUpdate)
       {
           using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
           {
               ctx.Orders.AddObject(orderToUpdate);
               ctx.SaveChanges();
           }
       }
    }
}
