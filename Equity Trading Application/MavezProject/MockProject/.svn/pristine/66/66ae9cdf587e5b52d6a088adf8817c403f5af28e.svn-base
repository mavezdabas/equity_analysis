using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityManagement.Helpers;
using System.Data.Linq;
using DataAccessLayer.Interfaces;
using CommonContracts;
using DataAccessLayer.DBML;
using DataAccessLayer.Converters;

namespace DataAccessLayer.DAL    
{
    public class MarketCommodityMapDAO : IMarketCommodityMapDAO
    {

        //public void CreateMarketCommodityMap(MarketCommodityMapPOCO marketCommodityMapPOCOToBeCreated)
        //{
        //    MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
        //    marketCommodityMapDataContext.MarketCommodityMaps.InsertOnSubmit(MarketCommodityMapConverter.ConvertMarketCommodityMapPOCOToMarketCommodityMap(marketCommodityMapPOCOToBeCreated));
        //    marketCommodityMapDataContext.SubmitChanges();
            
        //}
        public void CreateMarketCommodityMap(IEnumerable<MarketCommodityMapPOCO> marketCommodityMapPOCOListToBeCreated)
        {
            MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
            List<MarketCommodityMap> marketCommodityMapList = new List<MarketCommodityMap>();
            foreach (var marketCommodityMapPOCO in marketCommodityMapPOCOListToBeCreated)
            {
                var marketCommodityMapToBeAdded = MarketCommodityMapConverter.ConvertMarketCommodityMapPOCOToMarketCommodityMap(marketCommodityMapPOCO);
                marketCommodityMapList.Add(marketCommodityMapToBeAdded);
            }

            //marketCommodityMapDataContext.MarketCommodityMaps.AttachAll(marketCommodityMapList);
            marketCommodityMapDataContext.MarketCommodityMaps.InsertAllOnSubmit(marketCommodityMapList);
            marketCommodityMapDataContext.SubmitChanges();


        }


        //public void UpdateMarketCommodityMap(MarketCommodityMapPOCO marketCommodityMapPOCOToBeUpdated)
        //{
        //    MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
        //    var marketCommodityMapToBeUpdated=MarketCommodityMapConverter.ConvertMarketCommodityMapPOCOToMarketCommodityMap(marketCommodityMapPOCOToBeUpdated);
        //    marketCommodityMapDataContext.MarketCommodityMaps.Attach(marketCommodityMapToBeUpdated);
        //    marketCommodityMapDataContext.Refresh(RefreshMode.KeepCurrentValues, marketCommodityMapToBeUpdated);
        //    marketCommodityMapDataContext.SubmitChanges();

        //}


        public void UpdateMarketCommodityMap(IEnumerable<MarketCommodityMapPOCO> marketCommodityMapPOCOListToBeUpdated)
        {
            MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
            List<MarketCommodityMap> marketCommodityMapList = new List<MarketCommodityMap>();
            foreach (var marketCommodityMapPOCO in marketCommodityMapPOCOListToBeUpdated)
            {
                var marketCommodityMapToBeUpdated = MarketCommodityMapConverter.ConvertMarketCommodityMapPOCOToMarketCommodityMap(marketCommodityMapPOCO);
                marketCommodityMapList.Add(marketCommodityMapToBeUpdated);
                
            }
            marketCommodityMapDataContext.MarketCommodityMaps.AttachAll(marketCommodityMapList);
            marketCommodityMapDataContext.Refresh(RefreshMode.KeepCurrentValues, marketCommodityMapList);
            marketCommodityMapDataContext.SubmitChanges();


        }

        //public void DeleteMarketCommodityMap(MarketCommodityMapPOCO marketCommodityMapPOCOToBeDeleted)
        //{
        //    MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
        //    var marketCommodityMapToBeDeleted = MarketCommodityMapConverter.ConvertMarketCommodityMapPOCOToMarketCommodityMap(marketCommodityMapPOCOToBeDeleted);
        //    marketCommodityMapDataContext.MarketCommodityMaps.Attach(marketCommodityMapToBeDeleted);
        //    marketCommodityMapDataContext.MarketCommodityMaps.DeleteOnSubmit(marketCommodityMapToBeDeleted);
            
        //}
        public void DeleteMarketCommodityMap(int marketId)
        {
            MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
            var marketCommodityMappingsToBeDeleted = (from marketCommodityMap in marketCommodityMapDataContext.MarketCommodityMaps
                        where marketCommodityMap.MarketId == marketId
                        select marketCommodityMap).ToList();
            
            //marketCommodityMapDataContext.MarketCommodityMaps.AttachAll(marketCommodityMappingsToBeDeleted);
            marketCommodityMapDataContext.MarketCommodityMaps.DeleteAllOnSubmit(marketCommodityMappingsToBeDeleted);
            marketCommodityMapDataContext.SubmitChanges();
        }

        public IEnumerable<int> GetAllMappedCommodityTypeIDs(int marketId)
        {
            MDMDataContext marketCommodityMapDataContext = new MDMDataContext();
            var marketCommodityMapIdList = (from marketCommodityMap in marketCommodityMapDataContext.MarketCommodityMaps
                                          where marketCommodityMap.MarketId==marketId
                                          select marketCommodityMap.MarketId).ToList();

            return marketCommodityMapIdList;
           
        }


        
    }
}
