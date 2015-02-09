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
using MasterDataManagementUI.Market;
using MasterDataManagementUI.CommodityType;
using MasterDataManagementUI.Location;
using MasterDataManagementUI.Currency;

namespace MasterDataManagementUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
       public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get TabControl reference.
            var item = sender as TabControl;
            // ... Set Title to selected tab header.
            var selected = item.SelectedItem as TabItem;
            this.Title = selected.Header.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateMarket CreateMarket = new CreateMarket();
            CreateMarket.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateMarket UpdateMarket = new UpdateMarket();
            UpdateMarket.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteMarket DeleteMarket = new DeleteMarket();
            DeleteMarket.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            CreateCommodityType CreateCommodityType = new CreateCommodityType();
            CreateCommodityType.ShowDialog();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            UpdateCommodityType UpdateCommodityType = new UpdateCommodityType();
            UpdateCommodityType.ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            DeleteCommodityType DeleteCommodityType = new DeleteCommodityType();
            DeleteCommodityType.ShowDialog();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            CreateLocation CreateLocation = new CreateLocation();
            CreateLocation.ShowDialog();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            UpdateLocation UpdateLocation = new UpdateLocation();
            UpdateLocation.ShowDialog();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            DeleteLocation DeleteLocation = new DeleteLocation();
            DeleteLocation.ShowDialog();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            CreateCurrency CreateCurrency = new CreateCurrency();
            CreateCurrency.ShowDialog();
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            UpdateCurrency UpdateCurrency = new UpdateCurrency();
            UpdateCurrency.ShowDialog();
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            DeleteCurrency DeleteCurrency = new DeleteCurrency();
            DeleteCurrency.ShowDialog();
        } 
    }
}
