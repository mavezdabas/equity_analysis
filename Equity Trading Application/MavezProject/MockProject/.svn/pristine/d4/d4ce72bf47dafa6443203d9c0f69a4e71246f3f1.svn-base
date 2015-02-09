using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;

namespace AutoAllocationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SecurityConfigurationDetails : ISecurityConfigurationDetails
    {
        public List<SecurityConfigurationDetail> GetData()
        {
            ISecurityConfigurationDAL dalObject = new SecurityConfigurationDAL();
            var configDetails = dalObject.GetAllDetails();
            return configDetails;
        }
    }
}
