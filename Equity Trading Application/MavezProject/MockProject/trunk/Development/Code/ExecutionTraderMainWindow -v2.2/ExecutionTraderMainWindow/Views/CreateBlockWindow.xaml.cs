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
using System.Collections.ObjectModel;
using ExecutionTraderMainWindow.ViewModel;

namespace ExecutionTraderMainWindow.Views
{
    /// <summary>
    /// Interaction logic for CreateBlockWindow.xaml
    /// </summary>
    public partial class CreateBlockWindow : Window,IModalWindow
    {
        public CreateBlockWindow()
        {
            InitializeComponent();
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(CreateBlockWindow_DataContextChanged);

        }
       

        void CreateBlockWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((CreateBlockWindowViewModel)DataContext).RequestCloseDialog += new RequestCloseEventHandler(CreateBlockWindow_RequestCloseDialog);
        }

        void CreateBlockWindow_RequestCloseDialog(RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }
    }
}
