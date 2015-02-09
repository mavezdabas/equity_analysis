using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface IMarketDAO
    {
        IEnumerable<MarketPOCO> GetAllMarkets();
        void CreateMarket(MarketPOCO marketPOCOToBeCreated);
        void UpdateMarket(MarketPOCO marketPOCOToBeUpdated);
        void DeleteMarket(MarketPOCO marketPOCOToBeDeleted);
        MarketPOCO GetMarketByName(String MarketPOCOToBeSearched);
        int GetMarketIdByName(String marketPOCOName);
        string GetAllCommodityTypeNames(string marketName);
        IEnumerable<string> GetAllCommodityTypeNamesByMarketName(string marketName);
        
    }
}
