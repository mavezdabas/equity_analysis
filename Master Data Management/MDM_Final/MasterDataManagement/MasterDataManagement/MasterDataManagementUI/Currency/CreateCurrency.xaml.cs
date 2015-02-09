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
using MasterDataManagement.UIEntities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;
using MasterDatamangementUI.Converters;

namespace MasterDataManagementUI.Currency
{
    /// <summary>
    /// Interaction logic for CreateCurrency.xaml
    /// </summary>
    public partial class CreateCurrency : Window
    {
        CurrencyUI currency;
        public CreateCurrency()
        {
            InitializeComponent();
            currency = new CurrencyUI();
            this.Loaded += new RoutedEventHandler(CreateCurrency_Loaded);
        }

        void CreateCurrency_Loaded(object sender, RoutedEventArgs e)
        {
            txtCurrencyName.Focus();
            this.GridCreateCurrency.DataContext = currency;
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
                
                if (string.IsNullOrEmpty(currency.CurrencyName))
                {
                    exceptionString = "\nCurrency Name cannot be left empty";
                    //throw new  Exception();
                }
                //if (string.IsNullOrEmpty(currency.Description))
                //{
                //    exceptionString += "\nCurrency Description cannot be left empty";
                //    //throw new Exception();
                //}
                if (!string.IsNullOrEmpty(exceptionString))
                    throw new Exception(exceptionString);
                ICurrencyDAO currencyDAO = new CurrencyDAO();
                CurrencyPOCO currencyPOCO = CurrencyPOCOConverter.ConvertCurrencyUIToCurrencyPOCO(currency);
                string currencyName = txtCurrencyName.Text;
                int currencyId = currencyDAO.GetIdByName(currencyName);


                if (currencyPOCO != null)
                {
                    if (currencyId != 0)
                    {
                        MessageBox.Show("Currency already exists!");
                    }
                    else
                    {
                        string messageBoxText = "Are you sure you want to create the Currency?";
                        string caption = "Alert";
                        MessageBoxButton button = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                        if (result == MessageBoxResult.Yes)
                        {

                            currencyDAO.CreateCurrency(currencyPOCO);
                            MessageBox.Show("Currency is created!");
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
                    MessageBox.Show("Currency cannot be created!");
                    this.Close();
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show("Currency Cannot be created!" + exceptionString);
            }
           

            //String currencyName = txtCurrencyName.Text;
            //String currencyDescription = txtCurrencyDescription.Text;
            //CurrencyUI currency = new CurrencyUI(currencyName, currencyDescription);
            //CurrencyPOCO currencyPOCO = CurrencyPOCOConverter.ConvertCurrencyUIToCurrencyPOCO(currency);
            //ICurrencyDAO currencyDAO = new CurrencyDAO();
            //currencyDAO.CreateCurrency(currencyPOCO);
        }
    }
}
