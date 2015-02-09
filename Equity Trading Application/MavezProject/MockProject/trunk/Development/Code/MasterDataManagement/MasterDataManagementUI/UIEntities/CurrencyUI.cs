using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using CommonContracts;

namespace MasterDataManagement.UIEntities
{
   
       public class CurrencyUI : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;
            public CurrencyUI()
            {

            }
            public CurrencyUI(String currencyNameUI, String currencyDescriptionUI)
            {
                currencyName = currencyNameUI;
                description = currencyDescriptionUI;
                //lastUpdatedBy = UserSession.UserId;
                //lastUpdatedBy = 1;
                //LastUpdatedDate = DateTime.Now;
            }

            private void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
            }
            private string currencyName;

            public string CurrencyName
            {
                get { return currencyName; }
                set
                {
                    currencyName = value;
                    RaisePropertyChanged("CurrencyName");
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

