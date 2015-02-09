using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DBML;
using CommonContracts;


namespace DataAccessLayer.Converters
{
    public class MarketConverters
    {
        public static Market ConvertMarketPOCOToMarket(MarketPOCO market)
        {
            return new Market()
            {
                MarketName =market.MarketName,
                StartDate=market.StartDate,
                EndDate=market.EndDate,
                Version=market.Version,
                LastUpdatedBy=market.LastUpdatedBy,
                LastUpdatedDate=market.LastUpdatedDate,
                IsCurrentVersion=market.IsCurrentVersion,
                LocationId=market.LocationId,
                CurrencyId=market.CurrencyId
            };
        }
        public static MarketPOCO ConvertMarketToMarketPOCO(Market marketPOCO)
        {
            return new MarketPOCO()
            {
                MarketName = marketPOCO.MarketName,
                StartDate = marketPOCO.StartDate,
                EndDate = marketPOCO.EndDate,
                Version = marketPOCO.Version,
                LastUpdatedBy = marketPOCO.LastUpdatedBy,
                LastUpdatedDate = marketPOCO.LastUpdatedDate,
                IsCurrentVersion = marketPOCO.IsCurrentVersion,
                LocationId = marketPOCO.LocationId,
                CurrencyId = marketPOCO.CurrencyId
            };
        }

        public static IEnumerable<MarketPOCO> ConvertMarketListToMarketPOCOList(IEnumerable<Market> marketList)
        {
            List<MarketPOCO> marketPOCOList=new List<MarketPOCO>();
            foreach (var market in marketList)
            {
                MarketPOCO marketPOCO = ConvertMarketToMarketPOCO(market);
                marketPOCOList.Add(marketPOCO);
            }
            return marketPOCOList;
        }

        public static IEnumerable<Market> ConvertMarketPOCOListToMarketList(IEnumerable<MarketPOCO> marketPOCOList)
        {
            List<Market> marketList = new List<Market>();
            foreach (var marketPOCO in marketPOCOList)
            {
                Market market = ConvertMarketPOCOToMarket(marketPOCO);
                marketList.Add(market);
            }
            return marketList;
        }
    }
}
