using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class LoginCredentials: ILoginCredentials
    {
        public User BrokerDetails(User userName)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                var result = (from c in ctx.Users
                              where c.UserName == userName.Name
                              select c).FirstOrDefault();
                return result;
            }

            
        }

        public string ReturnPassword(string userName)
        {
            string password = null;
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                password = (from c in ctx.Users
                                where c.Name == userName
                                select c.Password).FirstOrDefault();

                

            }

            return password;
        }


        public User CheckForPassword(string userName)
        {
            User userForPasswordChange = null;
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                userForPasswordChange = (from c in ctx.Users
                                         where c.UserName == userName
                                         select c).FirstOrDefault();
            }
            return userForPasswordChange;

        }


        public void UpdateBrokerPassword(User userDetailsReset)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                ctx.Users.Attach(userDetailsReset);
                ctx.ObjectStateManager.ChangeObjectState(userDetailsReset, System.Data.EntityState.Modified);
                ctx.SaveChanges();
            }
        }
    }
}
