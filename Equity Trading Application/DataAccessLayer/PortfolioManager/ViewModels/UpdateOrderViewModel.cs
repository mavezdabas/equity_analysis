using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManagerWindow.Helpers;
using DataAccessLayer;
using System.Windows;
using EquityTradingApplication.Commands;
using System.Windows.Input;

namespace PortfolioManager.ViewModels
{
    public class UpdateOrderViewModel : ViewModelBase
    {
        PortfolioDAL dalObject;

        private bool buy;
        public bool Buy
        {
            get { return buy; }
            set
            {
                buy = value;
                RaisePropertyChanged("Buy");
            }
        }

        private bool sell;
        public bool Sell
        {
            get { return sell; }
            set
            {
                sell = value;
                RaisePropertyChanged("Sell");

            }
        }

        private bool gtc;
        public bool GTC
        {
            get { return gtc; }
            set
            {
                gtc = value;
                RaisePropertyChanged("GTC");
            }
        }

        private bool gtd;
        public bool GTD
        {
            get { return gtd; }
            set
            {
                gtd = value;
                RaisePropertyChanged("GTD");

            }
        }

        private bool limitEnabled;
        public bool LimitEnabled
        {
            get { return limitEnabled; }
            set
            {
                limitEnabled = value;
                RaisePropertyChanged("LimitEnabled");
            }
        }

        private bool stopEnabled;
        public bool StopEnabled
        {
            get { return stopEnabled; }
            set
            {
                stopEnabled = value;
                RaisePropertyChanged("StopEnabled");
            }
        }

        public UpdateOrderViewModel()
        {
            dalObject = new PortfolioDAL();
            OrderId = dalObject.GetMaxOrderID().ToString();
            Symbols = dalObject.GetAllSymbols();
            Buy = true;
            GTC = true;
            TypeOfOrders = new List<string>() { 
            "Market","Stop","Limit","StopLimit"
            };
            Status = "New";
            LimitEnabled = false;
            StopEnabled = false;
            symbolSelected = "AAPL";
        }

        private string orderId;
        public string OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                RaisePropertyChanged("OrderId");
            }
        }

        private List<string> typeOfOrders;
        public List<string> TypeOfOrders
        {
            get { return typeOfOrders; }
            set { typeOfOrders = value; }
        }

        private string ownedQuantity;
        public string OwnedQuantity
        {
            get { return ownedQuantity; }
            set
            {
                ownedQuantity = value;
                RaisePropertyChanged("OwnedQuantity");
            }
        }

        private string quantity;
        public string Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        private string limitPrice;
        public string LimitPrice
        {
            get { return limitPrice; }
            set
            {
                limitPrice = value;
                RaisePropertyChanged("LimitPrice");
            }
        }

        private string stopPrice;
        public string StopPrice
        {
            get { return stopPrice; }
            set
            {
                stopPrice = value;
                RaisePropertyChanged("StopPrice");
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged("Status");
            }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        private List<string> symbols;
        public List<string> Symbols
        {
            get { return symbols; }
            set { symbols = value; }
        }

        private string selectedType;

        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                RaisePropertyChanged("SelectedValueType");
                SelectedOrderType();
            }
        }

        private string symbolSelected;
        public string SymbolSelected
        {
            get { return symbolSelected; }
            set
            {
                symbolSelected = value;
                RaisePropertyChanged("SymbolSelected");

            }
        }

        private ICommand buyCommand;
        public ICommand BuyCommand
        {
            get
            {
                if (buyCommand == null)
                    buyCommand = new RelayCommand(p => BuySelected());

                return buyCommand;
            }

        }

        private ICommand sellCommand;
        public ICommand SellCommand
        {
            get
            {
                if (sellCommand == null)
                    sellCommand = new RelayCommand(p => SellSelected());

                return sellCommand;
            }

        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(p => Save());
                return saveCommand;
            }

        }

        private ICommand gtcCommand;
        public ICommand GtcCommand
        {
            get
            {
                if (gtcCommand == null)
                    gtcCommand = new RelayCommand(p => GtcSelected());

                return gtcCommand;
            }

        }

        private ICommand gtdCommand;
        public ICommand GtdCommand
        {
            get
            {
                if (gtdCommand == null)
                    gtdCommand = new RelayCommand(p => GtdSelected());

                return gtdCommand;
            }

        }

        private void BuySelected()
        {
            Buy = true;
        }

        private void SellSelected()
        {
            Sell = true;
        }

        private void GtcSelected()
        {
            GTC = true;
        }

        private void GtdSelected()
        {
            GTD = true;
        }

        private void SelectedOrderType()
        {
            if (SelectedType == "StopLimit" && Status == "New")
            {
                LimitEnabled = true;
                StopEnabled = true;
            }
            else if (SelectedType == "Limit" && Status=="New")
            {
                LimitEnabled = true;
            }
            else if (SelectedType == "Stop" && Status=="New")
            {
                StopEnabled = true;
            }

        }

        private void Save()
        {
            int orderId = int.Parse((OrderId));
            Order order = dalObject.GetOrderByOrderId(orderId);
            order.Quantity = int.Parse(Quantity);
            dalObject.UpdateOrder(order);
        }
    }
}
