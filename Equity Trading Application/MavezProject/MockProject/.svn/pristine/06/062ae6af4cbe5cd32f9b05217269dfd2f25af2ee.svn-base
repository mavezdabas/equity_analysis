using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class SecuritiesDAL : ISecuritiesDAL
    {

        public int GetAvailableSecurityExecutionQuantity(int securityID)
        {
            using(EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                return (from security in context.Securities
                        where security.SecurityID == securityID
                        select security.ExecutionQuantity).FirstOrDefault();
            }
        }

        public List<Security> GetSecurities()
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var securities = (from config in ctx.Securities.Include("SecurityConfigurationDetails")
                                  select config).ToList();
                return securities;
            }
        }
        public Security GetSecurities(Block block)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var securities = (from config in ctx.Securities
                                  where block.SecurityID == config.SecurityID
                                  select config).FirstOrDefault();
                return securities;
            }
        }


        public List<Security> GetSecuritiesMarketPrice()
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var securityLastTradePrices = (from security in ctx.Securities
                                               select security).ToList();
                return securityLastTradePrices;
            }
        }

        public void UpdateSecurity(Security security)
        {
            EquityTradingDBEntities ctx = new EquityTradingDBEntities();
            ctx.Securities.Attach(security);
            ctx.ObjectStateManager.ChangeObjectState(security, System.Data.EntityState.Modified);
            ctx.SaveChanges();
        }


    }
}
