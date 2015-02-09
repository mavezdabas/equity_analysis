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

namespace MasterDataManagementUI.BusinessMapping
{
    /// <summary>
    /// Interaction logic for DeleteEntityMapping.xaml
    /// </summary>
    public partial class DeleteEntityMapping : Window
    {
        BusinessMappingPOCO mappingToDelete;
        BusinessUserHome home;

        public DeleteEntityMapping(BusinessUserHome home)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DeleteEntityMapping_Loaded);
            this.home = home;
        }

        void DeleteEntityMapping_Loaded(object sender, RoutedEventArgs e)
        {

            TBoxMappingString.IsReadOnly = true;
            TBoxSource.IsReadOnly = true;
            TBoxDescription.IsReadOnly = true;
            StartDatePicker.AllowDrop = false;
            //StartDatePicker.IsReadOnly = true;
            EndDatePicker.AllowDrop = false;
            TBoxEntityName.IsReadOnly = true;
            //TBoxStartDate.IsReadOnly = true;
            TBoxDefault.IsReadOnly = true;
            mappingToDelete = (BusinessMappingPOCO)this.DataContext;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure ?",
  "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                IEntityMappingDAL MDMDALObject = new EntityMappingDAL();
                MDMDALObject.Delete(mappingToDelete.MappingID);
                MessageBox.Show("Mapping has been deleted");
                this.Close();
            }

            else
                this.Close();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartDate_SelectedDateChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndDate_SelectedDateChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
