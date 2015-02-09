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
    /// Interaction logic for EditWindowDetails.xaml
    /// </summary>
    public partial class EditWindowDetails : Window
    {
        static string previousId;
        public EditWindowDetails()
        {
            InitializeComponent();
            List<String> UserRoleList = new List<string>();
            UserRoleList.Add(Convert.ToString(UserRole.AdminUser));
            UserRoleList.Add(Convert.ToString(UserRole.BusinessUser));
            SaveBtn.Focus();
            cmbUserRole.ItemsSource = UserRoleList;
            cmbUserRole.SelectedIndex = 1 ;
            cmbUserRole.Text = UserRole.AdminUser.ToString() ;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserPOCO userEdit = new UserPOCO();

            //userEdit.DateOfBirth = DOB.SelectedDate.Value.Date;
            //userEdit.DateOfJoining = DOJ.SelectedDate.Value.Date;

            userEdit.DateOfBirth = DOB.SelectedDate.Value.Date;
            userEdit.DateOfJoining = DOJ.SelectedDate.Value.Date;
            userEdit.LoginId = LoginID.Text;
            userEdit.Name = Username.Text;

            string Rolevalue = cmbUserRole.Text;
            userEdit.Role = (UserRole)Enum.Parse(typeof(UserRole), Rolevalue);
            userEdit.Password = Password.Text;
            UserPOCO checkExistingUser = UserDAL.SearchSingleUser(userEdit);
            if ((checkExistingUser == null || checkExistingUser.IsDeleted.Equals("true")) || previousId.Equals(userEdit.LoginId))
            {
                UserDAL.AdminEditUser(userEdit,previousId);
                MessageBox.Show("Edit Successful");
                this.Close();
            }
            else MessageBox.Show("Login ID Already Exists!");

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
             
            String Role = UserSession.Role.ToString();
            if (Role.Equals("AdminUser"))
            {
                
                this.Close();
            }
            if (Role.Equals("BusinessUser"))
            {
                
                this.Close();
            }
        }

        private void Edit_Window_Loaded(object sender, RoutedEventArgs e)
        {
            previousId = LoginID.Text;
        }
        
    }
}
