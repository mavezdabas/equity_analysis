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
    /// Interaction logic for ResetWindowPassword.xaml
    /// </summary>
    public partial class ResetWindowPassword : Window
    {
        public ResetWindowPassword()
        {
            InitializeComponent();
            LoginID.Text = UserSession.LoginId.ToString();
        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {

            UserPOCO resetPasswordPOCO = new UserPOCO();

            if (!DOB.SelectedDate.HasValue || !DOJ.SelectedDate.HasValue)
                lblError.Content="Enter valid details";
            else
            {
                UserSession.LoginId = LoginID.Text;
                resetPasswordPOCO.LoginId = LoginID.Text;
                resetPasswordPOCO.DateOfBirth = DOB.SelectedDate.Value.Date;
                resetPasswordPOCO.DateOfJoining = DOJ.SelectedDate.Value.Date;
                bool finalResult = UserDAL.DetailsConfirmation(resetPasswordPOCO);
                if (finalResult == true)
                {
                    ResetPasswordWindow2 win2 = new ResetPasswordWindow2();

                    win2.Show();
                    this.Close();

                }
                else
                {
                    lblError.Content = "Incorrect details";
                }
               
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            LoginWindow newLoginWindow = new LoginWindow();
            newLoginWindow.Show();
            this.Close();
        }

    }
}
