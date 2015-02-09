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


namespace EquityTradingApp.Views
{
    /// <summary>
    /// Interaction logic for ResetWindowPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window, IModalWindow
    {
        public ResetPassword()
        {
            InitializeComponent();
              InitializeComponent();
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(UpdateWindow_DataContextChanged);
        }

        void UpdateWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((ResetPasswordViewModel)DataContext).RequestCloseDialog += new RequestCloseEventHandler(resetViewModel_RequestCloseDialog);
        }

        void resetViewModel_RequestCloseDialog(RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }
    }
}
