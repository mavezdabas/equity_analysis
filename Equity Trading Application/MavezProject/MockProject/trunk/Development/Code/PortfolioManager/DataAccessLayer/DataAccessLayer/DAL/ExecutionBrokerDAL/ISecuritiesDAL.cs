using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public interface ISecuritiesDAL
    {
        Security GetAvailableSecurityExecutionQuantity(int securityID);
        List<Security> GetSecurities();
        Security GetSecurities(Block block);
        void UpdateSecurity(Security security);
    }
}
