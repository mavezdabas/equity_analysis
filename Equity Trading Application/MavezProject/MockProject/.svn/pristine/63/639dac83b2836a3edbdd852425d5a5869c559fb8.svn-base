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
using DataAccessLayer.DAL;
using DataAccessLayer.Interfaces;
using System.Collections.ObjectModel;
using MasterDataManagementUI.Validations;


namespace MasterDataManagementUI.BusinessMapping
{
    /// <summary>
    /// Interaction logic for EditEntityMapping.xaml
    /// </summary>
    public partial class EditEntityMapping : Window
    {
        BusinessMappingPOCO mappingToEdit;
        BusinessUserHome home;
        ObservableCollection<string> entityNameList = new ObservableCollection<string>();
        ObservableCollection<string> commodityNameList = new ObservableCollection<string>();
        ObservableCollection<string> sourceNameList = new ObservableCollection<string>();
        
        List<string> isDefault = new List<string>() { "Yes", "No" };
        public EditEntityMapping(BusinessUserHome home)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(EditEntityMapping_Loaded);
            this.home = home;
            CBoxDefault.ItemsSource = isDefault;
        }

        void EditEntityMapping_Loaded(object sender, RoutedEventArgs e)
        {
            mappingToEdit = (BusinessMappingPOCO)this.DataContext;

            if (home.marketRadioButton.IsChecked == true)
            {
                mappingToEdit.EntityType = home.marketRadioButton.Content.ToString();
                IEnumerable<MarketPOCO> list = new MarketDAO().GetAllMarkets();
                foreach (var item in list)
                {
                    entityNameList.Add(item.MarketName);
                }
               // this.CBoxEntityName.DataContext = entityNameList;
            }

            else if (home.commodityRadioButton.IsChecked == true)
            {
                mappingToEdit.EntityType = home.commodityRadioButton.Content.ToString();
                IEnumerable<CommodityTypePOCO> listCommodities = new CommodityTypeDAO().GetAllCommodityTypes();
                foreach (var item in listCommodities)
                {
                    commodityNameList.Add(item.CommodityTypeName);
                }
               // this.CBoxEntityName.DataContext = commodityNameList;
            }
            //this.DataContext = mappingToEdit;

            IEnumerable<SourceSystemPOCO> sourceSystems = new SourceSystemDAL().GetAllSourceSystems();
            foreach (var item in sourceSystems)
            {
                sourceNameList.Add(item.SystemName);
            }

            TBoxSource.DataContext = sourceNameList;

            TBoxSource.Text = mappingToEdit.SourceSystemName;
            CBoxDefault.Text = mappingToEdit.IsDefaultMapping;
            this.DataContext = mappingToEdit;
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

            IEntityMappingDAL MDMDALObject = new EntityMappingDAL();
            mappingToEdit.IsDefaultMapping = CBoxDefault.Text.ToString();
            //MDMDALObject.Edit(mappingToEdit);
            

            if (home.marketRadioButton.IsChecked == true)
            {
                IMarketDAO marketDALObject = new MarketDAO();
                mappingToEdit.EntityID = marketDALObject.GetMarketIdByName(mappingToEdit.EntityName);
            }
            else if (home.commodityRadioButton.IsChecked == true)
            {
                ICommodityTypeDAO commodityDAOObject = new CommodityTypeDAO();
                mappingToEdit.EntityID = commodityDAOObject.GetCommodityTypeIdByCommodityTypeName(mappingToEdit.EntityName);
            }
            EntityMappingBusinessValidation validationObject = new EntityMappingBusinessValidation();
            //if (validationObject.CheckDuplicateDefaultMapping(mappingToEdit) != null)
            //{
                
            //    mappingToEdit.IsDefaultMapping = CBoxDefault.Text.ToString();
            //    MDMDALObject.Edit(mappingToEdit);
            //    MessageBox.Show("Edit Successfull");
            //}
            //else
            //{
            //    MessageBox.Show("Default Mapping String Already Exists");
            //}
            if (validationObject.CheckDuplicateDefaultMapping(mappingToEdit) != null && mappingToEdit.IsDefaultMapping == "No")
            {
                MDMDALObject = new EntityMappingDAL();

                //businessEntity.EntityID = GetEntityID(CBoxEntityName.SelectedItem as String);
                //mappingToEdit.EntityName = CBoxEntityName.SelectedItem as String;

                int sourceId = new SourceSystemDAL().GetSourceSystemID(TBoxSource.Text as String);
                mappingToEdit.SourceSystemID = sourceId;
                mappingToEdit.IsDefaultMapping = CBoxDefault.Text.ToString();
                MDMDALObject.Edit(mappingToEdit);
                MessageBox.Show("Mapping has been edited");
            }
            else
                if (validationObject.CheckDuplicateDefaultMapping(mappingToEdit) == null)
                {
                    MDMDALObject = new EntityMappingDAL();

                    //businessEntity.EntityID = GetEntityID(CBoxEntityName.SelectedItem as String);
                    //mappingToEdit.EntityName = CBoxEntityName.SelectedItem as String;

                    int sourceId = new SourceSystemDAL().GetSourceSystemID(TBoxSource.Text as String);
                    mappingToEdit.SourceSystemID = sourceId;
                    mappingToEdit.IsDefaultMapping = CBoxDefault.Text.ToString();
                    MDMDALObject.Edit(mappingToEdit);
                    MessageBox.Show("Mapping has been edited");
                }
                else
                {
                    MessageBox.Show("Default Mapping String Already Exists");
                }

            this.Close();
        }

        private void StartDate_SelectedDateChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndDate_SelectedDateChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            if (endDate.SelectedDate < startDate.SelectedDate)
            {
                MessageBox.Show("End Date Cannot be less than Start Date");
                endDate.SelectedDate = DateTime.Now;
            }
        }
    }
}
