using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CommonContracts;
using DataAccessLayer.DAL;
using DataAccessLayer.DBML;
using MasterDataManagement.UIEntities;
using MasterDataManagementUI.BusinessMapping;
using MasterDataManagementUI.CommodityType;
using MasterDataManagementUI.Currency;
using MasterDataManagementUI.Location;
using MasterDataManagementUI.Market;
using MasterDataManagmentUI.Converters;
using MasterDataMangementUI.Converters;
using MasterDatamangementUI.Converters;
using MasterDatamanagementUI.Converters;
using MasterDataManagementUI.UserManagement;
using DataAccessLayer.Converters;

namespace MasterDataManagementUI
{
    enum state { Market, Commodity }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class BusinessUserHome : Window
    {
        ObservableCollection<MarketUI> MarketCollection = new ObservableCollection<MarketUI>();
        ObservableCollection<CommodityTypeUI> CommodityTypeCollection = new ObservableCollection<CommodityTypeUI>();
        ObservableCollection<LocationUI> LocationCollection = new ObservableCollection<LocationUI>();
        ObservableCollection<CurrencyUI> CurrencyCollection = new ObservableCollection<CurrencyUI>();
        ObservableCollection<BusinessMappingPOCO> EntityMappingCollection = new ObservableCollection<BusinessMappingPOCO>();
        ObservableCollection<GenericSearchCriteria> GenericCollection;
        List<BusinessMappingPOCO> marketEntityMappingList;
        List<BusinessMappingPOCO> commodityEntityMappingList;

        state radioState;

        public void DisplayGridAccToRadioButton()
        {
            switch (radioState)
            {
                case state.Market:

                    IEnumerable<MarketPOCO> listOfMarkets = new MarketDAO().GetAllMarkets();
                    marketEntityMappingList = new List<BusinessMappingPOCO>();

                    foreach (var market in listOfMarkets)
                    {
                        foreach (var item in EntityMappingCollection)
                        {
                            if (market.MarketName == item.EntityName)
                                marketEntityMappingList.Add(item);
                        }
                    }
                    dgEntityMapping.DataContext = marketEntityMappingList;
                    break;

                case state.Commodity:
                    IEnumerable<CommodityTypePOCO> listOfCommodities = new CommodityTypeDAO().GetAllCommodityTypes();
                    commodityEntityMappingList = new List<BusinessMappingPOCO>();

                    foreach (var commodity in listOfCommodities)
                    {
                        foreach (var item in EntityMappingCollection)
                        {
                            if (commodity.CommodityTypeName == item.EntityName)
                                commodityEntityMappingList.Add(item);
                        }


                    }


                    dgEntityMapping.DataContext = commodityEntityMappingList;
                    break;

                default:
                    break;

            }
        }

        void LoadMarkets()
        {
            MarketCollection.Clear();
            MarketDAO MarketDAO = new MarketDAO();
            LocationDAO locationDAO = new LocationDAO();
            CurrencyDAO currencyDAO = new CurrencyDAO();
            var locations = locationDAO.GetAllLocations();
            var MarketPOCOList = MarketDAO.GetAllMarkets();
            var MarketUIList = MarketPOCOConverter.ConvertMarketPOCOListToMarketUIList(MarketPOCOList);

            foreach (var Market in MarketUIList)
            {
                Market.LocationName = locationDAO.GetLocationNameById(Market.LocationId);
                Market.Currency = currencyDAO.GetCurrencyNameById(Market.CurrencyId);
                Market.CommodityNames = MarketDAO.GetAllCommodityTypeNames(Market.MarketName);
                MarketCollection.Add(Market);

            }
        }

        public void LoadEntityMapping()
        {
            EntityMappingCollection.Clear();
            EntityMappingDAL entityMappingDAL = new EntityMappingDAL();
            foreach (var entityMapping in entityMappingDAL.GetList())
            {
                EntityMappingCollection.Add(entityMapping);
            }

        }

