using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonContracts    
{
    public class CommodityTypePOCO
    {
        //public int CommodityTypeId{get;set;}

        public string CommodityTypeName { get; set; }

        public string CommodityClass { get; set; }

        public DateTime? StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public int Version { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public bool IsCurrentVersion { get; set; }

    }
}
