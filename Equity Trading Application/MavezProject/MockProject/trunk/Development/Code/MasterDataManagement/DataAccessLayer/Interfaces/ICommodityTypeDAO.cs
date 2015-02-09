using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface ICommodityTypeDAO
    {
        void CreateCommodityType(CommodityTypePOCO commodityTypePOCOToBeCreated);
        void UpdateCommodityType(CommodityTypePOCO commodityTypePOCOToBeUpdated);
        void DeleteCommodityType(CommodityTypePOCO commodityTypePOCOToBeDeleted);
        CommodityTypePOCO GetCommodityTypeByName(string commodityTypePOCOName);
        IEnumerable<CommodityTypePOCO> GetAllCommodityTypes();
        int GetCommodityTypeIdByCommodityTypeName(string commodityTypePOCOName);
        int GetVersionByCommodityName(string commodityTypeName);
        IEnumerable<string> GetAllCommodityTypeNames();
        List<int> GetCommodityIdList(List<String> commodityTypeNameList);
    }
}
