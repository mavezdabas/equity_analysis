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

namespace MasterDataManagementUI.UserManagement
{
    /// <summary>
    /// Interaction logic for ResetPasswordWindow2.xaml
    /// </summary>
    public partial class ResetPasswordWindow2 : Window
    {
        public ResetPasswordWindow2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string newPassword = NewPassword.Password;
            string confirmPassword = ConfirmPassword.Password;
            if (newPassword.Equals(confirmPassword))
            {
                UserDAL.ResetPassword(newPassword);
                LoginWindow newLoginWindow = new LoginWindow();
                newLoginWindow.Show();
                this.Close();
            }
            else
            {
                lblError.Content = "Passwords don't match";
                NewPassword.Password = string.Empty;
                ConfirmPassword.Password = string.Empty;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResetWindowPassword resetPasswordWindow = new ResetWindowPassword();
            resetPasswordWindow.Show();
            this.Close();
        }

    }
}
