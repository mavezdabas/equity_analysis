using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DBML;
using CommonContracts;

namespace EntityManagement.Helpers
{
    internal class CommodityTypeConverter
    {
        internal static CommodityType ConvertCommodityTypePOCOToCommodityType(CommodityTypePOCO commodityTypePOCO)
        {
            if (commodityTypePOCO != null)
            {
                return new CommodityType()
                {
                    CommodityTypeName = commodityTypePOCO.CommodityTypeName,
                    CommodityClass = commodityTypePOCO.CommodityClass,
                    StartDate = commodityTypePOCO.StartDate,
                    EndDate = commodityTypePOCO.EndDate,
                    Version = commodityTypePOCO.Version,
                    LastUpdatedBy = commodityTypePOCO.LastUpdatedBy,
                    LastUpdatedDate = commodityTypePOCO.LastUpdatedDate,
                    IsCurrentVersion = commodityTypePOCO.IsCurrentVersion
                };
            }
            else return null;
        }

        internal static CommodityTypePOCO ConvertCommodityTypeToCommodityTypePOCO(CommodityType commodityType)
        {
            return new CommodityTypePOCO()
            {
                CommodityTypeName = commodityType.CommodityTypeName,
                CommodityClass = commodityType.CommodityClass,
                StartDate = commodityType.StartDate,
                EndDate = commodityType.EndDate,
                Version = commodityType.Version,
                LastUpdatedBy = commodityType.LastUpdatedBy,
                LastUpdatedDate = commodityType.LastUpdatedDate,
                IsCurrentVersion = commodityType.IsCurrentVersion

            };

        }

        internal static IEnumerable<CommodityTypePOCO> ConvertCommodityTypeListToCommodityTypePOCOList(IEnumerable<CommodityType> commodityTypeList)
        {
            List<CommodityTypePOCO> commodityTypePOCOList=new List<CommodityTypePOCO>();
            foreach (var commodityType in commodityTypeList)
            {
                commodityTypePOCOList.Add(ConvertCommodityTypeToCommodityTypePOCO(commodityType));
            }

            return commodityTypePOCOList;

        }

        internal static IEnumerable<CommodityType> ConvertCommodityTypePOCOListToCommodityTypePOCO(IEnumerable<CommodityTypePOCO> commodityTypePOCOList)
        {
            List<CommodityType> commodityTypeList = new List<CommodityType>();
            foreach (var commodityTypePOCO in commodityTypePOCOList)
            {
                commodityTypeList.Add(ConvertCommodityTypePOCOToCommodityType(commodityTypePOCO));
            }

            return commodityTypeList;
        }
    }
}