        public void LoadCommodityTypes()
        {
            CommodityTypeCollection.Clear();
            CommodityTypeDAO CommodityTypeDAO = new CommodityTypeDAO();
            var CommodityTypePOCOList = CommodityTypeDAO.GetAllCommodityTypes();
            var CommodityTypeUIList = CommodityTypePOCOConverter.ConvertCommodityTypePOCOListToCommodityTypePOCO(CommodityTypePOCOList);
            foreach (var CommodityType in CommodityTypeUIList)
            {
                CommodityTypeCollection.Add(CommodityType);
            }
        }

        public BusinessUserHome()
        {
            InitializeComponent();

            LoadEntityMapping();
            LoadMarkets();
            LoadCurrencies();
            LoadLocation();
            // BtnMappingAdd.IsEnabled = false;
            //MenuUpdateCommodityType.IsEnabled = false;
            allRadioButton.IsChecked = true;
        }

        private void MakeTheSearchCriteriaListForEntityMapping()
        {

            autoTxtMappingSearch.Text = "";
            List<string> listOfMappingCriteria = new List<string>();
            IEnumerable<MarketPOCO> listOfMarkets = new MarketDAO().GetAllMarkets();

            foreach (var item in listOfMarkets)
            {
                listOfMappingCriteria.Add(item.MarketName);
            }
            IEnumerable<CommodityTypePOCO> listOfCommodities = new CommodityTypeDAO().GetAllCommodityTypes();

            foreach (var item in listOfCommodities)
            {
                listOfMappingCriteria.Add(item.CommodityTypeName);
            }
            IEnumerable<BusinessMappingPOCO> listOfMappings = new EntityMappingDAL().GetList();

            foreach (var item in listOfMappings)
            {
                listOfMappingCriteria.Add(item.MappingString);
            }

            autoTxtMappingSearch.ItemsSource = listOfMappingCriteria;
        }

        private void MakeTheSearchCriteriaListForCurrency()
        {
            autoTxtCurrencySearch.Text = "";
            List<string> listOfMappingCriteria = new List<string>();
            IEnumerable<CurrencyPOCO> listOfCurrencies = new CurrencyDAO().GetAllCurrencies();

            foreach (var item in listOfCurrencies)
            {
                listOfMappingCriteria.Add(item.CurrencyName);
            }
            autoTxtCurrencySearch.ItemsSource = listOfMappingCriteria;
        }

        private void MakeTheSearchCriteriaListForMarket()
        {
            autoTxtMarketSearch.Text = "";
            List<string> listOfMappingCriteria = new List<string>();
            IEnumerable<MarketPOCO> listOfMarkets = new MarketDAO().GetAllMarkets();

            foreach (var item in listOfMarkets)
            {
                listOfMappingCriteria.Add(item.MarketName);
            }
            autoTxtMarketSearch.ItemsSource = listOfMappingCriteria;
        }

        private void MakeTheSearchCriteriaListForCommodity()
        {
            autoTxtCommoditySearch.Text = "";
            List<string> listOfMappingCriteria = new List<string>();
            IEnumerable<CommodityTypePOCO> listOfCommodities = new CommodityTypeDAO().GetAllCommodityTypes();

            foreach (var item in listOfCommodities)
            {
                listOfMappingCriteria.Add(item.CommodityTypeName);
                listOfMappingCriteria.Add(item.CommodityClass);
            }
            autoTxtCommoditySearch.ItemsSource = listOfMappingCriteria;
        }

        private void MakeTheSearchCriteriaListForLocation()
        {
            autoTxtLocationSearch.Text = "";
            List<string> listOfMappingCriteria = new List<string>();
            IEnumerable<LocationPOCO> listOfLocations = new LocationDAO().GetAllLocations(); ;

            foreach (var item in listOfLocations)
            {
                listOfMappingCriteria.Add(item.LocationName);
            }
            autoTxtLocationSearch.ItemsSource = listOfMappingCriteria;
        }

