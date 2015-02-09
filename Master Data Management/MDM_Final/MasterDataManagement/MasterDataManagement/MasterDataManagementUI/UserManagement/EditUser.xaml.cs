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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {   
        static int flagsearch = -1;
        public EditUser()
        {
            InitializeComponent();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            String name = UserIdSearchBox.Text;
            var gridData= UserDAL.SearchUser(name);
            if (gridData.Count == 0) MessageBox.Show("Your Search did not give any results.");

            else { EditSearchGrid.DataContext = gridData; flagsearch = 0; }
            
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            
            object editUser = EditSearchGrid.SelectedItem;
            UserPOCO newUserPoco = (UserPOCO)editUser;
            if (newUserPoco != null)
            {
                //MageBox.Show(newUserPoco.LoginId);

                EditWindowDetails newWindow = new EditWindowDetails();
                newWindow.DataContext = EditSearchGrid.SelectedItem;

                newWindow.Show();
                this.Close();
            }
            else if (flagsearch == 0) MessageBox.Show("Please select a field from the results");
            else MessageBox.Show("Please Search for a User First");
            ////MessageBox.Show(newUserPoco.Name);
            //UserDAL.EditUserDetails(newUserPoco);
            //String name = UserIdSearchBox.Text;
            //var gridData = UserDAL.SearchForDelete(name);
            //DeleteSearchGrid.DataContext = gridData;
        }

        private void Button_Click_Return(object sender, RoutedEventArgs e)
        {
            String Role = UserSession.Role.ToString();
            if (Role.Equals("AdminUser"))
            {
                //AdminHomePage newAdminWindow = new AdminHomePage();
                //newAdminWindow.Show();
                this.Close();
            }
            //if (Role.Equals("BusinessUser"))
            //{
            //    //UserHomePage newUserWindow = new UserHomePage();
            //    //newUserWindow.Show();
            //    this.Close();
            //}
        }
    }
}
