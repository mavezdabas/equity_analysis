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
using CommonContracts;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;
using MasterDataManagementUI.Validations;
using System.Collections.ObjectModel;


namespace MasterDataManagementUI.BusinessMapping
{
    /// <summary>
    /// Interaction logic for AddEntityMapping.xaml
    /// </summary>
    public partial class AddEntityMapping : Window
    {
        BusinessMappingPOCO businessEntity;
        BusinessUserHome home;
        IEntityMappingDAL mdmObject = null;

        ObservableCollection<string> entityNameList = new ObservableCollection<string>();
        ObservableCollection<string> commodityNameList = new ObservableCollection<string>();

        ObservableCollection<string> sourceNameList = new ObservableCollection<string>();

        List<string> isDefault = new List<string>() { "Yes", "No" };
        public AddEntityMapping(BusinessUserHome home)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AddEntityMapping_Loaded);
            this.home = home;
            CBoxDefault.ItemsSource = isDefault;
            CBoxDefault.Text = "No";
            startDate.Text = null;
        }

        void AddEntityMapping_Loaded(object sender, RoutedEventArgs e)
        {

            TBoxMappingString.Focus();
            businessEntity = new BusinessMappingPOCO();
            if (home.marketRadioButton.IsChecked == true)
            {
                businessEntity.EntityType = "Market";

                IEnumerable<MarketPOCO> list = new MarketDAO().GetAllMarkets();
                foreach (var item in list)
                {
                    entityNameList.Add(item.MarketName);
                }
                this.CBoxEntityName.DataContext = entityNameList;
                endDate.DisplayDateStart = DateTime.Now;

               
            }

            else if (home.commodityRadioButton.IsChecked == true)
            {
                businessEntity.EntityType = "Commodity";
                IEnumerable<CommodityTypePOCO> listCommodities = new CommodityTypeDAO().GetAllCommodityTypes();
                foreach (var item in listCommodities)
                {
                    commodityNameList.Add(item.CommodityTypeName);
                }
                this.CBoxEntityName.DataContext = commodityNameList;
              
            }

            IEnumerable<SourceSystemPOCO> sourceSystems = new SourceSystemDAL().GetAllSourceSystems();
            foreach (var item in sourceSystems)
            {
                sourceNameList.Add(item.SystemName);
            }

            TBoxSource.DataContext = sourceNameList;

            this.addGrid.DataContext = businessEntity;
        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {

                ////IMarketDAL marketDALObject = new MarketDAL();
                /////*
                //// * 
                //// * 
                //////Add code to get EntityID from EntityDAL and set it inside POCO
                //// * */
                ////businessEntity.EntityID = marketDALObject.GetMarketIdByName(businessEntity.EntityName);
                ////EntityMappingBusinessValidation validationObject = new EntityMappingBusinessValidation();
                ////string isDuplicateMapping = validationObject.CheckDuplicateMapping(businessEntity);
                ////if (isDuplicateMapping.Equals("No Mapping Exists"))
                ////{
                ////    if (validationObject.CheckDuplicateDefaultMapping(businessEntity) != null)
                ////    {
                //        mdmObject = new EntityMappingDAL();
                //        businessEntity.EntityID = GetEntityID(CBoxEntityName.SelectedItem as String);
                //        businessEntity.EntityName = CBoxEntityName.SelectedItem as String;
                //        businessEntity.IsDefaultMapping = CBoxDefault.SelectedItem as String;

                //        int sourceId = new SourceSystemDAL().GetSourceSystemID(TBoxSource.Text as String);
                //        businessEntity.SourceSystemID = sourceId;
                //        businessEntity.IsDefaultMapping = CBoxDefault.Text.ToString();
                //        mdmObject.Add(businessEntity);

                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("Default Mapping String Already Exists");
                //    //}
                ////}
                ////else
                ////{
                ////    MessageBox.Show("Mapping String Already Exists:Close original mapping by setting an appropriate end date that either predates the start of the new mapping by one second OR is identical to the start date of the original mapping where the start date of the new mapping predates it.");
                ////}



                EntityMappingBusinessValidation validationObject = new EntityMappingBusinessValidation();
                string errorMessage = validationObject.CheckEmptyFields(businessEntity);
                if (!String.IsNullOrEmpty(errorMessage))
                {
                    if (home.marketRadioButton.IsChecked == true)
                    {
                        //IMarketDAO marketDALObject = new MarketDAO();
                        //businessEntity.EntityID = marketDALObject.GetMarketIdByName(businessEntity.EntityName);
                        string market = CBoxEntityName.Text;
                        int entityId = new MarketDAO().GetMarketIdByName(market);
                        businessEntity.EntityID = entityId;
                        businessEntity.EntityName = market;
                        businessEntity.IsDefaultMapping = CBoxDefault.Text;

                    }
                    else if (home.commodityRadioButton.IsChecked == true)
                    {
                        //ICommodityTypeDAO commodityDAOObject = new CommodityTypeDAO();
                        //businessEntity.EntityID = commodityDAOObject.GetCommodityTypeIdByCommodityTypeName(businessEntity.EntityName);
                        string commodity = CBoxEntityName.Text;
                        int entityId = new CommodityTypeDAO().GetCommodityTypeIdByCommodityTypeName(commodity);
                        businessEntity.EntityID = entityId;
                        businessEntity.EntityName = commodity;
                        businessEntity.IsDefaultMapping = CBoxDefault.Text;
                    }

                    string isDuplicateMapping = validationObject.CheckDuplicateMapping(businessEntity);
                    if (isDuplicateMapping.Equals("No Mapping Exists"))
                    {
                        if (validationObject.CheckDuplicateDefaultMapping(businessEntity) != null && businessEntity.IsDefaultMapping == "No")
                        {
                            mdmObject = new EntityMappingDAL();

                            //businessEntity.EntityID = GetEntityID(CBoxEntityName.SelectedItem as String);
                            businessEntity.EntityName = CBoxEntityName.SelectedItem as String;

                            int sourceId = new SourceSystemDAL().GetSourceSystemID(TBoxSource.Text as String);
                            businessEntity.SourceSystemID = sourceId;
                            businessEntity.IsDefaultMapping = CBoxDefault.Text.ToString();
                            mdmObject.Add(businessEntity);

                        }
                        else
                            if (validationObject.CheckDuplicateDefaultMapping(businessEntity) == null)
                            {
                                mdmObject = new EntityMappingDAL();

                                //businessEntity.EntityID = GetEntityID(CBoxEntityName.SelectedItem as String);
                                businessEntity.EntityName = CBoxEntityName.SelectedItem as String;

                                int sourceId = new SourceSystemDAL().GetSourceSystemID(TBoxSource.Text as String);
                                businessEntity.SourceSystemID = sourceId;
                                businessEntity.IsDefaultMapping = CBoxDefault.Text.ToString();
                                mdmObject.Add(businessEntity);

                            }
                            else
                            {
                                MessageBox.Show("Default Mapping String Already Exists");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Mapping String Already Exists:Close original mapping by setting an appropriate end date that either predates the start of the new mapping by one second OR is identical to the start date of the original mapping where the start date of the new mapping predates it.");
                    }
                }
                else
                {

                    MessageBox.Show(errorMessage);


                }


                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Please Fill Required Fields");
            }
            }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void StartDate_SelectedDateChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            var startDatePicker = sender as DatePicker;
            DateTime? date = startDatePicker.SelectedDate;

           // startDate.Text = date.Value.ToShortDateString();
            startDate.Text = DateTime.Now.ToString();
        }

        private void EndDate_SelectedDateChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            var endDatePicker = sender as DatePicker;
            DateTime? date = endDatePicker.SelectedDate;
            if (endDate.SelectedDate < startDate.SelectedDate)
                MessageBox.Show("End Date Cannot be less than Start Date");
        }

        //private int GetEntityID(string entityName)
        //{
        //    ICommodityTypeDAO commodityDAOObject = new CommodityTypeDAO();
        //    int entityID = commodityDAOObject.GetCommodityTypeIdByCommodityTypeName(entityName);
        //    if (entityID != 0)
        //        return entityID;
        //    else
        //    {
        //        IMarketDAO marketDAOObject = new MarketDAO();
        //        int id = marketDAOObject.GetMarketIdByName(entityName);
        //        if (id != 0)
        //            return id;
        //    }
        //    return 0;
        //}
    }
}

