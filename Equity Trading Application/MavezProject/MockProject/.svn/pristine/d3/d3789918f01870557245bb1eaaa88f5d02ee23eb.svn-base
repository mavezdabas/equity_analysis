using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace EquityTradingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPortfolioService
    {
        [OperationContract]
        List<OrderContract> GetAllOrders();
        [OperationContract]
        List<SecurityContract> GetAllSecurities();
        [OperationContract]
        List<UserContract> GetAllUsersByRoleID(int id);
        [OperationContract]
        OrderContract GetOrderByID(int id);
        [OperationContract]
        void InsertOrder(OrderContract orderToInsert);
        [OperationContract]
        void UpdateOrder(OrderContract orderToUpdate);
        [OperationContract]
        void DeleteOrder(OrderContract orderToDelete);

        [OperationContract]
        UserContract GetUserByUserID(int id);
        [OperationContract]
        string GetNameByUserID(int id);

        [OperationContract]
        UserRoleContract GetUserRoleByID(int id);
        [OperationContract]
        string GetRoleNameByRoleID(int id);

        [OperationContract]
        ClientContract GetClientByID(int id);
        [OperationContract]
        string GetClientNameByID(int id);

        [OperationContract]
        SecurityContract GetSecurityByID(int id);
        [OperationContract]
        string GetSecurityNameByID(int id);

        [OperationContract]
        PortfolioContract GetPortfolioByID(int id);
        [OperationContract]
        string GetPortfolioNameByID(int id);

        [OperationContract]
        StatusContract GetStatusByID(int id);
        [OperationContract]
        string GetStatusNameByID(int id);


    }

   
}
