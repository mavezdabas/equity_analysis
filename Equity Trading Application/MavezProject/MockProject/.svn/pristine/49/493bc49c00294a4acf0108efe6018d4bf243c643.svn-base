using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using MasterDataManagement.UIEntities;

namespace MasterDataManagmentUI.Converters
{
    class CommodityTypePOCOConverter
    {
        internal static CommodityTypeUI ConvertCommodityTypePOCOToCommodityTypeUI(CommodityTypePOCO commodityTypePOCO)
        {

            return new CommodityTypeUI()
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
        internal static CommodityTypePOCO ConvertCommodityTypeUIToCommodityTypePOCO(CommodityTypeUI commodityType)
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

        internal static IEnumerable<CommodityTypePOCO> ConvertCommodityTypeUIListToCommodityTypePOCOList(IEnumerable<CommodityTypeUI> commodityTypeUIList)
        {
            List<CommodityTypePOCO> commodityTypePOCOList = new List<CommodityTypePOCO>();
            foreach (var commodityType in commodityTypeUIList)
            {
                commodityTypePOCOList.Add(ConvertCommodityTypeUIToCommodityTypePOCO(commodityType));
            }

            return commodityTypePOCOList;

        }

        internal static IEnumerable<CommodityTypeUI> ConvertCommodityTypePOCOListToCommodityTypePOCO(IEnumerable<CommodityTypePOCO> commodityTypePOCOList)
        {
            List<CommodityTypeUI> commodityTypeUIList = new List<CommodityTypeUI>();
            foreach (var commodityTypePOCO in commodityTypePOCOList)
            {
                commodityTypeUIList.Add(ConvertCommodityTypePOCOToCommodityTypeUI(commodityTypePOCO));
            }

            return commodityTypeUIList;
        }
    }
}