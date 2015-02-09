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
using DataAccessLayer;
using System.Collections.ObjectModel;
using CommonContracts;
using MasterDatamanagementUI.Converters;
using MasterDatamangementUI.Converters;

namespace MasterDataManagementUI.Market
{
    /// <summary>
    /// Interaction logic for CreateMarket.xaml
    /// </summary>
    public partial class CreateMarket : Window
    {
        // MarketUI market;
        ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
        ILocationDAO locationDAO = new LocationDAO();
        ICurrencyDAO currencyDAO = new CurrencyDAO();
        DataSource dataSource = new DataSource();
        public CreateMarket()
        {
            InitializeComponent();
            // market = new MarketUI();

            //this.DataContext = dataSource;
            this.Loaded += new RoutedEventHandler(CreateMarket_Loaded);
            cmbCommodityType.DataContext = dataSource;

        }


        ObservableCollection<string> commodityTypeNameList = new ObservableCollection<string>();
        ObservableCollection<string> locationNameList = new ObservableCollection<string>();
        ObservableCollection<string> cuurencyNameList = new ObservableCollection<string>();

        void CreateMarket_Loaded(object sender, RoutedEventArgs e)
        {
            // this.GridCreateMarket.DataContext = market;
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
            dpStartDate.SelectedDate = DateTime.Now;
            //cmbCommodityType.DataContext = commodityTypeNameList;
            cmbLocation.DataContext = locationNameList;
            cmbCurrency.DataContext = cuurencyNameList;
            txtMarketName.Focus();
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

              




                IMarketDAO marketDAO = new MarketDAO();
                IMarketCommodityMapDAO marketCommodityMapDAO = new MarketCommodityMapDAO();
                string location = "";
                if(cmbLocation.SelectedItem!=null)
                location = cmbLocation.SelectedItem.ToString();
               
                //MarketDAO marketDao = new MarketDAO();
                //aakanksha c
                //string commodityType = cmbCommodityType.SelectedItem.ToString(); //1
                //List<string> commodityTypeNameList1 = new List<string>();
                //commodityTypeNameList1.Add(commodityType);
                //aakanksha cends
                ObservableCollection<string> commodityTypeNameList1 = dataSource.SelectedCommodityTypeNames;
                List<string> selectedCommodityTypeNames = new List<string>();
                foreach (var item in commodityTypeNameList1)
                {
                    selectedCommodityTypeNames.Add(item);

                }
                ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();


                List<int> commodityIdList = commodityTypeDAO.GetCommodityIdList(selectedCommodityTypeNames);//remove cOMMENT
                //MarketCommodity
                List<MarketCommodityMapPOCO> marketCommodityMapPOCOList = new List<MarketCommodityMapPOCO>();
                string marketName = txtMarketName.Text;
                string currency="";
                if(cmbCurrency.SelectedItem!=null)
                 currency = cmbCurrency.SelectedItem.ToString();
                
                DateTime startDate = dpStartDate.SelectedDate.Value;
                DateTime? endDate=null;
                if(dpEndDate.SelectedDate!=null)
                 endDate = dpEndDate.SelectedDate.Value;


                if (string.IsNullOrEmpty(marketName))
                {
                    exceptionString += "\nMarket Name cannot be left empty";
                    //throw new  Exception();
                }
                if(string.IsNullOrEmpty(location))
                {
                    exceptionString += "\nLocation Name cannot be left empty";
                }

                if (selectedCommodityTypeNames.Count==0)
                {
                    exceptionString += "\nCommodity Type cannot be left empty";
                }
                
                if (string.IsNullOrEmpty(currency))
                {
                    exceptionString += "\nCurrency Name cannot be left empty";
                    //throw new Exception();
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
                if (startDate > endDate)
                {
                    exceptionString += "\nEnd Date has to be a future date";
                    //throw new Exception();
                }
                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);

                int locationId = locationDAO.GetLocationIdByName(location);
                int currencyId = currencyDAO.GetIdByName(currency);

                MarketUI marketUI = new MarketUI(marketName, locationId, currencyId, startDate, endDate); //here
                MarketPOCO marketPOCO = MarketPOCOConverter.ConvertMarketUIToMarketPOCO(marketUI);

                string messageBoxText = "Are you sure you want to create the Market?";
                string caption = "Alert";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;



                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                if (result == MessageBoxResult.Yes)
                {
                 
                    int marketId = marketDAO.GetMarketIdByName(marketName);
                    if (marketId == 0)
                    {
                        marketDAO.CreateMarket(marketPOCO);
                        marketId = marketDAO.GetMarketIdByName(marketName);
                        foreach (var commodityId in commodityIdList)
                        {
                            MarketCommodityMapUI marketCommodityMapUI = new MarketCommodityMapUI(marketId, commodityId);
                            MarketCommodityMapPOCO marketCommodityMapPOCO = MarketCommodityMapPOCOConverter.ConvertMarketCommodityMapUIToMarketCommodityMapPOCO(marketCommodityMapUI);
                            marketCommodityMapPOCOList.Add(marketCommodityMapPOCO);
                        }
                        marketCommodityMapDAO.CreateMarketCommodityMap(marketCommodityMapPOCOList);
                        MessageBox.Show("Market created Successfully!");
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Market already exists!!");
                    }
                }

                else
                {
                  //  this.Close();
                }

            }
            catch (Exception ex)
            {

            //  MessageBox.Show("Market cannot be created!");
                MessageBox.Show("Market cannot be created!"+exceptionString);
            }

      
        }
    }
}
