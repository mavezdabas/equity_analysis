using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonContracts
{
    public class CurrencyPOCO
    {
        //public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string Description { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
