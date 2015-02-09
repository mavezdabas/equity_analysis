using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonContracts
{
    public class MarketCommodityMapPOCO
    {
        public int MarketCommodityMapId { get; set; }

        public int MarketId{get;set;}

        public int CommodityTypeId{get;set;}
    }
}
