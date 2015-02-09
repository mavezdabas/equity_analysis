using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using DataAccessLayer.DBML;
using DataAccessLayer.Converters;

namespace DataAccessLayer.DAL
{
    public class UserDAL
    {
        public static void AddNewUser(UserPOCO user)
        {
            User newUser = new User();
            newUser = UserConverter.ConvertToUser(user);
            newUser.IsDeleted = "false";
            MDMDataContext ctx = new MDMDataContext();
            ctx.Users.InsertOnSubmit(newUser);
            ctx.SubmitChanges();
        }

        public static List<UserPOCO> SearchUser(String name)
        {
            MDMDataContext ctx = new MDMDataContext();
            var r = (from e in ctx.Users
                     where e.Name.Contains(name) && e.IsDeleted.Equals("false") && !(e.LoginId.Equals(UserSession.LoginId))
                     select e).ToList();


            List<UserPOCO> pocoList = new List<UserPOCO>();
            foreach (var x in r)
            {
                UserPOCO newpoco = new UserPOCO();
                newpoco = UserConverter.ConvertToUserPOCO(x);
                pocoList.Add(newpoco);
            }

            return pocoList;
        }

        public static void DeleteUser(UserPOCO deleteUserPOCO)
        {
            User deleteUser = new User();
            deleteUser = UserConverter.ConvertToUser(deleteUserPOCO);

            MDMDataContext ctx = new MDMDataContext();
            if (deleteUser != null)
            {
                var userToDelete = (from e in ctx.Users
                                    where e.UserId == deleteUser.UserId
                                    select e).FirstOrDefault();
                userToDelete.IsDeleted = "true";
                ctx.SubmitChanges();
            }
        }

        private static IEnumerable<User> SearchUserInternal(string name)
        {
            MDMDataContext ctx = new MDMDataContext();
            var r = (from e in ctx.Users
                     where e.Name.Contains(name)
                     select e).ToList();
            return r;
        }

        public static List<UserPOCO> SearchForDelete(String name)
        {
            List<User> userList = new List<User>(UserDAL.SearchUserInternal(name));
            List<UserPOCO> pocoList = new List<UserPOCO>();

            foreach (var x in userList)
            {

                UserPOCO newUserPoco = new UserPOCO();

                newUserPoco = UserConverter.ConvertToUserPOCO(x);

                pocoList.Add(newUserPoco);

            }

            return pocoList;
        }

        public static void AdminEditUser(UserPOCO userEditPOCO,String previousId)
        {

            User editUser = new User();
            MDMDataContext ctx = new MDMDataContext();

            editUser = (from e in ctx.Users
                        where e.LoginId.Equals(previousId)
                        select e).FirstOrDefault();

            //editUser.UserId = userEditPOCO.UserId;
            try
            {
                editUser.LoginId = userEditPOCO.LoginId;

                //editUser.DateOfBirth = userEditPOCO.DateOfBirth;
                //editUser.DateOfJoining = userEditPOCO.DateOfJoining;

                editUser.Name = userEditPOCO.Name;
                // editUser.Password = userEditPOCO.Password;
                editUser.Role = userEditPOCO.Role.ToString();
                ctx.SubmitChanges();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        public static UserPOCO LoginUser(UserPOCO user)
        {
            MDMDataContext ctx = new MDMDataContext();
            var loginUserObject = (from e in ctx.Users
                                   where e.LoginId == user.LoginId && e.Password == user.Password && e.IsDeleted.Equals("false")
                                   select e).FirstOrDefault();
            if (loginUserObject != null)
                if (loginUserObject.IsDeleted.Equals("false"))
                    return UserConverter.ConvertToUserPOCO(loginUserObject);
            return null;

        }

        public static bool LoginUserCheckExistance(UserPOCO user)
        {
            MDMDataContext ctx = new MDMDataContext();
            var r = (from e in ctx.Users
                     where e.LoginId == user.LoginId
                     select e).FirstOrDefault();
            if (r != null)
                return true;
            else
                return false;
        }

        public static bool DetailsConfirmation(UserPOCO user)
        {
            MDMDataContext ctx = new MDMDataContext();
            var r = (from e in ctx.Users
                     where e.LoginId == user.LoginId && e.DateOfBirth == user.DateOfBirth && e.DateOfJoining == user.DateOfJoining
                     select e).FirstOrDefault();
            if (r != null)
                return true;
            else
                return false;
        }

        public static int ResetPassword(string newPassword)
        {
            MDMDataContext ctx = new MDMDataContext();
            var r = (from e in ctx.Users
                     where e.LoginId == UserSession.LoginId
                     select e).FirstOrDefault();
            r.Password = newPassword;
            ctx.SubmitChanges();
            return 1;
        }

        public static UserPOCO SearchSingleUser(UserPOCO userPOCO)
        {
            MDMDataContext ctx = new MDMDataContext();
            var userFromDataBase = (from e in ctx.Users
                                    where e.LoginId.Equals(userPOCO.LoginId)
                                    select e).FirstOrDefault();
            return UserConverter.ConvertToUserPOCO(userFromDataBase);

        }

        public static bool ChangePassword(UserPOCO changepassword, string newpassword)
        {
            User newUser = UserConverter.ConvertToUser(changepassword);
            MDMDataContext ctx = new MDMDataContext();
            var r = (from e in ctx.Users
                     where e.LoginId.Equals(changepassword.LoginId) && e.Password.Equals(changepassword.Password)
                     select e).FirstOrDefault();
            if (r != null)
            {
                r.Password = newpassword;
                ctx.SubmitChanges();
                return true;
            }
            else
                return false;
        }

        public static bool ProfileEdit(UserPOCO userEdit)
        {
            User ProfileChangeObject = new User();
            User ProfileChangeObjectCheck = new User();
            MDMDataContext ctx = new MDMDataContext();

            ProfileChangeObject = (from e in ctx.Users
                                   where e.UserId == userEdit.UserId
                                   select e).FirstOrDefault();
            ProfileChangeObjectCheck = (from e in ctx.Users
                                        where e.LoginId.Equals(userEdit.LoginId)
                                        select e).FirstOrDefault();

            if (ProfileChangeObjectCheck == null)
            {
                ProfileChangeObject.LoginId = userEdit.LoginId;
                ProfileChangeObject.Name = userEdit.Name;
                ctx.SubmitChanges();
                return true;
            }
            else if (ProfileChangeObjectCheck.UserId == ProfileChangeObject.UserId || ProfileChangeObjectCheck.IsDeleted.Equals("true"))
            {

                ProfileChangeObject.LoginId = userEdit.LoginId;
                ProfileChangeObject.Name = userEdit.Name;
                ctx.SubmitChanges();
                return true;
            }
            else return false;
        }
    }
}
