using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface ILocationDAO
    {
        IEnumerable<LocationPOCO> GetAllLocations();

        LocationPOCO GetLocationByName(string locationNameToSearch);
        void CreateLocation(LocationPOCO locationPOCOToBeCreated);
        void DeleteLocation(LocationPOCO locationPOCOToBeDeleted);
        void UpdateLocation(LocationPOCO locationPOCOToBeUpdated);
        int GetLocationIdByName(string locationName);
        string GetLocationNameById(int locationId);
    }
}
