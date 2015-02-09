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
using Login.ViewModels;
using Login.Helpers;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vModel = new MainWindowViewModel();
            this.DataContext = vModel;
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(MainWindow_DataContextChanged);
        }

        void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).RequestCloseDialog += new CustomEventHelper.RequestCloseEventHandler(MainWindow_RequestCloseDialog);
        }

        void MainWindow_RequestCloseDialog(CustomEventHelper.RequestCloseEventArgs e)
        {
            this.DialogResult = e.DialogResult;
        }

    

     
        


      
    }
}
