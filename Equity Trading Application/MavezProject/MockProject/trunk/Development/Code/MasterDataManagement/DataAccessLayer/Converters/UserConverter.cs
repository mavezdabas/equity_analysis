using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DBML;
using CommonContracts;

namespace DataAccessLayer.Converters
{
    public class UserConverter
    {
        public static User ConvertToUser(UserPOCO user)
        {
            User newUser = new User();

            newUser.UserId = user.UserId;
            newUser.LoginId = user.LoginId;

            newUser.DateOfBirth = user.DateOfBirth;
            newUser.DateOfJoining = user.DateOfJoining;

            newUser.Name = user.Name;
            newUser.Role = user.Role.ToString();
            newUser.Password = user.Password;
            newUser.IsDeleted = Convert.ToString(user.IsDeleted);
            return newUser;
        }

        public static UserPOCO ConvertToUserPOCO(User user)
        {
            UserPOCO newUser = new UserPOCO();
            if (user != null)
            {
                newUser.UserId = user.UserId;
                newUser.LoginId = user.LoginId;

                newUser.DateOfBirth = user.DateOfBirth;
                newUser.DateOfJoining = user.DateOfJoining;

                newUser.Name = user.Name;
                newUser.Role = (UserRole)Enum.Parse(typeof(UserRole), user.Role);
                newUser.Password = user.Password;
                newUser.IsDeleted = Convert.ToBoolean(user.IsDeleted);
                return newUser;
            }
            else return null;
        }
    }
}
