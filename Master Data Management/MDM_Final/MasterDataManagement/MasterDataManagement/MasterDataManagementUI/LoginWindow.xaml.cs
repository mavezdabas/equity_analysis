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
using DataAccessLayer.DAL;
using CommonContracts;
using MasterDataManagementUI.UserManagement;


namespace MasterDataManagementUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserPOCO userLogin;

        public LoginWindow()
        {
            InitializeComponent();
            userLogin = new UserPOCO();
            this.LoginGrid.DataContext = userLogin;
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginID.Text))
            {
                lblError.Content = "Enter your username.";
                LoginID.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Password.Password))
            {
                lblError.Content = "Enter your password.";
                Password.Focus();
                return;
            }
          
            
           // userLogin.LoginId = LoginID.Text;

            userLogin.Password = Password.Password;
            UserSession.LoginId = LoginID.Text;
            //bool result = UserDAL.LoginUserCheckExistance(userLogin);

            userLogin = UserDAL.LoginUser(userLogin);
            if (userLogin != null)
            {
                // Setting User Session
                UserSession.LoginId = userLogin.LoginId;
                UserSession.UserId = userLogin.UserId;
                UserSession.Name = userLogin.Name;
                UserSession.Role = userLogin.Role;

                // Calling the Respective window based on the Role of the user that has logged in

                if (UserSession.Role == UserRole.AdminUser)
                {
                    AdminUserHome newAdminWindow = new AdminUserHome();
                    Hide();
                    newAdminWindow.ShowDialog();
                    this.Close();
                }
                else if (UserSession.Role == UserRole.BusinessUser)
                {
                    BusinessUserHome newUserWindow = new BusinessUserHome();
                    Hide();
                    newUserWindow.ShowDialog();
                    this.Close();
                }

            }
            else
            {
                lblError.Content = "The username or password you entered is incorrect.";
                LoginID.Text = string.Empty;
                Password.Password = string.Empty;
                LoginID.Focus();
                return;
            }


        }



        private void Button_Click_ForgotPassword(object sender, RoutedEventArgs e)
        {
            UserPOCO newUser = new UserPOCO();
            newUser.LoginId = LoginID.Text;
            bool result = UserDAL.LoginUserCheckExistance(newUser);

            if (result == true)
            {
                UserSession.LoginId = newUser.LoginId;
                ResetWindowPassword win2 = new ResetWindowPassword();
                win2.Show();
                this.Close();
            }
            else
            {
                lblError.Content = "The LoginID does not exist";
                LoginID.Text = string.Empty;
                Password.Password = string.Empty;
                LoginID.Focus();
                return;
            }
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginID.Focus();
            btnLogin.IsDefault = true;
        }
    }
}
