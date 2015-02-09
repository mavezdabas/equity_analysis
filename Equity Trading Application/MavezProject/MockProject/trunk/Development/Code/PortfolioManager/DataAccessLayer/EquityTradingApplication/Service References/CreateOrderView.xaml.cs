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
    /// Interaction logic for CreateEquityOrder.xaml
    /// </summary>
    public partial class CreateOrderView : Window,IModelWindow
    {
        public CreateOrderView()
        {
            InitializeComponent();
            CreateOrderViewModel vm = new CreateOrderViewModel();

    vm.RequestCloseDialog += new EquityTradingApplication.Helpers.CustomEventHelper.RequestCloseEventHandler(vm_RequestCloseDialog);
            this.DataContext = vm;
           
        }

        void vm_RequestCloseDialog(EquityTradingApplication.Helpers.CustomEventHelper.RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }
    }
}
