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
using System.Collections.ObjectModel;
using MasterDataManagement.UIEntities;
using DataAccessLayer.DAL;
using MasterDataManagmentUI.Converters;
using MasterDataMangementUI.Converters;
using CommonContracts;
using MasterDatamangementUI.Converters;
using MasterDatamanagementUI.Converters;
using System.Collections;
using MasterDataManagementUI.UserManagement;

namespace MasterDataManagementUI
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class AdminUserHome : Window
    {
        
        ObservableCollection<MarketUI> MarketCollection = new ObservableCollection<MarketUI>();
        ObservableCollection<CommodityTypeUI> CommodityTypeCollection = new ObservableCollection<CommodityTypeUI>();
        ObservableCollection<LocationUI> LocationCollection = new ObservableCollection<LocationUI>();
        ObservableCollection<CurrencyUI> CurrencyCollection = new ObservableCollection<CurrencyUI>();
        ObservableCollection<BusinessMappingPOCO> EntityMappingCollection = new ObservableCollection<BusinessMappingPOCO>();
        ObservableCollection<UserPOCO> UserPocoCollection = new ObservableCollection<UserPOCO>();
        ObservableCollection<GenericSearchCriteria> GenericCollection;
        List<BusinessMappingPOCO> marketEntityMappingList;
        List<BusinessMappingPOCO> commodityEntityMappingList;

        state radioState;

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
        void LoadEntityMapping()
        {
            EntityMappingCollection.Clear();
            EntityMappingDAL entityMappingDAL = new EntityMappingDAL();
            EntityMappingCollection = new ObservableCollection<BusinessMappingPOCO>(entityMappingDAL.GetList());
        }
        void LoadCommodityTypes()
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
        public AdminUserHome()
        {
            InitializeComponent();
            LoadEntityMapping();
            LoadMarkets();
            LoadCurrencies();
            LoadLocation();
            allRadioButton.IsChecked = true;
            //MenuUpdateCommodityType.IsEnabled = false;
        }

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

                if (TabMarket.IsSelected)
                {
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
                    if (dgCommodity.SelectedItem != null)
                    {
                        BtnCommodityUpdate.IsEnabled = true;
                        BtnCommodityDelete.IsEnabled = true;
                       
                    }
                    else
                    {
                        BtnCommodityUpdate.IsEnabled = false;
                        BtnCommodityDelete.IsEnabled = false;
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
                    if (dgCurrency.SelectedItem != null)
                    {
                        BtnCurrencyUpdate.IsEnabled = true;
                        BtnCurrencyDelete.IsEnabled = true;
                    }
                    else
                    {
                        BtnCurrencyUpdate.IsEnabled = false;
                        BtnCurrencyDelete.IsEnabled = false;
                    }
               
                    CurrencyCollection.Clear();
                    LoadCurrencies();
                    if (dgCurrency.SelectedItem == null)
                    {
                        BtnCurrencyUpdate.IsEnabled = false;
                        BtnCurrencyDelete.IsEnabled = false;
                    }
                    dgCurrency.DataContext = CurrencyCollection;
                }
                else if (TabLocation.IsSelected)
                {
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
                    if (dgLocation.SelectedItem == null)
                    {
                        BtnLocationUpdate.IsEnabled = false;
                        BtnLocationDelete.IsEnabled = false;
                    }
                    dgLocation.DataContext = LocationCollection;
                }
                else if (TabEntityMapping.IsSelected)
                {

                    MakeTheSearchCriteriaListForEntityMapping();
                    EntityMappingCollection.Clear();
                    LoadEntityMapping();
                    dgEntityMapping.DataContext = EntityMappingCollection;
                }
                else if (TabUserManagement.IsSelected)
                {
                    if (dgUserManagement.SelectedItem == null)
                    {
                        BtnUserUpdate.IsEnabled = false;
                        BtnUserDelete.IsEnabled = false;
                    }
                    else
                    {
                        BtnUserUpdate.IsEnabled = true;
                        BtnUserDelete.IsEnabled = true;
                    }
                    UserPocoCollection.Clear();
                    LoadUserManagement();
                    dgUserManagement.DataContext = UserPocoCollection;
                }
            }
        }

        private void LoadUserManagement()
        {
            UserPocoCollection.Clear();
            var usersInUserTable = UserDAL.SearchUser("");
            foreach (var user in usersInUserTable)
            {
                UserPocoCollection.Add(user);
            }
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
            this.Title = "Welcome " + UserSession.Name + " (Administrator User)";
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
            UpdateMarket.ShowDialog();
            LoadMarkets();
            dgMarket.DataContext = MarketCollection;
        }

        private void BtnMarketDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteMarket DeleteMarket = new DeleteMarket(dgMarket.SelectedItem as MarketUI);
            DeleteMarket.ShowDialog();
            LoadMarkets();
            dgMarket.DataContext = MarketCollection;
        }

        private void BtnCommodityAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateCommodityType CreateCommodityType = new CreateCommodityType(this);
            CreateCommodityType.ShowDialog();
            LoadCommodityTypes();
            dgCommodity.DataContext = CommodityTypeCollection;
        }

        private void BtnCommodityUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateCommodityType UpdateCommodityType = new UpdateCommodityType(dgCommodity.SelectedItem as CommodityTypeUI);
            UpdateCommodityType.DataContext = dgCommodity.SelectedItem;
            UpdateCommodityType.ShowDialog();
        }

        private void BtnCommodityDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteCommodityType DeleteCommodityType = new DeleteCommodityType(dgCommodity.SelectedItem as CommodityTypeUI);
            DeleteCommodityType.ShowDialog();
            LoadCommodityTypes();
            dgCommodity.DataContext = CommodityTypeCollection;
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
        }

        private void BtnLocationDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteLocation DeleteLocation = new DeleteLocation(dgLocation.SelectedItem as LocationUI);
            DeleteLocation.ShowDialog();
            LoadLocation();
            dgLocation.DataContext = LocationCollection;
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
        }

        private void BtnCurrencyDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteCurrency DeleteCurrency = new DeleteCurrency(dgCurrency.SelectedItem as CurrencyUI);
            DeleteCurrency.ShowDialog();
            LoadCurrencies();
            dgCurrency.DataContext = CurrencyCollection;
        }

        private void BtnMappingAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMappingUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMappingDelete_Click(object sender, RoutedEventArgs e)
        {

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

        private void dgCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnCurrencyUpdate.IsEnabled = true;
            BtnCurrencyDelete.IsEnabled = true;
        }

        private void dgLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnLocationUpdate.IsEnabled = true;
            BtnLocationDelete.IsEnabled = true;
        }

        private void dgUserManagement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUserManagement.SelectedItem != null)
            {
                BtnUserUpdate.IsEnabled = true;
                BtnUserDelete.IsEnabled = true;

               
            }
        }

        private void BtnUserAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow AddUserWindow = new AddUserWindow();
            AddUserWindow.ShowDialog();
            LoadUserManagement();
            dgUserManagement.DataContext = UserPocoCollection;
            BtnUserUpdate.IsEnabled = false;
            BtnUserDelete.IsEnabled = false;

        }

        private void BtnUserUpdate_Click(object sender, RoutedEventArgs e)
        {
            object editUser = dgUserManagement.SelectedItem;
            try
            {
                UserPOCO newUserPoco = (UserPOCO)editUser;
                if (newUserPoco != null)
                {
                    EditWindowDetails newEditWindow = new EditWindowDetails();
                    newEditWindow.DataContext = dgUserManagement.SelectedItem;
                    newEditWindow.ShowDialog();
                    LoadUserManagement();
                    dgUserManagement.DataContext = UserPocoCollection;
                    BtnUserUpdate.IsEnabled = false;
                    BtnUserDelete.IsEnabled = false;
                }
                else MessageBox.Show("Please select a field from the results");
            }
            catch(InvalidCastException)
            {
                MessageBox.Show("Please select a relevant field");
            }
        }

        private void BtnUserDelete_Click(object sender, RoutedEventArgs e)
        {
            IList deleteUsers = dgUserManagement.SelectedItems;
            string messageBoxText = "Are you sure you want to delete the User(s)?";
            string caption = "Alert";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            if (result == MessageBoxResult.Yes)
            {
                foreach (var RowObject in deleteUsers)
                {

                    UserPOCO DeleteUserPoco = (UserPOCO)RowObject;
                    if (DeleteUserPoco != null)
                    {

                        UserDAL.DeleteUser(DeleteUserPoco);
                    }
                }
            }
                LoadUserManagement();
                dgUserManagement.DataContext = UserPocoCollection;
                BtnUserUpdate.IsEnabled = false;
                BtnUserDelete.IsEnabled = false;
          }

        private void BtnUserSearch_Click(object sender, RoutedEventArgs e)
        {
            String name = TxtUserSearch.Text;
            var gridData = UserDAL.SearchUser(name);
            if (gridData.Count == 0) MessageBox.Show("Your Search did not give any results.");
            else 
            { 
                dgUserManagement.DataContext = gridData;
                BtnUserUpdate.IsEnabled = true;
            }
        }

        private void Load_MyProfile(object sender, RoutedEventArgs e)
        {
            UserProfile newProfileWindow = new UserProfile();
            newProfileWindow.LoginID.Text = UserSession.LoginId;
            newProfileWindow.Username.Text = UserSession.Name;
            newProfileWindow.ShowDialog();
            LoadUserManagement();
            dgUserManagement.DataContext = UserPocoCollection;
            BtnUserUpdate.IsEnabled = false;
            BtnUserDelete.IsEnabled = false;

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

        private void dgSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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

            else if (entityType.Trim() == "Currency")
            {
                CurrencyPOCO currencyPOCO = new CurrencyDAO().GetCurrencyByName(name);
                UpdateCurrency updateWindow = new UpdateCurrency(CurrencyPOCOConverter.ConvertCurrencyPOCOToCurrencyUI(currencyPOCO));
                updateWindow.Show();
            }

            else if (entityType.Trim() == "Location")
            {
                LocationPOCO locationPOCO = new LocationDAO().GetLocationByName(name);
                UpdateLocation updateWindow = new UpdateLocation(LocationPOCOConverter.ConvertLocationPOCOToLocationUI(locationPOCO));
                updateWindow.Show();
            }
        }

        private void BtnMappingSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = autoTxtMappingSearch.Text.ToString();
            var filteredEntityMappings = from entityMapping in EntityMappingCollection
                                         where entityMapping.MappingString.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase) || entityMapping.EntityName.StartsWith(searchText, System.StringComparison.OrdinalIgnoreCase)
                                         select entityMapping;
            dgEntityMapping.DataContext = new ObservableCollection<BusinessMappingPOCO>(filteredEntityMappings.ToList());
        }

        private void commodityRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            radioState = state.Commodity;
            DisplayGridAccToRadioButton();

        }

        private void marketRadioButton_Checked(object sender, RoutedEventArgs e)
        {

            radioState = state.Market;
            DisplayGridAccToRadioButton();
        }

        private void allRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dgEntityMapping.DataContext = EntityMappingCollection;
        }


    }
}
