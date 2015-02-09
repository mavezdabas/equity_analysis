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
using MasterDataManagement.UIEntities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;
using CommonContracts;
using MasterDatamanagementUI.Converters;
using System.Collections.ObjectModel;
using MasterDatamangementUI.Converters;

namespace MasterDataManagementUI.Market
{
    /// <summary>
    /// Interaction logic for UpdateMarket.xaml
    /// </summary>
    public partial class UpdateMarket : Window
    {
        AdminUserHome adminUserHome = new AdminUserHome();
        BusinessUserHome businessUserHome = new BusinessUserHome();
        ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
        ILocationDAO locationDAO = new LocationDAO();
        ICurrencyDAO currencyDAO = new CurrencyDAO();
        ObservableCollection<string> commodityTypeNameList = new ObservableCollection<string>();
        ObservableCollection<string> locationNameList = new ObservableCollection<string>();
        ObservableCollection<string> cuurencyNameList = new ObservableCollection<string>();
        MarketUI marketUI;
        UpdateDataSource dataSource;
        public UpdateMarket(MarketUI marketUI)
        {
            InitializeComponent();
            this.marketUI = marketUI;
            //MessageBox.Show(marketUI.LocationName);
            dataSource = new UpdateDataSource(marketUI.MarketName);
            this.GridUpdateMarket.DataContext = marketUI;
            this.Loaded += new RoutedEventHandler(UpdateMarket_Loaded);
        }

        void UpdateMarket_Loaded(object sender, RoutedEventArgs e)
        {
           
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
            cmbLocation.Text = new LocationDAO().GetLocationNameById(marketUI.LocationId);
            cmbCurrency.Text = new CurrencyDAO().GetCurrencyNameById(marketUI.CurrencyId);

            datePicker1.SelectedDate = DateTime.Now;
            
            //throw new NotImplementedException();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {


            string exceptionString = "";
            try
            {
               //adminUserHome.LoadMarkets();
              
                ILocationDAO locationDAO = new LocationDAO();
                ICurrencyDAO currencyDAO = new CurrencyDAO();
                IMarketDAO marketDAO = new MarketDAO();
                String locationName = cmbLocation.Text;
                String currencyName = cmbCurrency.Text;


                ObservableCollection<string> commodityTypeNameList1 = dataSource.SelectedCommodityTypeNames;
                List<string> selectedCommodityTypeNames = new List<string>();
                foreach (var item in commodityTypeNameList1)
                {
                    selectedCommodityTypeNames.Add(item);

                }
                List<int> commodityIdList = commodityTypeDAO.GetCommodityIdList(selectedCommodityTypeNames);//remove cOMMENT
                //MarketCommodity

               
                if (string.IsNullOrEmpty(locationName))
                {
                    exceptionString += "Location Name cannot be left empty";
                }

                //if ( == null)
                //{
                //    exceptionString += "\nCommodity Type cannot be left empty";
                //}

                if (string.IsNullOrEmpty(currencyName))
                {
                    exceptionString += "\nCurrency Name cannot be left empty";
                    //throw new Exception();
                }

                if (selectedCommodityTypeNames.Count==0)
                {
                    exceptionString += "\nCommodity Type cannot be left empty";
                }

                //if (commodityType.StartDate == null)
                //{
                //    exceptionString += "\nStart Date cannot be empty";
                //    //throw new Exception();
                //}
                //if (commodityType.EndDate == null)
                //{
                //    exceptionString += "\nEnd Date cannot be left empty";
                //    //throw new Exception();
                //}
                if (datePicker1.SelectedDate.Value > datePicker2.SelectedDate.Value)
                {
                    exceptionString += "\nEnd Date has to be a future date";
                    //throw new Exception();
                }
                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);

                marketUI.LastUpdatedBy = UserSession.UserId;
                marketUI.LastUpdatedDate = DateTime.Now;
                marketUI.Version += 1;
               
                int locationId = locationDAO.GetLocationIdByName(locationName);
                int currencyId = currencyDAO.GetIdByName(currencyName);
                marketUI.LocationId = locationId;
                marketUI.CurrencyId = currencyId;

                MarketPOCO marketPOCO = MarketPOCOConverter.ConvertMarketUIToMarketPOCO(marketUI);
                int marketId = marketDAO.GetMarketIdByName(marketUI.MarketName);
                MarketCommodityMapDAO marketCommodityMapDAO = new MarketCommodityMapDAO();
                marketCommodityMapDAO.DeleteMarketCommodityMap(marketId);
                if (marketPOCO != null)
                {
                    string messageBoxText = "Are you sure you want to update the Market?";
                    string caption = "Alert";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {
                        marketDAO.UpdateMarket(marketPOCO);
                        MessageBox.Show("Market Updated Successfully!");
                    //    adminUserHome.BtnMarketUpdate.IsEnabled = false;
                     //   businessUserHome.BtnMarketUpdate.IsEnabled = false;

                        this.Close();
                    }

                    else
                    {
                        this.Close();
                    }

                   
                    List<MarketCommodityMapPOCO> marketCommodityMapPOCOList = new List<MarketCommodityMapPOCO>();
                    foreach (var commodityId in commodityIdList)
                    {
                        MarketCommodityMapUI marketCommodityMapUI = new MarketCommodityMapUI(marketId, commodityId);
                        MarketCommodityMapPOCO marketCommodityMapPOCO = MarketCommodityMapPOCOConverter.ConvertMarketCommodityMapUIToMarketCommodityMapPOCO(marketCommodityMapUI);
                        marketCommodityMapPOCOList.Add(marketCommodityMapPOCO);
                    }
                    marketCommodityMapDAO.CreateMarketCommodityMap(marketCommodityMapPOCOList);
                }
                else
                {
                    MessageBox.Show("Market could not be Updated!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Market cannot be updated!"+exceptionString);

            }

        }
    
        
    }
}
