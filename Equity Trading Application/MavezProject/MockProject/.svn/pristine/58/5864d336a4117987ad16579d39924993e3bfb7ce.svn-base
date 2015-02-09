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
using CommonContracts;
using MasterDataManagmentUI.Converters;
using MasterDataManagement.UIEntities;

namespace MasterDataManagementUI.CommodityType
{
    /// <summary>
    /// Interaction logic for DeleteCommodityType.xaml
    /// </summary>
    public partial class DeleteCommodityType : Window
    {
        CommodityTypeUI commodityType;
        public DeleteCommodityType(CommodityTypeUI commodityTypeUI)
        {
            InitializeComponent();
            this.commodityType = commodityTypeUI;
            this.Loaded += new RoutedEventHandler(DeleteCommodityType_Loaded);
            
        }

        void DeleteCommodityType_Loaded(object sender, RoutedEventArgs e)
        {
            Save.Focus();
            this.GridDeleteCommodity.DataContext = commodityType;       
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
                CommodityTypePOCO commodityTypePOCO = CommodityTypePOCOConverter.ConvertCommodityTypeUIToCommodityTypePOCO(commodityType);
                if (commodityTypePOCO != null)
                {

                    string messageBoxText = "Are you sure you want to delete the Commodity?";
                    string caption = "Alert";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {
                        commodityTypeDAO.DeleteCommodityType(commodityTypePOCO);
                        MessageBox.Show("Commodity Type Deleted Successfully!");

                        this.Close();
                    }

                    else
                    {
                      
                    }
                   
                }
                else
                {
                    MessageBox.Show("CommodityType cannot be Deleted!");
                    this.Close();
                }
            }
            catch (Exception)
            {
                 MessageBox.Show("CommodityType cannot be Deleted. Commodity Type is already being used in Market!");
                    this.Close();
               
            }
        }

       
    }
}
