using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface IEntityMappingDAL
    {
        void Add(BusinessMappingPOCO mappingToAdd);
        void Edit(BusinessMappingPOCO mappingToEdit);
        void Delete(int id);
        List<BusinessMappingPOCO> GetList();
        BusinessMappingPOCO SearchMapping(int id);
        BusinessMappingPOCO SearchMapping(string mappingString);
        BusinessMappingPOCO SearchDuplicateDefaultMapping(BusinessMappingPOCO mappingToEdit);
    }
}
