using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterDataManagement.UIEntities;
using CommonContracts;

namespace MasterDatamangementUI.Converters
{
    class CurrencyPOCOConverter
    {
        internal static CurrencyUI ConvertCurrencyPOCOToCurrencyUI(CurrencyPOCO currencyPOCO)
        {
            return new CurrencyUI()
            {
                CurrencyName = currencyPOCO.CurrencyName,
                Description = currencyPOCO.Description,
                LastUpdatedBy = currencyPOCO.LastUpdatedBy,
                LastUpdatedDate = currencyPOCO.LastUpdatedDate.Value,

            };
        }

        internal static CurrencyPOCO ConvertCurrencyUIToCurrencyPOCO(CurrencyUI currencyUI)
        {
            return new CurrencyPOCO()
            {
                CurrencyName = currencyUI.CurrencyName,
                Description = currencyUI.Description,
                LastUpdatedBy = currencyUI.LastUpdatedBy,
                LastUpdatedDate = currencyUI.LastUpdatedDate,
            };
        }
        internal static IEnumerable<CurrencyPOCO> ConvertCurrencyUIListToCurrencyPOCOList(IEnumerable<CurrencyUI> currencyUIList)
        {
            List<CurrencyPOCO> currencyPOCOList = new List<CurrencyPOCO>();
            foreach (var currency in currencyUIList)
            {
                currencyPOCOList.Add(ConvertCurrencyUIToCurrencyPOCO(currency));
            }
            return currencyPOCOList;
        }
        internal static IEnumerable<CurrencyUI> ConvertCurrencyPOCOListToCurrencyUIList(IEnumerable<CurrencyPOCO> currencyPOCOList)
        {
            List<CurrencyUI> currencyUIList = new List<CurrencyUI>();
            foreach (var currency in currencyPOCOList)
            {
                currencyUIList.Add(ConvertCurrencyPOCOToCurrencyUI(currency));
            }
            return currencyUIList;

        }
    }
}
