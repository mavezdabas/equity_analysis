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
using MasterDatamangementUI.Converters;

namespace MasterDataManagementUI.Currency
{
    /// <summary>
    /// Interaction logic for DeleteCurrency.xaml
    /// </summary>
    public partial class DeleteCurrency : Window
    {
        CurrencyUI Currency;

        public DeleteCurrency(CurrencyUI CurrencyUI)
        {
            InitializeComponent();
            this.Currency = CurrencyUI;
            this.Loaded += new RoutedEventHandler(DeleteCurrency_Loaded);
        }

        void DeleteCurrency_Loaded(object sender, RoutedEventArgs e)
        {
            Save.Focus();
            this.GridDeleteCurrency.DataContext = Currency;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ICurrencyDAO currencyDAO = new CurrencyDAO();
                CurrencyPOCO currencyPOCO = CurrencyPOCOConverter.ConvertCurrencyUIToCurrencyPOCO(Currency);
                if (currencyPOCO != null)
                {
                    // MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the currency?");
                     string messageBoxText = "Are you sure you want to delete the Currency?";
                     string caption = "Alert";
                     MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon= MessageBoxImage.Warning;
                     MessageBoxResult result= MessageBox.Show(messageBoxText, caption, button,icon);
                     if (result == MessageBoxResult.Yes)
                     {
                    currencyDAO.DeleteCurrency(currencyPOCO);
                    MessageBox.Show("Currency Deleted Successfully!");
                       
                    this.Close();
                     }

                    else
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Currency cannot be Deleted!");
                    this.Close();
                }
            }

            catch (Exception)
            {

                MessageBox.Show("Currency cannot be Deleted. Currency already being used in Market!");
                this.Close();
            }


        }
    }
}
