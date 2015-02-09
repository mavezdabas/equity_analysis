using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommonContracts;
using DataAccessLayer.DAL;

namespace MasterDataManagementUI.UserManagement
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public static string newpassword = null;
        public static string reenterpassword = null;
        bool flag = false;

        public ChangePasswordWindow()
        {
            InitializeComponent();
            Chng_Button.Focus();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserPOCO UserChangePassword = new UserPOCO();
            UserChangePassword.LoginId = UserSession.LoginId;
            UserPOCO newUser = UserDAL.SearchSingleUser(UserChangePassword);

            if (newUser != null)
            {
                if (string.IsNullOrWhiteSpace(CurrentPassword.Password) || string.IsNullOrWhiteSpace(NewPassword.Password) || string.IsNullOrWhiteSpace(ReEnterPassword.Password))
                {
                    lblError.Content = "Please Enter all the fields";
                    InitializeComponent();
                }
                else
                {
                    UserChangePassword.Password = CurrentPassword.Password;
                    newpassword = NewPassword.Password;
                    reenterpassword = ReEnterPassword.Password;
                    if (newpassword.Equals(reenterpassword))
                        flag = UserDAL.ChangePassword(UserChangePassword, newpassword);
                    else lblError.Content = "Entered Passwords do not match";
                    if (flag)
                    { MessageBox.Show("Password change successful"); this.Close(); }
                    else
                        lblError.Content = "Password mismatch";
                }
            }
            else lblError.Content = "Enter LoginId does not exist";
                      
        }



    }
}