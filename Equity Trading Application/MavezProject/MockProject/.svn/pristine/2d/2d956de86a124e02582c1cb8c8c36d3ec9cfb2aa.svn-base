using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface ICurrencyDAO
    {
        IEnumerable<CurrencyPOCO> GetAllCurrencies();
        CurrencyPOCO GetCurrencyByName(string nameToSearch);
        void CreateCurrency(CurrencyPOCO currencyToBeCreated);
        void DeleteCurrency(CurrencyPOCO currencyToBeDeleted);
        void UpdateCurrency(CurrencyPOCO currencyToBeUpdated);
        int GetIdByName(string currencyName);
        string GetCurrencyNameById(int currencyId);
    }
}
