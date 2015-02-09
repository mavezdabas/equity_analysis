using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Linq;
using DataAccessLayer.Interfaces;
using CommonContracts;
using DataAccessLayer.DBML;
using DataAccessLayer.Converters;

namespace DataAccessLayer.DAL
{
    public class MarketDAO:IMarketDAO
    {

        public IEnumerable<MarketPOCO> GetAllMarkets()
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            var marketList = (from c in MarketDataContext.Markets
                              select c).ToList();
            var marketPOCOList = MarketConverters.ConvertMarketListToMarketPOCOList(marketList);
            return marketPOCOList;
        }

        public MarketPOCO GetMarketPOCOById(int id)
        {
            MDMDataContext context = new MDMDataContext();
            Market result = (from market in context.Markets
                         where market.MarketId == id
                         select market).First();
            
            return MarketConverters.ConvertMarketToMarketPOCO(result);
        }

        public void CreateMarket(MarketPOCO marketPOCOToBeCreated)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            MarketDataContext.Markets.InsertOnSubmit(MarketConverters.ConvertMarketPOCOToMarket(marketPOCOToBeCreated));
            MarketDataContext.SubmitChanges();
        }

        public void UpdateMarket(MarketPOCO marketPOCOToBeUpdated)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            var marketToBeUpdated = MarketConverters.ConvertMarketPOCOToMarket(marketPOCOToBeUpdated);
            marketToBeUpdated.MarketId = GetMarketIdByName(marketToBeUpdated.MarketName);
            MarketDataContext.Markets.Attach(marketToBeUpdated);
            MarketDataContext.Refresh(RefreshMode.KeepCurrentValues, marketToBeUpdated);
            MarketDataContext.SubmitChanges();
        } 

        public void DeleteMarket(MarketPOCO marketPOCOToBeDeleted)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            var marketToBeDeleted = MarketConverters.ConvertMarketPOCOToMarket(marketPOCOToBeDeleted);
            marketToBeDeleted.MarketId = GetMarketIdByName(marketToBeDeleted.MarketName);
            MarketDataContext.Markets.Attach(marketToBeDeleted);
            MarketDataContext.Markets.DeleteOnSubmit(marketToBeDeleted);
            MarketDataContext.SubmitChanges();
        }       

        public int GetMarketIdByName(string marketPOCOName)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            var searchedMarketId = (from market in MarketDataContext.Markets
                                  where market.MarketName == marketPOCOName
                                  select market.MarketId).FirstOrDefault();
            return searchedMarketId;
        }

        public string GetMarketNameById(int marketPOCOId)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            var searchedMarketName = (from market in MarketDataContext.Markets
                                    where market.MarketId == marketPOCOId
                                    select market.MarketName).First();
            return searchedMarketName;
        }

        public MarketPOCO GetMarketByName(string MarketPOCOToBeSearched)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            var searchedMarket = (from market in MarketDataContext.Markets
                                  where market.MarketName == MarketPOCOToBeSearched
                                  select market).FirstOrDefault();
            return MarketConverters.ConvertMarketToMarketPOCO(searchedMarket);

        }

        public IEnumerable<string> GetAllCommodityTypeNamesByMarketName(string marketName)
        {
             MDMDataContext MarketDataContext = new MDMDataContext();
            List<string> commodityNameList=new List<string>();
            //string allCommodities="";
            int marketId = GetMarketIdByName(marketName);
            
            IEnumerable<int> commodityTypeIdList=(from marketCommodityMap in MarketDataContext.MarketCommodityMaps
                                        where marketCommodityMap.MarketId==marketId
                                        select marketCommodityMap.CommodityTypeId).ToList();
            foreach (var item in commodityTypeIdList)
	{
                
		 
               var b = (from commmodity in MarketDataContext.CommodityTypes
                       where commmodity.CommodityTypeId == item
                       select commmodity.CommodityTypeName).FirstOrDefault();
                commodityNameList.Add(b);
	}
            return commodityNameList;

        }
        public string GetAllCommodityTypeNames(string marketName)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            List<string> commodityNameList=new List<string>();
            string allCommodities="";
            int marketId = GetMarketIdByName(marketName);
            
            IEnumerable<int> commodityTypeIdList=(from marketCommodityMap in MarketDataContext.MarketCommodityMaps
                                        where marketCommodityMap.MarketId==marketId
                                        select marketCommodityMap.CommodityTypeId).ToList();
            foreach (var item in commodityTypeIdList)
	{
                
		 
               var b = (from commmodity in MarketDataContext.CommodityTypes
                       where commmodity.CommodityTypeId == item
                       select commmodity.CommodityTypeName).FirstOrDefault();
                commodityNameList.Add(b);
	}

                foreach (var item in commodityNameList)
	{
		allCommodities+=item;
                    if(!(item==commodityNameList.Last()))
        allCommodities += "  ,";
	}

                return allCommodities;

        }
        

        

    }

    
}
