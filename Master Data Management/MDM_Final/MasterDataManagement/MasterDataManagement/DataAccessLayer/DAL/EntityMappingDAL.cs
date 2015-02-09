using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using System.Data.Linq;
using DataAccessLayer.DBML;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Converters;


namespace DataAccessLayer.DAL
{
    public class EntityMappingDAL : IEntityMappingDAL
    {
        public void Add(BusinessMappingPOCO mappingToAdd)
        {
            MDMDataContext context = new MDMDataContext();
            var convertedEntity = MappingConverter.Convert(mappingToAdd);
            context.BusinessMappings.InsertOnSubmit(convertedEntity);
            context.SubmitChanges();
        }
        public void Edit(BusinessMappingPOCO mappingToEdit)
        {
            MDMDataContext context = new MDMDataContext();
            BusinessMapping editMappingObject = MappingConverter.Convert(mappingToEdit);
            context.BusinessMappings.Attach(editMappingObject);
            context.Refresh(RefreshMode.KeepCurrentValues, editMappingObject);
            context.SubmitChanges();
        }
        public void Delete(int id)
        {
            MDMDataContext context = new MDMDataContext();
            var deleteMappingObject = MappingConverter.Convert(SearchMapping(id));
            context.BusinessMappings.Attach(deleteMappingObject);
            context.BusinessMappings.DeleteOnSubmit(deleteMappingObject);
            //context.Refresh(RefreshMode.KeepCurrentValues);
            context.SubmitChanges();
        }
        public BusinessMappingPOCO SearchMapping(int id)
        {
            MDMDataContext context = new MDMDataContext();
            var mapping = (from map in context.BusinessMappings
                           where map.MappingID == id
                           select map).FirstOrDefault();
            if (mapping != null)
                return MappingConverter.Convert(mapping);

            return null;
        }

        public BusinessMappingPOCO SearchMapping(string mappingString)
        {
            BusinessMapping mapping = null;
            try
            {
                MDMDataContext context = new MDMDataContext();
                mapping = (from map in context.BusinessMappings
                           where map.MappingString == mappingString
                           select map).FirstOrDefault();
                if (mapping != null)
                    return MappingConverter.Convert(mapping);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }

            return null;
        }

        public List<BusinessMappingPOCO> GetList()
        {
            List<BusinessMappingPOCO> mappingPOCOList = null;
            try
            {
                MDMDataContext context = new MDMDataContext();
                List<BusinessMapping> list = (List<BusinessMapping>)(from mapping in context.BusinessMappings
                                                                     select mapping).ToList();
                mappingPOCOList = new List<BusinessMappingPOCO>();
                foreach (var mapping in list)
                {
                    mappingPOCOList.Add(MappingConverter.Convert(mapping));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //throw new EntityMappingException(e.Message, e);
            }
            return mappingPOCOList;
        }

        public BusinessMappingPOCO SearchDuplicateDefaultMapping(BusinessMappingPOCO mappingToAdd)
        {
            try
            {
                MDMDataContext context = new MDMDataContext();
                var mapping = (from map in context.BusinessMappings
                               where map.EntityId == MappingConverter.Convert(mappingToAdd).EntityId && map.IsDefaultMapping == true
                               select map).FirstOrDefault();
                if (mapping != null)
                    return MappingConverter.Convert(mapping);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
    }
}
