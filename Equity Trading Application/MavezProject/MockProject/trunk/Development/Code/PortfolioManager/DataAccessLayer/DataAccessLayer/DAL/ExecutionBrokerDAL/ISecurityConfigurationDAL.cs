using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public interface ISecurityConfigurationDAL
    {
        List<Security> GetSecurities();
        void UpdateSecurityConfig(SecurityConfigurationDetail securityConfig);
        void AddSecurityConfig(SecurityConfigurationDetail securityConfig);
        List<SecurityConfigurationDetail> GetAllDetails();
        SecurityConfigurationDetail GetSecurityConfigurationDetailsByBlockId(Block block);
    }
}
