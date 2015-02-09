using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface IMarketCommodityMapDAO
    {
        void DeleteMarketCommodityMap(int marketId);
        void CreateMarketCommodityMap(IEnumerable<MarketCommodityMapPOCO> marketCommodityMapPOCOListToBeCreated);
        void UpdateMarketCommodityMap(IEnumerable<MarketCommodityMapPOCO> marketCommodityMapPOCOListToBeUpdated);
        IEnumerable<int> GetAllMappedCommodityTypeIDs(int marketId);
    }
}
