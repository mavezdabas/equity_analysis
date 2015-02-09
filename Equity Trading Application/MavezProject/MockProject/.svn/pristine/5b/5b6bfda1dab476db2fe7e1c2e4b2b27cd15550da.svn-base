using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DAL;

namespace MasterDataManagement.UIEntities
{

    public class CommodityTypeUI : INotifyPropertyChanged
        //, IDataErrorInfo
    {
     
        public CommodityTypeUI()
        {
            

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private string commodityTypeName;
        public string CommodityTypeName
        {
            get { return commodityTypeName; }
            set
            {
                //if (string.IsNullOrEmpty(value))
                    //throw new Exception("Name is mandatory.");
                //cName = value;
                commodityTypeName = value;
                RaisePropertyChanged("CommodityTypeName");
            }
        }

        private string commodityClass;
        public string CommodityClass
        {
            get { return commodityClass; }
            set
            {
                commodityClass = value;
                RaisePropertyChanged("CommodityClass");
            }
        }

        private Nullable<DateTime> startDate;
        public Nullable<DateTime> StartDate
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


        private Nullable<DateTime> lastUpdatedDate;
        public Nullable<DateTime> LastUpdatedDate
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

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string result = null;



        //        if (columnName == "CommodityTypeName")
        //        {
        //            if (string.IsNullOrEmpty(this.commodityTypeName))
        //                result = "Name cannot be null";
        //        }

        //        return result;
        //    }
        //}

        //public string Error
        //{
        //    get
        //    { //throw new NotImplementedException();
        //        return null;

        //    }
        //}
    }
    }

