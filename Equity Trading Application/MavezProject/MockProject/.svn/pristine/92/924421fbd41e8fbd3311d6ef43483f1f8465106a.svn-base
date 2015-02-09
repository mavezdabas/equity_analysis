using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using DataAccessLayer.DBML;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;


namespace DataAccessLayer.Converters
{

    internal static class MappingConverter
    {
        internal static BusinessMappingPOCO Convert(BusinessMapping mapping)
        {
            return new BusinessMappingPOCO()
            {
                EntityType = mapping.EntityType,
                EntityID = mapping.EntityId,
                EntityName = GetEntityName(mapping.EntityId,mapping.EntityType),
                SourceSystemName = GetSourceName(mapping.SourceSystemID),
                MappingID = mapping.MappingID,
                MappingString = mapping.MappingString,
                MappingDescription = mapping.MappingDescription,
                StartDate = mapping.StartDate,
                EndDate = mapping.EndDate,
                SourceSystemID = mapping.SourceSystemID,
                IsEnabled = mapping.IsEnabledFlag ? "Yes" : "No",
                IsDefaultMapping = mapping.IsDefaultMapping.HasValue ? (mapping.IsDefaultMapping.Value ? "Yes" : "No") : string.Empty,
                LastUpdatedBy = mapping.LastUpdatedBy,        //Get Name using UserDAL
                LastUpdatedDate = DateTime.Now
            };
        }

        internal static BusinessMapping Convert(BusinessMappingPOCO mapping)
        {
            return new BusinessMapping()
            {
                EntityType = mapping.EntityType,
                EntityId = mapping.EntityID,
                IsDefaultMapping = string.IsNullOrEmpty(mapping.IsDefaultMapping) ? default(Boolean?) : (mapping.IsDefaultMapping == "Yes" ? true : false),
                IsEnabledFlag = mapping.IsEnabled == "Yes" ? true : false,
                //LastUpdatedDate = mapping.LastUpdatedDate,
                MappingID = mapping.MappingID,
                MappingDescription = mapping.MappingDescription,
                StartDate = mapping.StartDate,
                MappingString = mapping.MappingString,
                EndDate = mapping.EndDate,
                SourceSystemID = mapping.SourceSystemID,
                LastUpdatedBy = UserSession.UserId
            };
        }

        private static string GetSourceName(int sourceSystemId)
        {
            ISourceSystemDAL SourceSystemDALObject = new SourceSystemDAL();
            return SourceSystemDALObject.GetSourceSystemName(sourceSystemId);
        }

        internal static string GetEntityName(int entityId,string entityType)
        {
            if(entityType.Trim().Equals("Commodity"))
            {
                string name = new CommodityTypeDAO().GetCommodityTypeNameByCommodityTypeId(entityId);
                return name;
            }
            else 
            {
                string name = new MarketDAO().GetMarketNameById(entityId);
                return name;
            }
        }

        internal static SourceSystemPOCO ConvertSourceSystemPOCO(SourceSystem sourceSystem)
        {
            return new SourceSystemPOCO()
            {
                SystemId = sourceSystem.SystemId,
                SystemName = sourceSystem.SystemName
            };
        }

        internal static SourceSystem ConvertSourceSystem(SourceSystemPOCO sourceSystem)
        {
            return new SourceSystem()
            {
                SystemId = sourceSystem.SystemId,
                SystemName = sourceSystem.SystemName
            };
        }
    }
}