        private void MakeTheSearchCriteriaListForGeneric()
        {
            autoTxtGenericSearch.Text = "";
            List<string> listOfMappingCriteria = new List<string>();
            IEnumerable<MarketPOCO> listOfMarkets = new MarketDAO().GetAllMarkets();

            foreach (var item in listOfMarkets)
            {
                listOfMappingCriteria.Add(item.MarketName);
            }
            IEnumerable<BusinessMappingPOCO> listOfMappings = new EntityMappingDAL().GetList();

            foreach (var item in listOfMappings)
            {
                listOfMappingCriteria.Add(item.MappingString);
            }
            IEnumerable<CommodityTypePOCO> listOfCommodities = new CommodityTypeDAO().GetAllCommodityTypes();

            foreach (var item in listOfCommodities)
            {
                listOfMappingCriteria.Add(item.CommodityTypeName);
            }
            IEnumerable<LocationPOCO> listOfLocations = new LocationDAO().GetAllLocations(); ;

            foreach (var item in listOfLocations)
            {
                listOfMappingCriteria.Add(item.LocationName);
            }
            IEnumerable<CurrencyPOCO> listOfCurrencies = new CurrencyDAO().GetAllCurrencies();

            foreach (var item in listOfCurrencies)
            {
                listOfMappingCriteria.Add(item.CurrencyName);
            }

            autoTxtGenericSearch.ItemsSource = listOfMappingCriteria;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                // ... Get TabControl reference.
                var item = sender as TabControl;
                // ... Set Title to selected tab header.
                //var selected = item.SelectedItem as TabItem;
                //this.Title = selected.Header.ToString();

                if (TabSearch.IsSelected)
                {
                    MakeTheSearchCriteriaListForGeneric();

                    dgSearch.DataContext = GenericCollection;
                }

                else if (TabMarket.IsSelected)
                {
                    MakeTheSearchCriteriaListForMarket();

                    if (dgMarket.SelectedItem == null)
                    {
                        BtnMarketUpdate.IsEnabled = false;
                        BtnMarketDelete.IsEnabled = false;
                    }
                    else
                    {
                        BtnMarketUpdate.IsEnabled = true;
                        BtnMarketDelete.IsEnabled = true;
                    }
                    MarketCollection.Clear();
                    LoadMarkets();
                    if (dgMarket.SelectedItem == null)
                    {
                        BtnMarketUpdate.IsEnabled = false;
                        BtnMarketDelete.IsEnabled = false;
                    }
                    dgMarket.DataContext = MarketCollection;
                }
                else if (TabCommodity.IsSelected)
                {
                    MakeTheSearchCriteriaListForCommodity();

                    if (dgCommodity.SelectedItem == null)
                    {
                        BtnCommodityUpdate.IsEnabled = false;
                        BtnCommodityDelete.IsEnabled = false;
                    }
                    else
                    {
                        BtnCommodityUpdate.IsEnabled = true;
                        BtnCommodityDelete.IsEnabled = true;
                    }
                    CommodityTypeCollection.Clear();
                    LoadCommodityTypes();
                    if (dgCommodity.SelectedItem == null)
                    {
                        BtnCommodityUpdate.IsEnabled = false;
                        BtnCommodityDelete.IsEnabled = false;
                    }
                    dgCommodity.DataContext = CommodityTypeCollection;
                }
                else if (TabCurrency.IsSelected)
                {
                    MakeTheSearchCriteriaListForCurrency();

                    if (dgCurrency.SelectedItem == null)
                    {
                        BtnCurrencyUpdate.IsEnabled = false;
                        BtnCurrencyDelete.IsEnabled = false;
                    }
                    else
                    {
                        BtnCurrencyUpdate.IsEnabled = true;
                        BtnCurrencyDelete.IsEnabled = true;
                    }
                    CurrencyCollection.Clear();
                    LoadCurrencies();
                    dgCurrency.DataContext = CurrencyCollection;
                }
                else if (TabLocation.IsSelected)
                {
                    MakeTheSearchCriteriaListForLocation();

                    if (dgLocation.SelectedItem == null)
                    {
                        BtnLocationUpdate.IsEnabled = false;
                        BtnLocationDelete.IsEnabled = false;
                    }
                    else
                    {
                        BtnLocationUpdate.IsEnabled = true;
                        BtnLocationDelete.IsEnabled = true;
                    }
                    LocationCollection.Clear();
                    LoadLocation();
                    dgLocation.DataContext = LocationCollection;
                }
                else if (TabEntityMapping.IsSelected)
                {
                    MakeTheSearchCriteriaListForEntityMapping();

                    if (dgEntityMapping.SelectedItem == null)
                    {
                        BtnMappingUpdate.IsEnabled = false;
                        BtnMappingDelete.IsEnabled = false;
                    }
                    else
                    {
                        BtnMappingUpdate.IsEnabled = true;
                        BtnMappingDelete.IsEnabled = true;
                    }
                    LoadEntityMapping();
                    dgEntityMapping.DataContext = EntityMappingCollection;
                }
            }
        }

