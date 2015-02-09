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
using EquityTradingApplication.Helpers;
using EquityTradingApplication.ViewModels;
using System.Threading;

namespace EquityTradingApplication.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window,IModelWindow
    {
        LoginViewModel login;
        public Login()
        {
            Thread.Sleep(2000);
            InitializeComponent();
            login = new LoginViewModel();
            
            login.RequestCloseDialog += new Action(login_RequestCloseDialog);
            this.DataContext = login;
          // login.Password = pBox.Password;
            
        }

        void login_RequestCloseDialog()
        {
            this.Visibility = Visibility.Hidden;
           // login.Password = pBox.Password;
        }



        //public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    TextBox tb = (TextBox)sender;
        //    tb.Text = string.Empty;
        //    tb.GotFocus -= TextBox_GotFocus;
        //}
    }
}
