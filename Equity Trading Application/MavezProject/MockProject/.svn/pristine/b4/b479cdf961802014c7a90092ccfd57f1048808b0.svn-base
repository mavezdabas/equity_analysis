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
using EquityTradingApp.Helpers;
using EquityTradingApp.ViewModels;

namespace LoginWindowForEquityTradingSystem.Views
{
    /// <summary>
    /// Interaction logic for PasswordResetWindow.xaml
    /// </summary>
    public partial class PasswordResetWindow : Window, IModalWindow
    {
        public PasswordResetWindow()
        {
            InitializeComponent();
            PasswordResetWindowViewModel passViewModel = new PasswordResetWindowViewModel();
            passViewModel.RequestCloseDialog += new RequestCloseEventHandler(passViewModel_RequestCloseDialog);
            this.DataContext = passViewModel;
        }

        void passViewModel_RequestCloseDialog(RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }


    }
}
