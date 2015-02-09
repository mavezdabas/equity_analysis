using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class AllocationMethodDAL : IAllocationMethodDAL
    {
        public AllocationMethod GetAllocationMethod()
        {
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                return (from method in context.AllocationMethods
                        select method).FirstOrDefault();
            }
        }

    }
}
