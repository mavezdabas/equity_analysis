using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DBML;
using CommonContracts;

namespace DataAccessLayer.Converters
{
    internal class CurrencyConverter
    {

        internal static Currency ConvertCurrencyPOCOToCurrency(CurrencyPOCO currency)
        {
            return new Currency()
            {
                CurrencyName = currency.CurrencyName,
                Description= currency.Description,
                LastUpdatedBy = currency.LastUpdatedBy,
                LastUpdatedDate = currency.LastUpdatedDate,
               
            };
        }

        internal static CurrencyPOCO ConvertCurrencyToCurrencyPOCO(Currency currency)
        {
            return new CurrencyPOCO()
            {
                CurrencyName = currency.CurrencyName,
                Description = currency.Description,
                LastUpdatedBy = currency.LastUpdatedBy,
                LastUpdatedDate = currency.LastUpdatedDate,
            };
        }
        internal static IEnumerable<CurrencyPOCO> ConvertCurrencyListToCurrencyPOCOList(IEnumerable<Currency> currencyList)
        {
            List<CurrencyPOCO> currencyPOCOList=new List<CurrencyPOCO>();
            foreach (var currency in currencyList)      	
            {	
	 	       currencyPOCOList.Add(ConvertCurrencyToCurrencyPOCO(currency));
            }
            return currencyPOCOList;                    
        }
        internal static IEnumerable<Currency> ConvertCurrencyPOCOListToCurrencyList(IEnumerable<CurrencyPOCO> currencyPOCOList)
        {
            List<Currency> currencyList = new List<Currency>();
            foreach (var currency in currencyPOCOList)
            {
                currencyList.Add(ConvertCurrencyPOCOToCurrency(currency));
            }
            return currencyList;
 
        }
    }
}