        private void LoadCurrencies()
        {
            CurrencyCollection.Clear();
            CurrencyDAO CurrencyDAO = new CurrencyDAO();
            var CurrencyPOCOList = CurrencyDAO.GetAllCurrencies();
            var CurrencyUIList = CurrencyPOCOConverter.ConvertCurrencyPOCOListToCurrencyUIList(CurrencyPOCOList);
            foreach (var Currency in CurrencyUIList)
            {
                CurrencyCollection.Add(Currency);
            }
        }

        private void LoadLocation()
        {
            LocationCollection.Clear();
            LocationDAO LocationDAO = new LocationDAO();
            var LocationPOCOList = LocationDAO.GetAllLocations();
            var LocationUIList = LocationPOCOConverter.ConvertLocationPOCOListToLocationListUI(LocationPOCOList);
            foreach (var Location in LocationUIList)
            {
                LocationCollection.Add(Location);
            }
        }

        private void dgCommodityType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MenuUpdateCommodityType.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Welcome " + UserSession.Name + " (Business User)";
            
        }

        private void BtnMarketAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateMarket CreateMarket = new CreateMarket();
            CreateMarket.ShowDialog();
            LoadMarkets();
            dgMarket.DataContext = MarketCollection;
        }

        private void BtnMarketUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            UpdateMarket UpdateMarket = new UpdateMarket(dgMarket.SelectedItem as MarketUI);
            //UpdateMarket.cmbLocation.Text = ((MarketUI)dgMarket.SelectedItem).LocationName;
            UpdateMarket.ShowDialog();
            LoadMarkets();
            dgMarket.DataContext = MarketCollection;
            BtnMarketUpdate.IsEnabled = false;
        }

        private void BtnMarketDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteMarket DeleteMarket = new DeleteMarket(dgMarket.SelectedItem as MarketUI);
            DeleteMarket.ShowDialog();
            LoadMarkets();
            dgMarket.DataContext = MarketCollection;
            BtnMarketDelete.IsEnabled = false;
        }

        private void BtnCommodityAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateCommodityType CreateCommodityType = new CreateCommodityType();
            CreateCommodityType.ShowDialog();
            LoadCommodityTypes();
            dgCommodity.DataContext = CommodityTypeCollection;

        }

        private void BtnCommodityUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateCommodityType UpdateCommodityType = new UpdateCommodityType(dgCommodity.SelectedItem as CommodityTypeUI);
            UpdateCommodityType.DataContext = dgCommodity.SelectedItem;
            UpdateCommodityType.ShowDialog();
            BtnCommodityUpdate.IsEnabled = false;
        }

        private void BtnCommodityDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteCommodityType DeleteCommodityType = new DeleteCommodityType(dgCommodity.SelectedItem as CommodityTypeUI);
            DeleteCommodityType.ShowDialog();
            BtnCommodityDelete.IsEnabled = false;

        }

        private void BtnLocationAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateLocation CreateLocation = new CreateLocation();
            CreateLocation.ShowDialog();
            LoadLocation();
            dgLocation.DataContext = LocationCollection;
        }

        private void BtnLocationUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateLocation UpdateLocation = new UpdateLocation(dgLocation.SelectedItem as LocationUI);
            UpdateLocation.DataContext = dgLocation.SelectedItem;
            UpdateLocation.ShowDialog();
            LoadLocation();
            dgLocation.DataContext = LocationCollection;
            BtnLocationUpdate.IsEnabled = false;
        }

        private void BtnLocationDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteLocation DeleteLocation = new DeleteLocation(dgLocation.SelectedItem as LocationUI);
            DeleteLocation.ShowDialog();
            BtnLocationDelete.IsEnabled = false;
        }

        private void BtnCurrencyAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateCurrency CreateCurrency = new CreateCurrency();
            CreateCurrency.ShowDialog();
            LoadCurrencies();
            dgCurrency.DataContext = CurrencyCollection;
        }

        private void BtnCurrencyUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrency UpdateCurrency = new UpdateCurrency(dgCurrency.SelectedItem as CurrencyUI);
            UpdateCurrency.DataContext = dgCurrency.SelectedItem;
            UpdateCurrency.ShowDialog();
            BtnCurrencyUpdate.IsEnabled = false;
            // if(UpdateCurrency.ShowDialog()==false)
            // BtnCurrencyUpdate.IsEnabled = false;
        }

        private void BtnCurrencyDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteCurrency DeleteCurrency = new DeleteCurrency(dgCurrency.SelectedItem as CurrencyUI);
            DeleteCurrency.ShowDialog();
            LoadCurrencies();
            dgCurrency.DataContext = CurrencyCollection;
            BtnCurrencyDelete.IsEnabled = false;
        }

        private void BtnMappingAdd_Click(object sender, RoutedEventArgs e)
        {
            if (marketRadioButton.IsChecked == true || commodityRadioButton.IsChecked == true)
            {
                AddEntityMapping addEntity = new AddEntityMapping(this);
                addEntity.ShowDialog();
                LoadEntityMapping();
                DisplayGridAccToRadioButton();

                if (marketRadioButton.IsChecked == true)
                {
                    dgEntityMapping.DataContext = marketEntityMappingList;
                }
                else if (commodityRadioButton.IsChecked == true)
                {
                    dgEntityMapping.DataContext = commodityEntityMappingList;
                }
                else
                    dgEntityMapping.DataContext = EntityMappingCollection;
            }
            else
                MessageBox.Show("Please select the entity type (Commodity/Market)");
        }

        private void BtnMappingUpdate_Click(object sender, RoutedEventArgs e)
        {

            EditEntityMapping editEntity = new EditEntityMapping(this);
            editEntity.DataContext = dgEntityMapping.SelectedItem;
            editEntity.ShowDialog();
            int id = ((BusinessMappingPOCO)dgEntityMapping.SelectedItem).SourceSystemID;
            string name = new SourceSystemDAL().GetSourceSystemName(id);
            ((BusinessMappingPOCO)dgEntityMapping.SelectedItem).SourceSystemName = name;
            LoadEntityMapping();
            DisplayGridAccToRadioButton();

            if (marketRadioButton.IsChecked == true)
            {
                dgEntityMapping.DataContext = marketEntityMappingList;
            }
            else if (commodityRadioButton.IsChecked == true)
            {
                dgEntityMapping.DataContext = commodityEntityMappingList;
            }
            else
                dgEntityMapping.DataContext = EntityMappingCollection;

            BtnMappingUpdate.IsEnabled = false;
            BtnMappingDelete.IsEnabled = false;

        }

        private void BtnMappingDelete_Click(object sender, RoutedEventArgs e)
        {

            DeleteEntityMapping deleteEntity = new DeleteEntityMapping(this);
            int id = ((BusinessMappingPOCO)dgEntityMapping.SelectedItem).SourceSystemID;
            string name = new SourceSystemDAL().GetSourceSystemName(id);
            ((BusinessMappingPOCO)dgEntityMapping.SelectedItem).SourceSystemName = name;
            deleteEntity.DataContext = dgEntityMapping.SelectedItem;
            deleteEntity.ShowDialog();
            LoadEntityMapping();
            DisplayGridAccToRadioButton();

            if (marketRadioButton.IsChecked == true)
            {
                dgEntityMapping.DataContext = marketEntityMappingList;
            }
            else if (commodityRadioButton.IsChecked == true)
            {
                dgEntityMapping.DataContext = commodityEntityMappingList;
            }
            else
                dgEntityMapping.DataContext = EntityMappingCollection;

            BtnMappingUpdate.IsEnabled = false;
            BtnMappingDelete.IsEnabled = false;


        }

        private void dgMarket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnMarketUpdate.IsEnabled = true;
            BtnMarketDelete.IsEnabled = true;
        }

        private void dgCommodity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnCommodityUpdate.IsEnabled = true;
            BtnCommodityDelete.IsEnabled = true;
        }

        private void dgEntityMapping_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void commodityRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<CommodityTypePOCO> list = new ObservableCollection<CommodityTypePOCO>();
            //MDMDataContext context = new MDMDataContext();
            //IEnumerable<CommodityTypePOCO> results = from commodity in context.CommodityTypes
            //                                         select commodity;

            //dgEntityMapping.DataContext= results.ToList();

            radioState = state.Commodity;
            DisplayGridAccToRadioButton();


        }

        private void marketRadioButton_Checked(object sender, RoutedEventArgs e)
        {

            radioState = state.Market;
            DisplayGridAccToRadioButton();
        }

        //SEARCH...
        private void BtnMappingSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = autoTxtMappingSearch.Text.ToString();
            var filteredEntityMappings = from entityMapping in EntityMappingCollection
                                         where entityMapping.MappingString.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase) || entityMapping.EntityName.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase)
                                         select entityMapping;
            dgEntityMapping.DataContext = new ObservableCollection<BusinessMappingPOCO>(filteredEntityMappings.ToList());
        }

        private void BtnCurrencySearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = autoTxtCurrencySearch.Text;
            var filteredCurrencies = from currency in CurrencyCollection
                                     where currency.CurrencyName.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase)
                                     select currency;
            dgCurrency.DataContext = new ObservableCollection<CurrencyUI>(filteredCurrencies.ToList());
        }

        private void BtnLocationSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = autoTxtLocationSearch.Text;
            var filteredLocations = from location in LocationCollection
                                    where location.LocationName.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase)
                                    select location;
            dgLocation.DataContext = new ObservableCollection<LocationUI>(filteredLocations.ToList());
        }

        private void BtnCommoditySearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = autoTxtCommoditySearch.Text;
            var filteredCommodities = from commodity in CommodityTypeCollection
                                      where commodity.CommodityTypeName.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase) || commodity.CommodityClass.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase)
                                      select commodity;
            dgCommodity.DataContext = new ObservableCollection<CommodityTypeUI>(filteredCommodities.ToList());
        }

        private void BtnMarketSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = autoTxtMarketSearch.Text;
            var filteredMarkets = from market in MarketCollection
                                  where market.MarketName.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase)
                                  select market;
            dgMarket.DataContext = new ObservableCollection<MarketUI>(filteredMarkets.ToList());
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            GenericCollection = new ObservableCollection<GenericSearchCriteria>();
            string textToSearch = autoTxtGenericSearch.Text;
            var entityIds = from mappin in EntityMappingCollection
                            where mappin.MappingString.StartsWith(textToSearch, System.StringComparison.OrdinalIgnoreCase)
                            select new { ID = mappin.EntityID, Type = mappin.EntityType };

            foreach (var item in entityIds)
            {
                GenericSearchCriteria temp = GetEntityName(item.ID, item.Type);
                if (temp != null)
                    GenericCollection.Add(temp);
            }

            var filteredMarkets = from market in MarketCollection
                                  where market.MarketName.StartsWith(textToSearch, System.StringComparison.OrdinalIgnoreCase)
                                  select new GenericSearchCriteria { Name = market.MarketName, EntityType = "Market" };
            var filteredCommodities = from commodity in CommodityTypeCollection
                                      where commodity.CommodityTypeName.StartsWith(textToSearch, System.StringComparison.OrdinalIgnoreCase) || commodity.CommodityClass.StartsWith(textToSearch, System.StringComparison.OrdinalIgnoreCase)
                                      select new GenericSearchCriteria { Name = commodity.CommodityTypeName, EntityType = "Commodity" };
            var filteredLocations = from location in LocationCollection
                                    where location.LocationName.StartsWith(textToSearch, System.StringComparison.OrdinalIgnoreCase)
                                    select new GenericSearchCriteria { Name = location.LocationName, EntityType = "Location" };
            var filteredCurrencies = from currency in CurrencyCollection
                                     where currency.CurrencyName.StartsWith(textToSearch, System.StringComparison.OrdinalIgnoreCase)
                                     select new GenericSearchCriteria { Name = currency.CurrencyName, EntityType = "Currency" };

            foreach (var item in filteredMarkets)
            {
                GenericCollection.Add(item);
            }
            foreach (var item in filteredCommodities)
            {
                GenericCollection.Add(item);
            }
            foreach (var item in filteredLocations)
            {
                GenericCollection.Add(item);
            }
            foreach (var item in filteredCurrencies)
            {
                GenericCollection.Add(item);
            }

            dgSearch.DataContext = GenericCollection;

        }

        private GenericSearchCriteria GetEntityName(int entityId, string entityType)
        {
            string name = "";
            if (entityType.Trim().Equals("Commodity"))
            {
                name = new CommodityTypeDAO().GetCommodityTypeNameByCommodityTypeId(entityId);
            }
            else
            {
                name = new MarketDAO().GetMarketNameById(entityId);
            }
            return new GenericSearchCriteria() { Name = name, EntityType = entityType };
        }

        private void dgEntityMapping_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            BtnMappingUpdate.IsEnabled = true;
            BtnMappingDelete.IsEnabled = true;
        }

        private void Load_MyProfile(object sender, RoutedEventArgs e)
        {
            UserProfile newProfileWindow = new UserProfile();
            newProfileWindow.LoginID.Text = UserSession.LoginId;
            newProfileWindow.Username.Text = UserSession.Name;
            newProfileWindow.ShowDialog();

        }
        //Method invoked on the double click of a row of the generic search
        private void dgSearch_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string entityType = ((GenericSearchCriteria)dgSearch.SelectedItem).EntityType;
            string name = ((GenericSearchCriteria)dgSearch.SelectedItem).Name;
            if (entityType.Trim() == "Market")
            {
                int id = new MarketDAO().GetMarketIdByName(name);
                MarketPOCO marketPOCO = new MarketDAO().GetMarketPOCOById(id);
                UpdateMarket updateWindow = new UpdateMarket(MarketPOCOConverter.ConvertMarketPOCOToMarketUI(marketPOCO));

                updateWindow.Show();
            }
            else if (entityType.Trim() == "Commodity")
            {
                CommodityTypePOCO commodityPOCO = new CommodityTypeDAO().GetCommodityTypeByName(name);
                UpdateCommodityType updateWindow = new UpdateCommodityType(CommodityTypePOCOConverter.ConvertCommodityTypePOCOToCommodityTypeUI(commodityPOCO));
                
                updateWindow.Show();
            }

            //else if (entityType.Trim() == "Currency")
            //{
            //    CurrencyPOCO currencyPOCO = new CurrencyDAO().GetCurrencyByName(name);
            //    UpdateCurrency updateWindow = new UpdateCurrency(CurrencyPOCOConverter.ConvertCurrencyPOCOToCurrencyUI(currencyPOCO));
            //    updateWindow.Show();
            //}

            //else if (entityType.Trim() == "Location")
            //{
            //    LocationPOCO locationPOCO = new LocationDAO().GetLocationByName(name);
            //    UpdateLocation updateWindow = new UpdateLocation(LocationPOCOConverter.ConvertLocationPOCOToLocationUI(locationPOCO));
            //    updateWindow.Show();
            //}
        }

        private void allRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dgEntityMapping.DataContext = EntityMappingCollection;
        }

    }
}
