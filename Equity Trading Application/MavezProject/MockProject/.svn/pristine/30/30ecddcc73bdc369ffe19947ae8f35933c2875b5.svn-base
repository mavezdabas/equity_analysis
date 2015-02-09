using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer;
using AutoMapper;

namespace EquityTradingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class PortfolioService : IPortfolioService
    {
       private IPortfolioDAL dalObject;
       private IUserDAL dalUserObj;
       public PortfolioService()
        {
            dalObject = new PortfolioDAL();
            dalUserObj = new UserDAL();
            Mapper.CreateMap<Order, OrderContract>();
            Mapper.CreateMap<Security, SecurityContract>();
            Mapper.CreateMap<User, UserContract>();
            Mapper.CreateMap<UserRole, UserRoleContract>();
            Mapper.CreateMap<Status, StatusContract>();
            Mapper.CreateMap<Portfolio, PortfolioContract>();
            Mapper.CreateMap<Client, ClientContract>();

 
            
        }




        public List<OrderContract> GetAllOrders()
        {
            List<OrderContract> list = new List<OrderContract>();
            foreach (var item in dalObject.GetAllOrders())
            {
                list.Add(Mapper.Map<Order, OrderContract>(item));
            }
            return list;
        }


        public List<SecurityContract> GetAllSecurities()
        {
            List<SecurityContract> list = new List<SecurityContract>();
            foreach (var item in dalObject.GetAllSecurities())
            {
                list.Add(Mapper.Map<Security, SecurityContract>(item));
            }
            return list;
           
        }


        public List<UserContract> GetAllUsersByRoleID(int id)
        {
            List<UserContract> list = new List<UserContract>();
            foreach (var item in dalUserObj.GetAllUsersByRoleID(id))
            {
                list.Add(Mapper.Map<User, UserContract>(item));
            }
            return list;
        }



        public OrderContract GetOrderByID(int id)
        {
            OrderContract orderContract = new OrderContract();
            orderContract = Mapper.Map<Order,OrderContract>(dalObject.GetOrderByID(id));
            return orderContract;
        }


        public void InsertOrder(OrderContract orderToInsert)
        {
            dalObject.InsertOrder(Mapper.Map<OrderContract, Order>(orderToInsert));
        }



        public void UpdateOrder(OrderContract orderToUpdate)
        {
            dalObject.UpdateOrder(Mapper.Map<OrderContract, Order>(orderToUpdate));
        }


        public void DeleteOrder(OrderContract orderToDelete)
        {
            dalObject.DeleteOrder(Mapper.Map<OrderContract,Order>(orderToDelete));
        }


        public UserContract GetUserByUserID(int id)
        {

            var userContract = Mapper.Map<User, UserContract>(dalUserObj.GetUserByUserID(id));
            return userContract;
        }

        public string GetNameByUserID(int id)
        {
            var userName = dalUserObj.GetNameByUserID(id);
            return userName;
        }

        public UserRoleContract GetUserRoleByID(int id)
        {
            var userRoleContract = Mapper.Map<UserRole, UserRoleContract>(dalUserObj.GetUserRoleByID(id));
            return userRoleContract;
        }

        public string GetRoleNameByRoleID(int id)
        {
            var roleName = dalUserObj.GetRoleNameByRoleID(id);
            return roleName;
        }

        public ClientContract GetClientByID(int id)
        {
            var clientContract = Mapper.Map<Client, ClientContract>(dalObject.GetClientByID(id));
            return clientContract;
        }

        public string GetClientNameByID(int id)
        {
            var clientName = dalObject.GetClientNameByID(id);
            return clientName;
        }

        public SecurityContract GetSecurityByID(int id)
        {
            var securityContract = Mapper.Map<Security, SecurityContract>(dalObject.GetSecurityByID(id));
            return securityContract;
        }

        public string GetSecurityNameByID(int id)
        {
            var securityName = dalObject.GetSecurityNameByID(id);
            return securityName;
        }

        public PortfolioContract GetPortfolioByID(int id)
        {
            var portfolioContract = Mapper.Map<Portfolio, PortfolioContract>(dalObject.GetPortfolioByID(id));
            return portfolioContract;
        }

        public string GetPortfolioNameByID(int id)
        {
            var portfolioName = dalObject.GetPortfolioNameByID(id);
            return portfolioName;
        }

        public StatusContract GetStatusByID(int id)
        {
            var statusContract = Mapper.Map<Status, StatusContract>(dalObject.GetStatusByID(id));
            return statusContract;
        }

        public string GetStatusNameByID(int id)
        {
            var statusName = dalObject.GetStatusNameByID(id);
            return statusName;
        }
    }
}
