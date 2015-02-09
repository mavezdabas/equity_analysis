using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;

namespace TestApp
{
    class DataSource : INotifyPropertyChanged
    {
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion

        private ObservableCollection<string> _commodityTypeNames = new ObservableCollection<string> 
        { "Cat", "Dog", "Bear", "Lion", "Mouse", "Horse", "Rat", "Elephant", "Kangaroo", "Lizard", "Snake", "Frog", "Fish", "Butterfly", "Human", "Cow", "Bumble Bee" };
        
        public ObservableCollection<string> CommodityTypeNames
        {
            get { return _commodityTypeNames; }
        }
        
       
        private ObservableCollection<string> _selectedAllCommodityTypeNames;
        public ObservableCollection<string> SelectedCommodityTypeNames
        {
            get
            {
                if (_selectedAllCommodityTypeNames == null)
                {
                    _selectedAllCommodityTypeNames = new ObservableCollection<string> ();
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
