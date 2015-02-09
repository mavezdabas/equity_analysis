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
using CommonContracts;
using MasterDataMangementUI.Converters;
using DataAccessLayer.DAL;
using DataAccessLayer.Interfaces;

namespace MasterDataManagementUI.Location
{
    /// <summary>
    /// Interaction logic for DeleteLocation.xaml
    /// </summary>
    public partial class DeleteLocation : Window
    {
        LocationUI Location;
        public DeleteLocation(LocationUI Location)
        {
            InitializeComponent();
            this.Location = Location;
            this.Loaded += new RoutedEventHandler(DeleteLocation_Loaded);
        }

        void DeleteLocation_Loaded(object sender, RoutedEventArgs e)
        {
            this.GridDeleteLocation.DataContext = Location;
            Delete.Focus();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ILocationDAO locationDAO = new LocationDAO();
                LocationPOCO locationPOCO = LocationPOCOConverter.ConvertLocationUIToLocationPOCO(Location);
                if (locationPOCO != null)
                {

                    string messageBoxText = "Are you sure you want to delete the Location?";
                    string caption = "Alert";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {

                        locationDAO.DeleteLocation(locationPOCO);
                        MessageBox.Show("Location Deleted Successfully!");
                        this.Close();
                    }

                    else
                    {
                  
                    }

                }
                else
                {
                    MessageBox.Show("Location cannot be Deleted!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Location cannot be Deleted. Location already being used in Market!");
                
            }
        }

    }
}
