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
using MasterDataManagmentUI.Converters;

namespace MasterDataManagementUI.CommodityType
{
    /// <summary>
    /// Interaction logic for UpdateCommodityType.xaml
    /// </summary>
    public partial class UpdateCommodityType : Window
    {

        CommodityTypeUI commodityType;

        public UpdateCommodityType(CommodityTypeUI commodityType)
        {
            InitializeComponent();
            this.commodityType = commodityType;
            this.Loaded += new RoutedEventHandler(UpdateCommodityType_Loaded);
        }

        void UpdateCommodityType_Loaded(object sender, RoutedEventArgs e)
        {
            Txt_CreateCommodityTypeName.Focus();
            datePicker1.SelectedDate = DateTime.Now;
            this.GridUpdateCommodity.DataContext = commodityType;        
        }
     

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            commodityType.StartDate = datePicker1.SelectedDate.Value;
            string exceptionString = "";
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
                if (commodityType.StartDate == null)
                {
                    exceptionString += "\nStart Date cannot be empty";
                    //throw new Exception();
                }
                if (commodityType.StartDate == null)
                {
                    exceptionString += "\nStart Date cannot be null";
                    //throw new Exception();
                }
                //if (commodityType.EndDate == null)
                //{
                //    exceptionString += "\nEnd Date cannot be null";
                //    //throw new Exception();
                //}
                //if (commodityType.StartDate > commodityType.EndDate)
                //{
                //    exceptionString += "\nStart Date cannot be greater than end date";
                //    //throw new Exception();
                //}
                if(commodityType.EndDate<DateTime.Now)
                {
                    exceptionString += "\nEnd Date has to be a future Date";
                    //throw new Exception();
                }

                commodityType.LastUpdatedBy = UserSession.UserId;
               
                commodityType.LastUpdatedDate = DateTime.Now;
                commodityType.IsCurrentVersion = true;
                commodityType.Version += 1;
                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);
              

                ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
                CommodityTypePOCO commodityTypePOCO = CommodityTypePOCOConverter.ConvertCommodityTypeUIToCommodityTypePOCO(commodityType);
                if (commodityTypePOCO != null)
                {
                    commodityTypeDAO.UpdateCommodityType(commodityTypePOCO);
                    MessageBox.Show("CommodityType Updated Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("CommodityType cannot be Updated");
                    //this.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("CommodityType cannot be Updated" + exceptionString);
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
