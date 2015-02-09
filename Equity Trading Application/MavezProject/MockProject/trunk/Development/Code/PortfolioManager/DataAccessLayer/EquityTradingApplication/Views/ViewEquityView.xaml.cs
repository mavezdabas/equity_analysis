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
using DataAccessLayer;
using AutoMapper;
using EquityTradingApplication.ViewModels;
using EquityTradingApplication.Helpers;

namespace EquityTradingApplication.Views
{
    /// <summary>
    /// Interaction logic for ViewEquityOrder.xaml
    /// </summary>
    public partial class ViewEquityOrder : Window,IModelWindow
    {
        public ViewEquityOrder()
        {
            InitializeComponent();
            
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(ViewEquityOrder_DataContextChanged);
           
            ViewWindow.btnSaveOrder.Visibility = Visibility.Hidden;
            ViewWindow.btnCancelOrder.Visibility = Visibility.Hidden;

        }

        void ViewEquityOrder_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((ViewEquityOrderViewModel)DataContext).RequestCloseDialog += new CustomEventHelper.RequestCloseEventHandler(ViewEquityOrder_RequestCloseDialog);
        }

        void ViewEquityOrder_RequestCloseDialog(CustomEventHelper.RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }

     
    

      
    }
}
