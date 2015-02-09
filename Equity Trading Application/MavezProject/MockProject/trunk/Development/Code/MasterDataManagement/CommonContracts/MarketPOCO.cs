using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonContracts
{
    public class MarketPOCO
    {
       

        public String MarketName { get; set; }
        public DateTime? StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public int Version { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsCurrentVersion { get; set; }
        public int LocationId { get; set; }
        public int CurrencyId { get; set; }
        
    }
}
