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
using MasterDataManagmentUI.Converters;
using CommonContracts;
using DataAccessLayer.Interfaces;
using MasterDataMangementUI.Converters;
using MasterDataManagement.UIEntities;
using MasterDatamangementUI.Converters;

namespace MasterDataManagementUI.Currency
{
    /// <summary>
    /// Interaction logic for UpdateCurrency.xaml
    /// </summary>
    public partial class UpdateCurrency : Window
    {
        CurrencyUI Currency;
        public UpdateCurrency(CurrencyUI CurrencyUI)
        {
            InitializeComponent();
            this.Currency = CurrencyUI;
            this.Loaded += new RoutedEventHandler(UpdateCurrency_Loaded);
        }

        void UpdateCurrency_Loaded(object sender, RoutedEventArgs e)
        {
            txtCurrencyName.Focus();
            this.GridUpdateCurrency.DataContext = Currency;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string exceptionString = "";
            try
            {

                ICurrencyDAO currencyDAO = new CurrencyDAO();
                CurrencyPOCO currencyPOCO = CurrencyPOCOConverter.ConvertCurrencyUIToCurrencyPOCO(Currency);

                if (string.IsNullOrEmpty(Currency.CurrencyName))
                {
                    exceptionString = "\nCurrency Name cannot be left empty";
                    //throw new  Exception();
                }
                //if (string.IsNullOrEmpty(Currency.Description))
                //{
                //    exceptionString += "\nCurrency Description cannot be left empty";
                //    //throw new Exception();
                //}
                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);

                Currency.LastUpdatedBy = UserSession.UserId;

                Currency.LastUpdatedDate = DateTime.Now;
                //commodityType.IsCurrentVersion = true;
                //commodityType.Version += 1;
                if (currencyPOCO != null)
                {
                    string messageBoxText = "Are you sure you want to update the Currency?";
                    string caption = "Alert";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {
                        currencyDAO.UpdateCurrency(currencyPOCO);
                        MessageBox.Show("Currency Updated Successfully!");
                        this.Close();
                    }

                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Currency cannot be Updated!");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Currency cannot be Updated!"+exceptionString);
                throw;
            }
        }

        
    }
}
