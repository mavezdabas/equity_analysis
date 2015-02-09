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

namespace EquityTradingApplication.View
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPasswordView :Window,IModelWindow
    {
        ForgotPasswordViewModel vModel;

        public ForgotPasswordView()
        {
            InitializeComponent();
            //vModel = new ForgotPasswordViewModel(null);
            this.DataContext = vModel;
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(ForgotPasswordView_DataContextChanged);
          
        }

        void ForgotPasswordView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            vModel = (ForgotPasswordViewModel)this.DataContext;
            vModel.RequestCloseDialog += new CustomEventHelper.RequestCloseEventHandler(vModel_RequestCloseDialog);
        }

        void vModel_RequestCloseDialog(CustomEventHelper.RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }

       

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
            var x = Validation.GetErrors(pBox);

        }

    }
}
