using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DBML;
using CommonContracts;


namespace DataAccessLayer.Converters
{
    class LocationConverter
    {
        
        internal static Location ConvertLocationPOCOToLocation(LocationPOCO location)
        {
            return new Location()
            {
                
                LocationName = location.LocationName,
                Description = location.Description,
                LastUpdatedBy=location.LastUpdatedBy,
               LastUpdatedDate = location.LastUpdatedDate
            };
        }

        internal static LocationPOCO ConvertLocationToLocationPOCO(Location location)
        {
            return new LocationPOCO()
            {
                
                LocationName = location.LocationName,
                Description = location.Description,
                LastUpdatedBy = location.LastUpdatedBy,
                LastUpdatedDate= location.LastUpdatedDate
            };
        }
        internal static IEnumerable<LocationPOCO> ConvertLocationListToLocationPOCOList(IEnumerable<Location> locationList)
        {
            List<LocationPOCO> locationPOCOList=new List<LocationPOCO>();
            foreach (var location in locationList)
            {
                locationPOCOList.Add(ConvertLocationToLocationPOCO(location));
            }
	
            return locationPOCOList;
        }

        internal static IEnumerable<Location> ConvertLocationPOCOToLocationList(IEnumerable<LocationPOCO> locationPOCOList)
        {
            List<Location> locationList = new List<Location>();
            foreach (var location in locationPOCOList)
            {
                locationList.Add(ConvertLocationPOCOToLocation(location));
            }
            return locationList;
        }
    }
    }

