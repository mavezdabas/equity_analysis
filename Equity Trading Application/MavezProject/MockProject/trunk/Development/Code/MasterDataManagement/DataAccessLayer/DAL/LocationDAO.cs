using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DataAccessLayer.Interfaces;
using CommonContracts;
using DataAccessLayer.DBML;
using DataAccessLayer.Converters;

namespace DataAccessLayer.DAL
{
    public class LocationDAO : ILocationDAO
    {


        public IEnumerable<LocationPOCO> GetAllLocations()
        {
            MDMDataContext locationContext = new MDMDataContext();

            var locationList = (from location in locationContext.Locations
                                select location).ToList();

            var locationPOCOList = LocationConverter.ConvertLocationListToLocationPOCOList(locationList);

            return locationPOCOList;
        }

        public LocationPOCO GetLocationByName(string locationNameToSearch)
        {
            MDMDataContext locationContext = new MDMDataContext();

            var searchedLocation = (from location in locationContext.Locations
                                    where location.LocationName == locationNameToSearch
                                    select location).FirstOrDefault();
            var searchedPOCOLocation = LocationConverter.ConvertLocationToLocationPOCO(searchedLocation);
            return searchedPOCOLocation;

        }

        public void CreateLocation(LocationPOCO locationPOCOToBeCreated)
        {
            MDMDataContext locationContext = new MDMDataContext();
            var ConvertedEntity = LocationConverter.ConvertLocationPOCOToLocation(locationPOCOToBeCreated);
            ConvertedEntity.LastUpdatedDate = DateTime.Now;
            ConvertedEntity.LastUpdatedBy = UserSession.UserId;
            //ConvertedEntity.LastUpdatedBy = 2;
            locationContext.Locations.InsertOnSubmit(ConvertedEntity);
            locationContext.SubmitChanges();
        }

        public void DeleteLocation(LocationPOCO locationPOCOToBeDeleted)
        {
            MDMDataContext locationContext = new MDMDataContext();
            var locationToBeDeleted = LocationConverter.ConvertLocationPOCOToLocation(locationPOCOToBeDeleted);
            locationToBeDeleted.LocationId = GetLocationIdByName(locationToBeDeleted.LocationName);
            locationContext.Locations.Attach(locationToBeDeleted);
            locationContext.Locations.DeleteOnSubmit(locationToBeDeleted);
            locationContext.SubmitChanges();
        }


        public void UpdateLocation(LocationPOCO locationPOCOToBeUpdated)
        {
            MDMDataContext locationContext = new MDMDataContext();
            var locationToBeUpdated = LocationConverter.ConvertLocationPOCOToLocation(locationPOCOToBeUpdated);
            locationToBeUpdated.LocationId = GetLocationIdByName(locationToBeUpdated.LocationName);
            locationContext.Locations.Attach(locationToBeUpdated);
            locationContext.Refresh(RefreshMode.KeepCurrentValues, locationToBeUpdated);
            locationContext.SubmitChanges();

        }

        public int GetLocationIdByName(string locationName)
        {
            MDMDataContext locationContext = new MDMDataContext();
            var searchedLocationId = (from location in locationContext.Locations
                                      where location.LocationName == locationName
                                      select location.LocationId).FirstOrDefault();
            return searchedLocationId;
        }

        public string GetLocationNameById(int locationId)
        {
            MDMDataContext locationContext = new MDMDataContext();
            var searchedLocationName = (from location in locationContext.Locations
                                        where location.LocationId == locationId
                                        select location.LocationName).FirstOrDefault();
            return searchedLocationName;
        }
    }
}
