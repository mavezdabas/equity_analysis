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
using EquityTradingApp.Helpers;
using EquityTradingApp.ViewModels;

namespace EquityTradingApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IModalWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginWindowViewModel loginViewModel = new LoginWindowViewModel();
            this.DataContext = loginViewModel;
            loginViewModel.RequestCloseDialog += new RequestCloseEventHandler(loginViewModel_RequestCloseDialog);
         
        }

        void loginViewModel_RequestCloseDialog(RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }
    }
}
