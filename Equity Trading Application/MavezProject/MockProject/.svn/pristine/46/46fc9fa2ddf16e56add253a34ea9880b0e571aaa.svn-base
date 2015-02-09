using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MasterDataManagement.UIEntities
{
    public class MarketCommodityMapUI:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MarketCommodityMapUI()
        {

        }

        public MarketCommodityMapUI(int marketIdUI, int commodityTypeIdUI)
        {
            MarketId = marketIdUI;
            CommodityTypeId = commodityTypeIdUI;
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private int marketCommodityMapId;
        public int MarketCommodityMapId
        {
            get { return  marketCommodityMapId; }
            set
            {
                marketCommodityMapId = value;
                RaisePropertyChanged("MarketCommodityMapId");
            }
        }

        private int marketId;
        public int MarketId
        {
            get { return marketId; }
            set
            {
                marketId = value;
                RaisePropertyChanged("MarketId");
            }
        }

        private int commodityTypeId;
        public int CommodityTypeId
        {
            get { return commodityTypeId; }
            set
            {
                commodityTypeId = value;
                RaisePropertyChanged("CommodityTypeId");
            }
        }
    }
}
