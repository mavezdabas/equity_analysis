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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasterDataManagementUI.Market;
using MasterDataManagementUI.CommodityType;
using MasterDataManagementUI.Location;
using MasterDataManagementUI.Currency;
using System.Collections.ObjectModel;
using MasterDataManagement.UIEntities;
using DataAccessLayer.DAL;
using MasterDataManagmentUI.Converters;
using MasterDataMangementUI.Converters;
using CommonContracts;
using MasterDatamangementUI.Converters;
using MasterDatamanagementUI.Converters;
using System.Collections;
using MasterDataManagementUI.UserManagement;


namespace MasterDataManagementUI.UserManagement
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        public UserProfile()
        {
            InitializeComponent();
            List<String> UserRoleList = new List<string>();
            UserRoleList.Add(Convert.ToString(UserRole.AdminUser));
            UserRoleList.Add(Convert.ToString(UserRole.BusinessUser));
            Save.Focus();
        }
            private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserPOCO userEdit = new UserPOCO();
            try
            {
               
                userEdit.LoginId = LoginID.Text;
                userEdit.Name = Username.Text;
                userEdit.UserId = UserSession.UserId;
                bool changeCheck = UserDAL.ProfileEdit(userEdit);
                if (changeCheck) { MessageBox.Show("Change Successful"); UserSession.LoginId = userEdit.LoginId; UserSession.Name = Username.Text; this.Close(); }
                else MessageBox.Show("LoginID already Exists");
                
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
            }
           

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();           
        }

        private void Button_Click_ChangePassword(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow newWindow = new ChangePasswordWindow();
            newWindow.Show();
            this.Close();

        }

    }
}
