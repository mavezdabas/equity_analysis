using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DBML;
using CommonContracts;


namespace DataAccessLayer.Converters
{
    internal class MarketCommodityMapConverter
    {
        internal static MarketCommodityMap ConvertMarketCommodityMapPOCOToMarketCommodityMap(MarketCommodityMapPOCO marketCommodityMapPOCO)
        {

            return new MarketCommodityMap()
            {
                MarketCommodityMapId=marketCommodityMapPOCO.MarketCommodityMapId,
                MarketId=marketCommodityMapPOCO.MarketId,
                CommodityTypeId=marketCommodityMapPOCO.CommodityTypeId

            };

        }

        internal static MarketCommodityMapPOCO ConvertMarketCommodityMapToMarketCommodityMapPOCO(MarketCommodityMap marketCommodityMap)
        {

            return new MarketCommodityMapPOCO()
            {
                MarketCommodityMapId = marketCommodityMap.MarketCommodityMapId,
                MarketId = marketCommodityMap.MarketId,
                CommodityTypeId = marketCommodityMap.CommodityTypeId

            };

        }

        internal static IEnumerable<MarketCommodityMapPOCO> ConvertMarketCommodityMapListToMarketCommodityMapPOCOList(IEnumerable<MarketCommodityMap> marketCommodityMapList)
        {
            List<MarketCommodityMapPOCO> marketCommodityMapPOCOList = new List<MarketCommodityMapPOCO>();
            foreach (var marketCommodityMap in marketCommodityMapList)
            {
                marketCommodityMapPOCOList.Add(ConvertMarketCommodityMapToMarketCommodityMapPOCO(marketCommodityMap));
            }

            return marketCommodityMapPOCOList;

        }

        internal static IEnumerable<MarketCommodityMap> ConvertMarketCommodityMapPOCOListToMarketCommodityMapList(IEnumerable<MarketCommodityMapPOCO> marketCommodityMapPOCOList)
        {
            List<MarketCommodityMap> marketCommodityMapList = new List<MarketCommodityMap>();
            foreach (var marketCommodityMapPOCO in marketCommodityMapPOCOList)
            {
                marketCommodityMapList.Add(ConvertMarketCommodityMapPOCOToMarketCommodityMap(marketCommodityMapPOCO));
            }

            return marketCommodityMapList;

        }
    }
}
