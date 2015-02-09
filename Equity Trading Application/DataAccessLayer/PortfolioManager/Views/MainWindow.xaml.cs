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
using PortfolioManager.ViewModels;
using PortfolioManagerWindow.Helpers;

namespace PortfolioManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IModelWindow
    {
        MainWindowViewModel vModel;

        public MainWindow()
        {
            InitializeComponent();
            vModel= new MainWindowViewModel();
            this.DataContext = vModel;
           
        }

        private void dataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    if (dgr.IsMouseOver)
                    {
                        (dgr as DataGridRow).IsSelected = false;
                    }
                }
            } 
        }
    }
}
