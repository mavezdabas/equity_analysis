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

namespace EquityTradingApplication.Views
{
    /// <summary>
    /// Interaction logic for SymbolListView.xaml
    /// </summary>
    public partial class SymbolListView : Window,IModelWindow
    {
        public SymbolListView()
        {
            InitializeComponent();
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(SymbolListView_DataContextChanged);
            //vm.RequestCloseDialog += new EquityTradingApplication.Helpers.CustomEventHelper.RequestCloseEventHandler(vm_RequestCloseDialog);
            

        }

        void SymbolListView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((SymbolViewModel)DataContext).RequestCloseDialog += new CustomEventHelper.RequestCloseEventHandler(SymbolListView_RequestCloseDialog);
            //throw new NotImplementedException();
        }

        void SymbolListView_RequestCloseDialog(CustomEventHelper.RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }

       
    }
}

