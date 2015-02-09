using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityManagement.Helpers;
using System.Data.Linq;
using DataAccessLayer.DBML;
using DataAccessLayer.Interfaces;
using CommonContracts;
using DataAccessLayer.Converters;

namespace DataAccessLayer.DAL
{
    public class CurrencyDAO : ICurrencyDAO
    {

        public IEnumerable<CurrencyPOCO> GetAllCurrencies()
        {
            MDMDataContext CurrencyContext = new MDMDataContext();

            var currencyList = (from currency in CurrencyContext.Currencies
                                select currency).ToList();
            var currencyPOCOList = CurrencyConverter.ConvertCurrencyListToCurrencyPOCOList(currencyList);

            return currencyPOCOList;
        }

        public CurrencyPOCO GetCurrencyByName(string nameToSearch)
        {
            MDMDataContext CurrencyContext = new MDMDataContext();
            var searchedCurrency = (from currency in CurrencyContext.Currencies
                                    where currency.CurrencyName == nameToSearch
                                    select currency).FirstOrDefault();
            var searchedPOCOCurrency = CurrencyConverter.ConvertCurrencyToCurrencyPOCO(searchedCurrency);
            return searchedPOCOCurrency;
        }

        public void CreateCurrency(CurrencyPOCO currencyPOCOToBeCreated)
        {
            MDMDataContext CurrencyContext = new MDMDataContext();
            var currencyToBeCreated = CurrencyConverter.ConvertCurrencyPOCOToCurrency(currencyPOCOToBeCreated);
            currencyToBeCreated.LastUpdatedBy = UserSession.UserId;
            //currencyToBeCreated.LastUpdatedBy = 2;
            currencyToBeCreated.LastUpdatedDate = DateTime.Now;
            CurrencyContext.Currencies.InsertOnSubmit(currencyToBeCreated);

            CurrencyContext.SubmitChanges();

        }

        public void DeleteCurrency(CurrencyPOCO currencyPOCOToBeDeleted)
        {
            MDMDataContext CurrencyContext = new MDMDataContext();
            var currencyToBeDeleted = CurrencyConverter.ConvertCurrencyPOCOToCurrency(currencyPOCOToBeDeleted);
            currencyToBeDeleted.CurrencyId = GetIdByName(currencyToBeDeleted.CurrencyName);
            CurrencyContext.Currencies.Attach(currencyToBeDeleted);
            CurrencyContext.Currencies.DeleteOnSubmit(currencyToBeDeleted);
            CurrencyContext.SubmitChanges();
        }

        public void UpdateCurrency(CurrencyPOCO currencyPOCOToBeUpdated)
        {
            MDMDataContext CurrencyContext = new MDMDataContext();
            var currencyToBeUpdated = CurrencyConverter.ConvertCurrencyPOCOToCurrency(currencyPOCOToBeUpdated);
            currencyToBeUpdated.CurrencyId = GetIdByName(currencyToBeUpdated.CurrencyName);
            CurrencyContext.Currencies.Attach(currencyToBeUpdated);
            CurrencyContext.Refresh(RefreshMode.KeepCurrentValues, currencyToBeUpdated);
            CurrencyContext.SubmitChanges();
        }

        public int GetIdByName(string currencyName)
        {
            MDMDataContext CurrencyContext = new MDMDataContext();
            var searchedCurrencyId = (from currency in CurrencyContext.Currencies
                                      where currency.CurrencyName == currencyName
                                      select currency.CurrencyId).FirstOrDefault();
            // var searchedPOCOCurrencyId = CurrencyConverter.ConvertCurrencyToCurrencyPOCO(searchedCurrency);
            return searchedCurrencyId;
        }
        public string GetCurrencyNameById(int currencyId)
        {
            MDMDataContext CurrencyContext = new MDMDataContext();
            var searchedCurrencyName = (from currency in CurrencyContext.Currencies
                                        where currency.CurrencyId == currencyId
                                        select currency.CurrencyName).FirstOrDefault();
            return searchedCurrencyName;
        }
    }
}
