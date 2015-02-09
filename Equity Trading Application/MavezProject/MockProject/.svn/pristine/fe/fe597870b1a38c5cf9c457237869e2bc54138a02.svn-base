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
using ExecutionTraderMainWindow.Helpers;
using ExecutionTraderMainWindow.ViewModel;

namespace ExecutionTraderMainWindow.Views
{
    /// <summary>
    /// Interaction logic for AddOrdersToBlockWindow.xaml
    /// </summary>
    public partial class AddOrdersToBlockWindow : Window,IModalWindow
    {

        public AddOrdersToBlockWindow()
        {
            InitializeComponent();
           this.DataContextChanged += new DependencyPropertyChangedEventHandler(AddOrdersToBlockWindow_DataContextChanged);
        }

        void AddOrdersToBlockWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((AddOrdersToBlockViewModel)DataContext).RequestCloseDialog += new RequestCloseEventHandler(AddOrdersToBlockWindow_RequestCloseDialog);
        }

        void AddOrdersToBlockWindow_RequestCloseDialog(RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }
    }
}
