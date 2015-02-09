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
using System.Collections;
using CommonContracts;
using DataAccessLayer.DAL;

namespace MasterDataManagementUI.UserManagement
{
    /// <summary>
    /// Interaction logic for DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        static int flagsearch = -1;
        public DeleteUser()
        {

            InitializeComponent();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

            var x = chkMultiple.IsChecked;
            //MessageBox.Show(Convert.ToString(x));
            if (x == true) Button_Click_Delete_Multiple(sender, e);
            else
            {
                if (flagsearch == -1)
                {
                    MessageBox.Show("Please enter something to search ");
                }
                else
                {
                    object deleteUser = DeleteSearchGrid.SelectedItem;
                    UserPOCO newUserPoco = (UserPOCO)deleteUser;
                    //MessageBox.Show(newUserPoco.Name);
                    UserDAL.DeleteUser(newUserPoco);
                    String name = UserIdSearchBox.Text;
                    var gridData = UserDAL.SearchForDelete(name);
                    DeleteSearchGrid.DataContext = gridData;
                }
            }
        }

        private void Button_Click_Delete_Multiple(object sender, RoutedEventArgs e)
        {

            if (flagsearch == -1)
            {
                MessageBox.Show("Please enter something to search ");
            }
            else
            {
                IList deleteUser = DeleteSearchGrid.SelectedItems;
                foreach (var eachUser in deleteUser)
                {
                    UserPOCO newUserPoco = (UserPOCO)eachUser;
                    UserDAL.DeleteUser(newUserPoco);
                }
                String name = UserIdSearchBox.Text;
                var gridData = UserDAL.SearchForDelete(name);
                DeleteSearchGrid.DataContext = gridData;
                chkMultiple.IsChecked = false;

            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            String name = null;
            name = UserIdSearchBox.Text;
            if (name.Equals(""))
            {
                MessageBox.Show("Please enter the username to search");
                InitializeComponent();
            }
            else
            {
                var gridData = UserDAL.SearchForDelete(name);
                if (gridData.Count == 0)
                {
                    MessageBox.Show("Please enter a valid username");
                }
                else
                {
                    flagsearch = 0;
                    DeleteSearchGrid.DataContext = gridData;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // navigate user to the Home Window 
            //UserHomePage userHomePage= new UserHomeUser();
        }
    }
}
