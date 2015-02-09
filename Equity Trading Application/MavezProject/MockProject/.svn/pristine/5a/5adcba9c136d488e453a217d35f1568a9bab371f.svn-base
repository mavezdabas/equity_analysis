using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterDataManagement.UIEntities;
using CommonContracts;


namespace MasterDataMangementUI.Converters
{
    class LocationPOCOConverter
    {
        internal static LocationUI ConvertLocationPOCOToLocationUI(LocationPOCO location)
        {
            return new LocationUI()
            {

                LocationName = location.LocationName,
                Description = location.Description,
                LastUpdatedBy = location.LastUpdatedBy,
                LastUpdatedDate = location.LastUpdatedDate.Value
            };
        }

        internal static LocationPOCO ConvertLocationUIToLocationPOCO(LocationUI location)
        {
            return new LocationPOCO()
            {

                LocationName = location.LocationName,
                Description = location.Description,
                LastUpdatedBy = location.LastUpdatedBy,
                LastUpdatedDate = location.LastUpdatedDate
            };
        }
        internal static IEnumerable<LocationPOCO> ConvertLocationListUIToLocationPOCOList(IEnumerable<LocationUI> locationListUI)
        {
            List<LocationPOCO> locationPOCOList = new List<LocationPOCO>();
            foreach (var location in locationListUI)
            {
                locationPOCOList.Add(ConvertLocationUIToLocationPOCO(location));
            }

            return locationPOCOList;
        }

        internal static IEnumerable<LocationUI> ConvertLocationPOCOListToLocationListUI(IEnumerable<LocationPOCO> locationPOCOList)
        {
            List<LocationUI> locationListUI = new List<LocationUI>();
            foreach (var location in locationPOCOList)
            {
                locationListUI.Add(ConvertLocationPOCOToLocationUI(location));
            }
            return locationListUI;
        }
    }
}
