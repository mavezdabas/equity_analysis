using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;

namespace MasterDataManagementUI.Validations
{
    public class EntityMappingBusinessValidation
    {
        public string CheckEmptyFields(BusinessMappingPOCO businessEntity)
        {
            string errorString = null;
           
            if (String.IsNullOrEmpty(businessEntity.MappingString))
                errorString = "Mapping String Cannot Be Empty";
            if (String.IsNullOrEmpty(businessEntity.EntityName))
                errorString += "Entity Name cannot be empty";
            if (String.IsNullOrEmpty(businessEntity.SourceSystemName))
                errorString += "Source System Cannot Be mpty";
            if (businessEntity.StartDate == null)
                errorString += "StartDate Cannot be Empty";
            if (String.IsNullOrEmpty(businessEntity.IsDefaultMapping))
                errorString+= "Default Mapping Must Be Selected";
            if(businessEntity.EndDate == null)
                errorString += "EndDate Cannot be Empty";
            return errorString;
        }

        public string CheckDuplicateMapping(BusinessMappingPOCO businessEntity)
        {
            IEntityMappingDAL mdmObject = new EntityMappingDAL();
            BusinessMappingPOCO objectToCheckDuplicacy = mdmObject.SearchMapping(businessEntity.MappingString);
            if (objectToCheckDuplicacy != null)
            {
                return String.Format("Mapping String Already Exists");
            }
            return String.Format("No Mapping Exists");
        }

        public BusinessMappingPOCO CheckDuplicateDefaultMapping(BusinessMappingPOCO businessEntity)
        {
            IEntityMappingDAL mdmObject = new EntityMappingDAL();
            BusinessMappingPOCO objectToCheckDuplicacy = mdmObject.SearchDuplicateDefaultMapping(businessEntity);
            if (objectToCheckDuplicacy != null)
            {
                return objectToCheckDuplicacy;
            }
            return null;
        }
    }
}
