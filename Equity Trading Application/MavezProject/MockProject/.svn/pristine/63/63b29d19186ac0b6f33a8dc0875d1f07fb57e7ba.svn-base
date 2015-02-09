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
using DataAccessLayer.DAL;
using DataAccessLayer.Interfaces;
using MasterDataManagement.UIEntities;
using CommonContracts;
using MasterDatamangementUI.Converters;
using System.Collections.ObjectModel;

namespace MasterDataManagementUI.Market
{
    /// <summary>
    /// Interaction logic for DeleteMarket.xaml
    /// </summary>
    /// 

    public partial class DeleteMarket : Window
    {
        ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
        ILocationDAO locationDAO = new LocationDAO();
        ICurrencyDAO currencyDAO = new CurrencyDAO();
        ObservableCollection<string> commodityTypeNameList = new ObservableCollection<string>();
        ObservableCollection<string> locationNameList = new ObservableCollection<string>();
        ObservableCollection<string> cuurencyNameList = new ObservableCollection<string>();
        UpdateDataSource dataSource;

        MarketUI MarketUI;
        public DeleteMarket(MarketUI MarketUI)
        {
            InitializeComponent();
            this.MarketUI = MarketUI;
            dataSource = new UpdateDataSource(MarketUI.MarketName);
            this.GridDeleteMarket.DataContext = MarketUI;
            this.Loaded += new RoutedEventHandler(DeleteMarket_Loaded);
          //  cmbLocation.Text = "aakanksha";
        }

        void DeleteMarket_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbLocation.Text = "aakanksha";
            Delete.Focus();
           
            var commodityTypePOCOList = commodityTypeDAO.GetAllCommodityTypes();
            foreach (var item in commodityTypePOCOList)
            {
                commodityTypeNameList.Add(item.CommodityTypeName);
            }
            var locationPOCOList = locationDAO.GetAllLocations();
            foreach (var item in locationPOCOList)
            {
                locationNameList.Add(item.LocationName);
            }
            var currencyPOCOList = currencyDAO.GetAllCurrencies();
            foreach (var item in currencyPOCOList)
            {
                cuurencyNameList.Add(item.CurrencyName);
            }
            cmbLocation.DataContext = locationNameList;
            cmbCurrency.DataContext = cuurencyNameList;
            cmbCommodityType.DataContext = dataSource;
            //cmbLocation.Text = "aakanksha";
            cmbLocation.Text = MarketUI.LocationName;
            cmbCurrency.Text = MarketUI.Currency;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbLocation.Text = "aakanksha";
                ICurrencyDAO currencyDAO = new CurrencyDAO();
                ILocationDAO locationDAO = new LocationDAO();
                ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
                IMarketDAO marketDAO = new MarketDAO();
                string marketName = txtMarketName.Text;
                //string locationName = cmbLocation.SelectedItem.ToString();
                //string commodityType = cmbCommodityType.SelectedItem.ToString();
                //string currencyName = cmbCurrency.SelectedItem.ToString();
                //int currencyId = currencyDAO.GetIdByName(currencyName);
                //int locationId = locationDAO.GetLocationIdByName(locationName);
                //int commodityTypeId = commodityTypeDAO.GetCommodityTypeIdByCommodityTypeName(commodityType);
                int marketId = marketDAO.GetMarketIdByName(marketName);
                //MarketCommodityMapUI marketCommodityMapUI = new MarketCommodityMapUI(marketId, commodityTypeId);
                //MarketCommodityMapPOCO marketCommodityMapPOCO = MarketCommodityMapPOCOConverter.ConvertMarketCommodityMapUIToMarketCommodityMapPOCO(marketCommodityMapUI);
                MarketCommodityMapDAO marketCommodityMapDAO = new MarketCommodityMapDAO();
                marketCommodityMapDAO.DeleteMarketCommodityMap(marketId);
                MarketPOCO marketToBeDeleted = marketDAO.GetMarketByName(marketName);

                string messageBoxText = "Are you sure you want to delete the Market?";
                string caption = "Alert";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                if (result == MessageBoxResult.Yes)
                {
                    marketDAO.DeleteMarket(marketToBeDeleted);
                    MessageBox.Show("Market deleted Successfully!");
                    this.Close();


                }

                else
                {
                    this.Close();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Market cannot be deleted!");
            }
          

        }

       
    }
}
