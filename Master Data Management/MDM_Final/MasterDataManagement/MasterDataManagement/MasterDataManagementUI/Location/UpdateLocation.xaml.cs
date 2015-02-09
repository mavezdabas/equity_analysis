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
    /// Interaction logic for UpdateLocation.xaml
    /// </summary>
    public partial class UpdateLocation : Window
    {
        LocationUI Location;
        public UpdateLocation(LocationUI LocationUI)
        {
            InitializeComponent();
            this.Location = LocationUI;
            this.Loaded += new RoutedEventHandler(UpdateLocation_Loaded);
        }

        void UpdateLocation_Loaded(object sender, RoutedEventArgs e)
        {
            this.GridUpdateLocation.DataContext = Location;
            txtLocationName.Focus();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            String exceptionString = "";
            try
            {

                if (string.IsNullOrEmpty(Location.LocationName))
                {
                    exceptionString = "\nLocation  Name cannot be left empty";
                    //throw new  Exception();
                }
                //if (string.IsNullOrEmpty(Location.Description))
                //{
                //    exceptionString += "\nLocation Description cannot be left empty";
                //    //throw new Exception();
                //}

                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);

                Location.LastUpdatedBy = UserSession.UserId;
                Location.LastUpdatedDate = DateTime.Now;

                ILocationDAO locationDAO = new LocationDAO();
                LocationPOCO locationPOCO = LocationPOCOConverter.ConvertLocationUIToLocationPOCO(Location);
                if (locationPOCO != null)
                {
                    string messageBoxText = "Are you sure you want to update the Location?";
                    string caption = "Alert";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {
                        locationDAO.UpdateLocation(locationPOCO);
                        MessageBox.Show("Location Updated Successfully!");
                        this.Close();
                    }

                    else
                    {
                        this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Location could not be Updated!");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Location could not be Updated!"+exceptionString);
                
            }
               
          }
           
        }
    }

