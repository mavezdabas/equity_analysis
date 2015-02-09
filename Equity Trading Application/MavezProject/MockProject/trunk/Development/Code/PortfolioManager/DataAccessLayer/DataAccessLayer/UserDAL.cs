using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
   public class UserDAL:IUserDAL
    {
        public List<User> GetAllUsersByRoleID(int id)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var list = (from users in ctx.Users
                            where users.RoleID == id
                            select users).ToList();
                return list;
            }
        }

        public User GetUserByUserID(int id)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var user = (from u in ctx.Users
                            where u.UserID == id
                            select u).FirstOrDefault();
                return user;
            }
        }

        public string GetNameByUserID(int id)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var user = (from u in ctx.Users
                            where u.UserID == id
                            select u.Name).FirstOrDefault();
                return user;
            }
        }
        public UserRole GetUserRoleByID(int id)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var userRole = (from u in ctx.UserRoles
                                where u.RoleID == id
                                select u).FirstOrDefault();
                return userRole;
            }
        }

        public string GetRoleNameByRoleID(int id)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var roleName = (from u in ctx.UserRoles
                                where u.RoleID == id
                                select u.RoleName).FirstOrDefault();
                return roleName;
            }
        }


        public User getUserByUser(User userToAuthenticate)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var user1 = (from u in ctx.Users
                            where (u.UserName == userToAuthenticate.UserName && u.Password == userToAuthenticate.Password)
                            select u).FirstOrDefault();

                return user1;
            }
        }

        public string GetTraderNameByTraderID(int id)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var traderName = (from trader in ctx.Users 
                                  where trader.UserID == id
                                  select trader.UserName).FirstOrDefault();
                return traderName;
            }
        }
        public List<string> GetAllTraderNames()
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var traderNames = (from trader in ctx.Users
                                   where trader.RoleID == 2
                                   select trader.UserName).ToList();
                return traderNames;
            }


        }
        public List<User> GetAllUsers()
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var list = (from users in ctx.Users
                            select users).ToList();
                return list;
            }
        }


        public void UpdatePassword(User user)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                ctx.Users.Attach(user);
                ctx.ObjectStateManager.ChangeObjectState(user, System.Data.EntityState.Modified);
                ctx.SaveChanges();
            }
        }
    }
}
