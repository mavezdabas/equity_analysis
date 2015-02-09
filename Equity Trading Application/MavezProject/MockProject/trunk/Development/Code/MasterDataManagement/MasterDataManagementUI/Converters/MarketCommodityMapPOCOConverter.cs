using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using MasterDataManagement.UIEntities;


namespace MasterDatamangementUI.Converters
{
    class MarketCommodityMapPOCOConverter
    {
        internal static MarketCommodityMapUI ConvertMarketCommodityMapPOCOToMarketCommodityMapUI(MarketCommodityMapPOCO marketCommodityMapPOCO)
        {

            return new MarketCommodityMapUI()
            {
                MarketCommodityMapId = marketCommodityMapPOCO.MarketCommodityMapId,
                MarketId = marketCommodityMapPOCO.MarketId,
                CommodityTypeId = marketCommodityMapPOCO.CommodityTypeId

            };

        }

        internal static MarketCommodityMapPOCO ConvertMarketCommodityMapUIToMarketCommodityMapPOCO(MarketCommodityMapUI marketCommodityMapUI)
        {

            return new MarketCommodityMapPOCO()
            {
                MarketCommodityMapId = marketCommodityMapUI.MarketCommodityMapId,
                MarketId = marketCommodityMapUI.MarketId,
                CommodityTypeId = marketCommodityMapUI.CommodityTypeId

            };

        }

        internal static IEnumerable<MarketCommodityMapPOCO> ConvertMarketCommodityMapUIListToMarketCommodityMapPOCOList(IEnumerable<MarketCommodityMapUI> marketCommodityMapUIList)
        {
            List<MarketCommodityMapPOCO> marketCommodityMapPOCOList = new List<MarketCommodityMapPOCO>();
            foreach (var marketCommodityMap in marketCommodityMapUIList)
            {
                marketCommodityMapPOCOList.Add(ConvertMarketCommodityMapUIToMarketCommodityMapPOCO(marketCommodityMap));
            }

            return marketCommodityMapPOCOList;

        }

        internal static IEnumerable<MarketCommodityMapUI> ConvertMarketCommodityMapPOCOListToMarketCommodityMapUIList(IEnumerable<MarketCommodityMapPOCO> marketCommodityMapPOCOList)
        {
            List<MarketCommodityMapUI> marketCommodityMapUIList = new List<MarketCommodityMapUI>();
            foreach (var marketCommodityMapPOCO in marketCommodityMapPOCOList)
            {
                marketCommodityMapUIList.Add(ConvertMarketCommodityMapPOCOToMarketCommodityMapUI(marketCommodityMapPOCO));
            }

            return marketCommodityMapUIList;

        }

    }
}
