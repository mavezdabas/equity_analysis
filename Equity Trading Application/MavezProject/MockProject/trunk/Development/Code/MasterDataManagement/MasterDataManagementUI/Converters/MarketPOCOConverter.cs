using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using MasterDataManagement.UIEntities;

namespace MasterDatamanagementUI.Converters
{
    class MarketPOCOConverter
    {
        internal static MarketUI ConvertMarketPOCOToMarketUI(MarketPOCO marketPOCO)
        {
            return new MarketUI()
            {
                MarketName = marketPOCO.MarketName,
                StartDate = marketPOCO.StartDate.Value,
                EndDate = marketPOCO.EndDate,
                Version = marketPOCO.Version,
                LastUpdatedBy = marketPOCO.LastUpdatedBy,
                LastUpdatedDate = marketPOCO.LastUpdatedDate.Value,
                IsCurrentVersion = marketPOCO.IsCurrentVersion,
                LocationId = marketPOCO.LocationId,
                CurrencyId = marketPOCO.CurrencyId
            };
        }
        internal static MarketPOCO ConvertMarketUIToMarketPOCO(MarketUI marketUI)
        {
            return new MarketPOCO()
            {
                MarketName = marketUI.MarketName,
                StartDate = marketUI.StartDate,
                EndDate = marketUI.EndDate,
                Version = marketUI.Version,
                LastUpdatedBy = marketUI.LastUpdatedBy,
                LastUpdatedDate = marketUI.LastUpdatedDate,
                IsCurrentVersion = marketUI.IsCurrentVersion,
                LocationId = marketUI.LocationId,
                CurrencyId = marketUI.CurrencyId
            };
        }

        internal static IEnumerable<MarketPOCO> ConvertMarketUIListToMarketPOCOList(IEnumerable<MarketUI> marketUIList)
        {
            List<MarketPOCO> marketPOCOList = new List<MarketPOCO>();
            foreach (var market in marketUIList)
            {
                MarketPOCO marketPOCO = ConvertMarketUIToMarketPOCO(market);
                marketPOCOList.Add(marketPOCO);
            }
            return marketPOCOList;
        }

        internal static IEnumerable<MarketUI> ConvertMarketPOCOListToMarketUIList(IEnumerable<MarketPOCO> marketPOCOList)
        {
            List<MarketUI> marketUIList = new List<MarketUI>();
            foreach (var marketPOCO in marketPOCOList)
            {
                MarketUI market = ConvertMarketPOCOToMarketUI(marketPOCO);
                marketUIList.Add(market);
            }
            return marketUIList;
        }
    }
}
