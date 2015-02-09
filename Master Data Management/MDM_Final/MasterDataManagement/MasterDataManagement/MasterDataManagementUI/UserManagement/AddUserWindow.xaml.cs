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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            
            InitializeComponent();
            List<String> UserRoleList = new List<string>();
            UserRoleList.Add(Convert.ToString(UserRole.AdminUser));
            UserRoleList.Add(Convert.ToString(UserRole.BusinessUser));
            cmbUserRole.DataContext = UserRoleList;
        }

        
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            UserPOCO userAdd = new UserPOCO();
            if (LoginID.Text.Equals("") || Username.Text.Equals("") || Password.Text.Equals("") || !DOB.SelectedDate.HasValue || !DOJ.SelectedDate.HasValue)
            {
                ErrorBlock.Content = "Please Enter All The Fields";
                InitializeComponent();
            }
            else
            {
                DateTime presentDate = DateTime.Today;
                DateTime bday = DOB.SelectedDate.Value.Date;
                if (DateTime.Compare(presentDate, bday) > 0)
                {
                    userAdd.LoginId = LoginID.Text;
                    UserPOCO checkExistingUser = UserDAL.SearchSingleUser(userAdd);
                    if (checkExistingUser == null || checkExistingUser.IsDeleted.Equals("true"))
                    {
                        userAdd.DateOfBirth = DOB.SelectedDate.Value.Date;
                        userAdd.DateOfJoining = DOJ.SelectedDate.Value.Date;
                        //userAdd.UserId = Convert.ToInt32(UserID.Text);
                        userAdd.Name = Username.Text;
                        string Rolevalue = cmbUserRole.Text;
                        if (!(Rolevalue.Equals("")))
                        {
                            userAdd.Role = (UserRole)Enum.Parse(typeof(UserRole), Rolevalue);
                            userAdd.IsDeleted = false;
                            userAdd.Password = Password.Text;
                            UserDAL.AddNewUser(userAdd);
                            MessageBox.Show("Add Successful");
                            this.Close();
                        }
                        else MessageBox.Show("Please select a Role");
                    }
                    else { lblError.Content = "LoginID already Exists!"; InitializeComponent(); }
                }
                else { lblError.Content = "Date Of birth cannot be greater than present date"; InitializeComponent(); }
            }

            
             
        }

        private void DateOfBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void LoginID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Loaded(object sender, RoutedEventArgs e)
        {
            LoginID.Focus();
            Save_button.IsDefault = true;
        }
    }
}
