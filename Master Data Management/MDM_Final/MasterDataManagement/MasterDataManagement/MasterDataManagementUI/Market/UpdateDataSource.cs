using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using DataAccessLayer.DAL;
using DataAccessLayer.Interfaces;

namespace MasterDataManagementUI.Market
{
    class UpdateDataSource : INotifyPropertyChanged
    {
        string marketName;
        private ObservableCollection<string> _commodityTypeNames;
        ObservableCollection<string> commodityTypeNameList = new ObservableCollection<string>();
        ICommodityTypeDAO commodityTypeDAO = new CommodityTypeDAO();
        IMarketDAO marketDAO = new MarketDAO();
        #region INotifyPropertyChanged Members
        public UpdateDataSource(String marketName)
        {
            this.marketName = marketName;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        ObservableCollection<string> LoadCommodityTypeNames()
        {
            var commodityTypePOCOList = commodityTypeDAO.GetAllCommodityTypes();
            foreach (var item in commodityTypePOCOList)
            {
                commodityTypeNameList.Add(item.CommodityTypeName);
            }
            return commodityTypeNameList;
        }


        public ObservableCollection<string> CommodityTypeNames
        {
            get
            {
                _commodityTypeNames = LoadCommodityTypeNames();
                return _commodityTypeNames;
            }
        }


        private ObservableCollection<string> _selectedAllCommodityTypeNames;
        public ObservableCollection<string> SelectedCommodityTypeNames
        {
            get
            {
               // _selectedAllCommodityTypeNames = null;
                if (_selectedAllCommodityTypeNames == null)
                {
                    _selectedAllCommodityTypeNames = new ObservableCollection<string>();
                    
                    IEnumerable<string> selectedCommodityNames = marketDAO.GetAllCommodityTypeNamesByMarketName(marketName);//
                    ObservableCollection<string> myList = new ObservableCollection<string>();
                    foreach (var item in selectedCommodityNames)
                    {
                        myList.Add(item);

                    }
                     //selectedAllCommodityTypeNames = 
                    
                    _selectedAllCommodityTypeNames = myList;
                    
                   
                    //_selectedAllCommodityTypeNames.Add("test");
                    
                    

                    SelectedCommodityTypeNamesText = WriteSelectedAnimalsString(_selectedAllCommodityTypeNames);
                    _selectedAllCommodityTypeNames.CollectionChanged +=
                        (s, e) =>
                        {
                            SelectedCommodityTypeNamesText = WriteSelectedAnimalsString(_selectedAllCommodityTypeNames);
                            OnPropertyChanged("SelectedCommodityTypeNames");
                        };
                }
                return _selectedAllCommodityTypeNames;
            }
            set
            {
                _selectedAllCommodityTypeNames = value;
            }
        }

        public string SelectedCommodityTypeNamesText
        {
            get { return _selectedAnimalsText; }
            set
            {
                _selectedAnimalsText = value;
                OnPropertyChanged("SelectedCommodityTypeNamesText");
            }
        } string _selectedAnimalsText;


        private static string WriteSelectedAnimalsString(IList<string> list)
        {
            if (list.Count == 0)
                return String.Empty;

            StringBuilder builder = new StringBuilder(list[0]);

            for (int i = 1; i < list.Count; i++)
            {
                builder.Append(", ");
                builder.Append(list[i]);
            }

            return builder.ToString();
        }
    }
}
