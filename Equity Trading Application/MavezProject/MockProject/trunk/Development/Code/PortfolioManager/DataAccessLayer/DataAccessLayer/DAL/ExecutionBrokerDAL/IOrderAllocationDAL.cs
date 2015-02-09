using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public interface IOrderAllocationDAL
    {
        int GetAllocatedQtySum(Order order);
        void InsertAllocatedOrder(OrderAllocation orderToAllocate);
        void ExpireOpenOrders(OrderAllocation orderToExpire);

        OrderAllocation GetAllocatedOrderByID(Order order);
    }
}
