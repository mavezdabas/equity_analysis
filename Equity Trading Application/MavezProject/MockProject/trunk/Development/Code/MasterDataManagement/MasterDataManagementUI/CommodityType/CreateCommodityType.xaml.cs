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
using CommonContracts;
using MasterDataManagmentUI.Converters;
using DataAccessLayer.DAL;

namespace MasterDataManagementUI.CommodityType
{
    /// <summary>
    /// Interaction logic for CreateCommodityType.xaml
    /// </summary>
    public partial class CreateCommodityType : Window
    {
        CommodityTypeUI commodityType;

        public CreateCommodityType()
        {
            InitializeComponent();
            commodityType = new CommodityTypeUI();
            this.Loaded += new RoutedEventHandler(CreateCommodityType_Loaded);
        }

        public CreateCommodityType(AdminUserHome home)
        {
            InitializeComponent();
            commodityType = new CommodityTypeUI();
            this.Loaded += new RoutedEventHandler(CreateCommodityType_Loaded);
        }

        void CreateCommodityType_Loaded(object sender, RoutedEventArgs e)
        {
            txtCreateCommodityTypeName.Focus();
            dpStartDate.SelectedDate = DateTime.Now;
            this.GridCreateCommodity.DataContext = commodityType;
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            string exceptionString = "";
           // ICommodityTypeDAO commodityTypeDao = new CommodityTypeDAO();
           commodityType.StartDate = dpStartDate.SelectedDate.Value;
               try
               {
                   if (string.IsNullOrEmpty(commodityType.CommodityTypeName))
                   {
                       exceptionString = "Commodity Type Name cannot be left empty";
                       //throw new  Exception();
                   }
                   if (string.IsNullOrEmpty(commodityType.CommodityClass))
                   {
                       exceptionString += "\nCommodity Class Name cannot be left empty";
                       //throw new Exception();
                   }
                  
                   if (commodityType.StartDate==null)
                   {
                       exceptionString += "\nStart Date cannot be empty";
                       //throw new Exception();
                   }
                   //if (commodityType.EndDate == null)
                   //{
                   //    exceptionString += "\nEnd Date cannot be left empty";
                   //    //throw new Exception();
                   //}
                   if (commodityType.StartDate>commodityType.EndDate)
                   {
                       exceptionString += "\nEnd Date has to be a future date";
                       //throw new Exception();
                   }
                   if (!string.IsNullOrEmpty(exceptionString))
                       throw new Exception(exceptionString);
              
              
            ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
            CommodityTypePOCO commodityTypePOCO = CommodityTypePOCOConverter.ConvertCommodityTypeUIToCommodityTypePOCO(commodityType);

            string commodityTypeName = txtCreateCommodityTypeName.Text;
            int commodityTypeId = commodityTypeDAO.GetCommodityTypeIdByCommodityTypeName(commodityTypeName);
            if (commodityTypePOCO != null)
            {
                if (commodityTypeId != 0)
                {
                    MessageBox.Show("Commodity already exists!");
                }
                else
                {
                    commodityTypeDAO.CreateCommodityType(commodityTypePOCO);
                    MessageBox.Show("CommodityType Created");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Commodity Type not created");
                this.Close();
            }
               }
               catch (Exception ex)
               {
                  // MessageBox.Show("Commodity Type Name Cannot be left empty");
                   MessageBox.Show("Commodity Type cannot be created!"+exceptionString);
               }

           
        }
    }
}
