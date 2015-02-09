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
    /// Interaction logic for CreateLocation.xaml
    /// </summary>
    public partial class CreateLocation : Window
    {
        LocationUI location;
        public CreateLocation()
        {
            InitializeComponent();
            location = new LocationUI();
            this.Loaded += new RoutedEventHandler(CreateLocation_Loaded);

        }

        void CreateLocation_Loaded(object sender, RoutedEventArgs e)
        {
            this.GridCreateLocation.DataContext = location;
            txtLocationName.Focus();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string exceptionString = "";
            try
            {


                if (string.IsNullOrEmpty(location.LocationName))
                {
                    exceptionString = "\nLocation  Name cannot be left empty";
                    //throw new  Exception();
                }
                //if (string.IsNullOrEmpty(location.Description))
                //{
                //    exceptionString += "\nLocation Description cannot be left empty";
                //    //throw new Exception();
                //}
                
                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);

                //String locationName = txtLocationName.Text;
                //String locationDescription = txtLocationDescription.Text;
                //LocationUI location = new LocationUI(locationName, locationDescription);
                //LocationPOCO locationPOCO = LocationPOCOConverter.ConvertLocationUIToLocationPOCO(location);
                ILocationDAO locationDAO = new LocationDAO();
                LocationPOCO locationPOCO = LocationPOCOConverter.ConvertLocationUIToLocationPOCO(location);

                string locationName = txtLocationName.Text;
                int locationId = locationDAO.GetLocationIdByName(locationName);
                if (locationPOCO != null)
                {
                    if (locationId != 0)
                    {
                        MessageBox.Show("Location Already Exists!");
                    }

                    else
                    {
                        string messageBoxText = "Are you sure you want to create the Location?";
                        string caption = "Alert";
                        MessageBoxButton button = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                        if (result == MessageBoxResult.Yes)
                        {
                            locationDAO.CreateLocation(locationPOCO);
                            MessageBox.Show("Location Created Successfully!");
                            this.Close();
                        }

                        else
                        {
                            this.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Location could not be Created!");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Location could not be Created!" + exceptionString);

            }
            //locationDAO.CreateLocation(locationPOCO);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




    }
}
