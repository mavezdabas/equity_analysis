using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class SecurityConfigurationDAL : ISecurityConfigurationDAL
    {
        public List<Security> GetSecurities()
        {
            using(EquityTradingDBEntities ctx=new EquityTradingDBEntities())
            {
                var securities = (from config in ctx.Securities.Include("SecurityConfigurationDetails")
                                  select config).ToList();
                return securities;
            }
        }

        public SecurityConfigurationDetail GetSecurityConfigurationDetailsByBlockId(Block block)
        {
            // List<Security> securityList = new List<Security>();
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {

                var securityConfiguration = (from config in ctx.SecurityConfigurationDetails
                                             where config.SecurityID == block.SecurityID
                                             select config).FirstOrDefault();
                return securityConfiguration;
            }

        }

        public void UpdateSecurityConfig(SecurityConfigurationDetail securityConfig)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                ctx.SecurityConfigurationDetails.Attach(securityConfig);
                ctx.ObjectStateManager.ChangeObjectState(securityConfig,System.Data.EntityState.Modified);
                ctx.SaveChanges();
            }
        }

        public void AddSecurityConfig(SecurityConfigurationDetail securityConfig)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                ctx.SecurityConfigurationDetails.AddObject(securityConfig);
                ctx.SaveChanges();
            }
        }

        public List<SecurityConfigurationDetail> GetAllDetails()
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var result = (from c in ctx.SecurityConfigurationDetails
                              select c).ToList();
                return result;
            }
        }
    }
}
