using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class OrderAllocationDAL : IOrderAllocationDAL
    {
        public int GetAllocatedQtySum(Order orderInExecution)
        {
            using(EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                return (from order in context.OrderAllocations
                        where order.OrderID == orderInExecution.OrderID
                        select order.AllocatedQuantity).Sum();
            }
        }


        public void InsertAllocatedOrder(OrderAllocation orderToAllocate)
        {
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                context.OrderAllocations.Attach(orderToAllocate);
                context.ObjectStateManager.ChangeObjectState(orderToAllocate, System.Data.EntityState.Added);
                context.OrderAllocations.AddObject(orderToAllocate);
                context.SaveChanges();
            }
        }

        public void ExpireOpenOrders(OrderAllocation orderToExpire)
        {
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                context.OrderAllocations.Attach(orderToExpire);
                context.ObjectStateManager.ChangeObjectState(orderToExpire, System.Data.EntityState.Modified);
                context.SaveChanges();
            }
        }


        public OrderAllocation GetAllocatedOrderByID(Order order)
        {
            OrderAllocation allocatedOrderToReturn = null;
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                allocatedOrderToReturn = (from allocatedOrder in context.OrderAllocations
                                          where allocatedOrder.OrderID == order.OrderID
                                          select allocatedOrder).FirstOrDefault();
            }
            return allocatedOrderToReturn;
        }
    }
}
