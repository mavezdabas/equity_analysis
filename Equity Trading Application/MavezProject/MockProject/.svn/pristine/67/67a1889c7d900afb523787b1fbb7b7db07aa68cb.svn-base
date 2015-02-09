using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
   public interface IUserDAL
    {
        List<User> GetAllUsersByRoleID(int id);
        List<User> GetAllUsers();
        User getUserByUser(User user);

        void UpdatePassword(User user); 

        User GetUserByUserID(int id);
        string GetNameByUserID(int id);

        UserRole GetUserRoleByID(int id);
        string GetRoleNameByRoleID(int id);
        List<string> GetAllTraderNames();
        string GetTraderNameByTraderID(int id);

    }
}
