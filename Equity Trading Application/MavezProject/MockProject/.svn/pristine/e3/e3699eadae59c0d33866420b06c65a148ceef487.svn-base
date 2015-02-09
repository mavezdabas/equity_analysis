using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MasterDataManagement.UIEntities
{
   
        public class LocationUI : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public LocationUI()
            {

            }
            public LocationUI(String locationName,String locationDescription)
            {
                LocationName = locationName;
                Description = locationDescription;
                ////LastUpdatedBy = UserSession.UserId;
                //LastUpdatedBy = 1;
                //LastUpdatedDate = DateTime.Now;


            }
            private void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
            }

            private string locationName;
            public string LocationName
            {
                get { return locationName; }
                set
                {
                    locationName = value;
                    RaisePropertyChanged("LocationName");
                }
            }

            private string description;
            public string Description
            {
                get { return description; }
                set
                {
                   description = value;
                    RaisePropertyChanged("Description");
                }
            }

            private int lastUpdatedBy;
            public int LastUpdatedBy
            {
                get { return lastUpdatedBy; }
                set
                {
                    lastUpdatedBy = value;
                    RaisePropertyChanged("LastUpdatedBy");
                }
            }
            private DateTime lastUpdatedDate;
            public DateTime LastUpdatedDate
            {
                get { return lastUpdatedDate; }
                set 
                {
                    lastUpdatedDate = value;
                    RaisePropertyChanged("LastUpdatedDate");
                }
            }
        }
    }

