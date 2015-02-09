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
using System.Collections.ObjectModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;

namespace MasterDataManagementUI.BusinessMapping
{
    /// <summary>
    /// Interaction logic for EntityMappingHome.xaml
    /// </summary>
    public partial class EntityMappingHome : Window
    {
        ObservableCollection<BusinessMappingPOCO> data = new ObservableCollection<BusinessMappingPOCO>();

        public EntityMappingHome()
        {
            InitializeComponent();
            IEntityMappingDAL MDMDALObject = new EntityMappingDAL();
            foreach (var item in MDMDALObject.GetList())
            {
                data.Add(item);
            }
            this.editButton.IsEnabled = false;
            this.deleteButton.IsEnabled = false;
            this.addButton.IsEnabled = false;
        }

        private void commodityCheckBoxEventHandler(object sender, RoutedEventArgs e)
        {
            if (commodityRadioButton.IsChecked == true)
            {
                datagrid.DataContext = data;
                datagrid.IsReadOnly = true;
                this.addButton.IsEnabled = true;
            }
        }

        private void marketCheckBoxEventHandler(object sender, RoutedEventArgs e)
        {
            if (marketRadioButton.IsChecked == true)
            {
                datagrid.DataContext = data;
                datagrid.IsReadOnly = true;
                this.addButton.IsEnabled = true;
            }
        }

        private void searchButtonClickEventHandler(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxAutoEventHandler(object sender, TextCompositionEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
          //  AddEntityMapping addWindow = new AddEntityMapping(this);
            //addWindow.ShowDialog();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //EditEntityMapping editWindow = new EditEntityMapping(this);
            //editWindow.DataContext = this.datagrid.SelectedValue;
            //editWindow.ShowDialog();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //DeleteEntityMapping deleteWindow = new DeleteEntityMapping(this);
            //deleteWindow.DataContext = this.datagrid.SelectedValue;
            //deleteWindow.ShowDialog();
        }

        internal void RefreshGrid()
        {
            data.Clear();
            IEntityMappingDAL MDMDALObject = new EntityMappingDAL();
            foreach (var item in MDMDALObject.GetList())
            {
                data.Add(item);
            }
            this.datagrid.DataContext = data;
            this.editButton.IsEnabled = false;
            this.deleteButton.IsEnabled = false;
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.editButton.IsEnabled = true;
            this.deleteButton.IsEnabled = true;
        }
    }
}
