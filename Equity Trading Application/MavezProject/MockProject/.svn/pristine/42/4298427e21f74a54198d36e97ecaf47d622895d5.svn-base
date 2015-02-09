using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using EntityManagement.Helpers;
using DataAccessLayer.Interfaces;
using CommonContracts;
using DataAccessLayer.DBML;


namespace DataAccessLayer.DAL    
{
   public class CommodityTypeDAO:ICommodityTypeDAO
    {

        public void CreateCommodityType(CommodityTypePOCO commodityTypePOCOToBeCreated)
        {
            if (commodityTypePOCOToBeCreated != null)
            {
                MDMDataContext commodityTypeDataContext = new MDMDataContext();
                var convertedEntity = CommodityTypeConverter.ConvertCommodityTypePOCOToCommodityType(commodityTypePOCOToBeCreated);
                convertedEntity.LastUpdatedBy = UserSession.UserId;
                convertedEntity.LastUpdatedDate = DateTime.Now;
                convertedEntity.IsCurrentVersion = true;
                convertedEntity.Version = GetVersionByCommodityName(convertedEntity.CommodityTypeName)+1;
                commodityTypeDataContext.CommodityTypes.InsertOnSubmit(convertedEntity);
                commodityTypeDataContext.SubmitChanges();
            }
        }

        public void UpdateCommodityType(CommodityTypePOCO commodityTypePOCOToBeUpdated)
        {
            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var commodityTypeToBeUpdated = CommodityTypeConverter.ConvertCommodityTypePOCOToCommodityType(commodityTypePOCOToBeUpdated);
            commodityTypeToBeUpdated.CommodityTypeId = GetCommodityTypeIdByCommodityTypeName(commodityTypeToBeUpdated.CommodityTypeName);
            commodityTypeDataContext.CommodityTypes.Attach(commodityTypeToBeUpdated);
            commodityTypeDataContext.Refresh(RefreshMode.KeepCurrentValues, commodityTypeToBeUpdated);
            commodityTypeDataContext.SubmitChanges();
            
            
        }

        public void DeleteCommodityType(CommodityTypePOCO commodityTypePOCOToBeDeleted)
        {

            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var commodityTypeToBeDeleted = CommodityTypeConverter.ConvertCommodityTypePOCOToCommodityType(commodityTypePOCOToBeDeleted);
            commodityTypeToBeDeleted.CommodityTypeId = GetCommodityTypeIdByCommodityTypeName(commodityTypeToBeDeleted.CommodityTypeName);
            commodityTypeDataContext.CommodityTypes.Attach(commodityTypeToBeDeleted);
            commodityTypeDataContext.Refresh(RefreshMode.KeepCurrentValues, commodityTypeToBeDeleted);
            commodityTypeDataContext.CommodityTypes.DeleteOnSubmit(commodityTypeToBeDeleted);
            commodityTypeDataContext.SubmitChanges();
        }

        public CommodityTypePOCO GetCommodityTypeByName(string commodityTypePOCOName)
        {
            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var searchCommodityType = (from commodityType in commodityTypeDataContext.CommodityTypes
                                 where commodityType.CommodityTypeName == commodityTypePOCOName
                                 select commodityType).FirstOrDefault();
            var commodityTypePOCO = CommodityTypeConverter.ConvertCommodityTypeToCommodityTypePOCO(searchCommodityType);
            return commodityTypePOCO;
           
        }

        public IEnumerable<CommodityTypePOCO> GetAllCommodityTypes()
        {

            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var commodityTypeList = (from commodityType in commodityTypeDataContext.CommodityTypes
                                     select commodityType).ToList();

            var commodityTypePOCOList = CommodityTypeConverter.ConvertCommodityTypeListToCommodityTypePOCOList(commodityTypeList);

            return commodityTypePOCOList;

            //throw new NotImplementedException();
        }

        public int GetCommodityTypeIdByCommodityTypeName(string commodityTypePOCOName)
        {
            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var searchCommodityTypeId = (from commodityType in commodityTypeDataContext.CommodityTypes
                                       where commodityType.CommodityTypeName == commodityTypePOCOName
                                       select commodityType.CommodityTypeId).FirstOrDefault();
            return searchCommodityTypeId;
            //throw new NotImplementedException();
        }

        public string GetCommodityTypeNameByCommodityTypeId(int commodityTypePOCOId)
        {
            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var searchCommodityTypeName = (from commodityType in commodityTypeDataContext.CommodityTypes
                                         where commodityType.CommodityTypeId == commodityTypePOCOId
                                         select commodityType.CommodityTypeName).First();
            return searchCommodityTypeName;
            //throw new NotImplementedException();
        }

        public int GetVersionByCommodityName(string commodityTypeName)
        {
            MDMDataContext MarketDataContext = new MDMDataContext();
            Nullable<int> versionId = (from commodityType in MarketDataContext.CommodityTypes
                                       where commodityType.CommodityTypeName == commodityTypeName
                                       select commodityType.Version).FirstOrDefault();
            if (versionId == null)
            {
                return 0;
            }
            else
            {
                int vId = (int)versionId;
                return vId;
            }
        }

        public IEnumerable<string> GetAllCommodityTypeNames()
        {

            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            var commodityTypeList = (from commodityType in commodityTypeDataContext.CommodityTypes
                                     select commodityType.CommodityTypeName).ToList();

            return commodityTypeList;

            //throw new NotImplementedException();
        }

        public List<int> GetCommodityIdList(List<string> commodityNameList)
        {
            MDMDataContext commodityTypeDataContext = new MDMDataContext();
            List<int> commodityIdList = new List<int>();


            foreach (var item in commodityNameList)
            {
                int searchCommodityTypeId = (from commodityType in commodityTypeDataContext.CommodityTypes
                                             where commodityType.CommodityTypeName == item
                                             select commodityType.CommodityTypeId).FirstOrDefault();
                commodityIdList.Add(searchCommodityTypeId);
            }
            return commodityIdList;
        }
    }
}
