using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public interface ILoginCredentials
    {
        User BrokerDetails(User name);
        string ReturnPassword(string userName);
        User CheckForPassword(string userName);
        void UpdateBrokerPassword(User userDetailsReset);
    }
}
