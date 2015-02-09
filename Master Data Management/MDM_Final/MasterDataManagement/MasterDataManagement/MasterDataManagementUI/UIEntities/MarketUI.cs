using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CommonContracts;

namespace MasterDataManagement.UIEntities
{

    public class MarketUI : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MarketUI()
        {

        }

        public MarketUI(string marketNameUI, int locationIdUI, int currencyIdUI, DateTime startDateUI, DateTime? endDateUI)
        {

            MarketName = marketNameUI;
            LocationId = locationIdUI;
            CurrencyId = currencyIdUI;
            StartDate = startDateUI;
            EndDate = endDateUI;
            LastUpdatedBy = UserSession.UserId;
            //LastUpdatedBy = 2;
            LastUpdatedDate = DateTime.Now;
            IsCurrentVersion = true;
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private string marketName;
        public string MarketName
        {
            get { return marketName; }
            set
            {
                marketName = value;
                RaisePropertyChanged("MarketName");
            }
        }
        private int locationId;
        public int LocationId
        {
            get { return locationId; }
            set
            {
                locationId = value;
                RaisePropertyChanged("LocationId");
            }
        }
        private int currencyId;
        public int CurrencyId
        {
            get { return currencyId; }
            set
            {
                currencyId = value;
                RaisePropertyChanged("CurrencyId");
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        private Nullable<DateTime> endDate;
        public Nullable<DateTime> EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private int version;
        public int Version
        {
            get { return version; }
            set
            {
                version = value;
                RaisePropertyChanged("Version");
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
        private bool isCurrentVersion;
        public bool IsCurrentVersion
        {
            get { return isCurrentVersion; }
            set
            {
                isCurrentVersion = value;
                RaisePropertyChanged("IsCurrentVersion");
            }
        }
        public string LocationName { get; set; }
        public string Currency { get; set; }
        public string CommodityNames { get; set; }
    }
}
