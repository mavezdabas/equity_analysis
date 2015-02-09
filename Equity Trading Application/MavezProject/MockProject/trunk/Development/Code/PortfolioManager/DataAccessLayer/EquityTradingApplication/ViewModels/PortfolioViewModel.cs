using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DataAccessLayer;
using AutoMapper;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using EquityTradingApplication.Helpers;
using System.Windows;
using log4net.Config;
using log4net;
using EquityTradingApplication.ApplicationHelper;
using System.Windows.Controls;
using EquityTradingApplication.Converters;
using System.Reflection;
using System.Diagnostics;
using System.Timers;
using System.ServiceModel;
using AutoAllocationService;


namespace EquityTradingApplication.ViewModels
{


    public class PortfolioViewModel : ViewModelBase, SecurityMarketServiceReference.ISecurityMarketPriceCallback
    {
        public PortfolioViewModel()
        {

        }
        private ExceptionHandler ex;
        private IPortfolioDAL dalObject;
        ClientModel clientModel;
        IModelDialogService dialogService;
        private OrderViewModel orderViewModel;

        public event Action graphEvent;
        public event Action allEvent;
        public event Action newEvent;

        Timer timer;
        Random r;

        InstanceContext ctx;

        EnumRadioButtonState stateOfRadioButton;

        public event Action switchList;

        public ObservableCollection<OrderViewModel> TotalOrders { get; set; }

        SecurityMarketServiceReference.SecurityMarketPriceClient obj;

        public List<Security> securities { get; set; }

        public ObservableCollection<OrderViewModel> NewList { get; set; }
        public ObservableCollection<OrderViewModel> OpenList { get; set; }

        //  public ObservableCollection<DetailsForPM> SearchList { get; set; }

        public ObservableCollection<OrderModel> OrderUpdatedList { get; set; }
        //  public ObservableCollection<OrderModel> OrderDeletedList { get; set; }
        public ObservableCollection<OrderViewModel> OrderViewList { get; set; }

        public PortfolioViewModel(ClientModel c)
        {
            timer = new System.Timers.Timer(7000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;

            r = new Random();

            stateOfRadioButton = EnumRadioButtonState.All;

            RadioAllButton = true;
            Mapper.CreateMap<Order, OrderModel>();
            Mapper.CreateMap<OrderModel, Order>();
            clientModel = c;
            OrderViewList = new ObservableCollection<OrderViewModel>();
            OrderUpdatedList = new ObservableCollection<OrderModel>();
            // OrderDeletedList = new ObservableCollection<OrderModel>();
            dalObject = new PortfolioDAL();
            dialogService = new ModelDialogService();

            NewList = new ObservableCollection<OrderViewModel>();
            OpenList = new ObservableCollection<OrderViewModel>();

            TotalOrders = new ObservableCollection<OrderViewModel>();
            try
            {
                LoadAllOrders();
            }
            catch (NullReferenceException e)
            {
                new ExceptionHandler(codes.NullCode);
            }

            // MessageBox.Show("jghilu");
            // LoadSecurityName();
            XmlConfigurator.Configure();
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Debug("Welcome to Log4Net by DOTNET BATCH");

            //securities = dalObject.GetAllSecurities();

             ctx = new InstanceContext(this);
            obj = new SecurityMarketServiceReference.SecurityMarketPriceClient(ctx);
            obj.GetMarketPrice();

            //MessageBox.Show("BEFORE FETCH");

            Fetch();

        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Fetch();

        }

        private void Fetch()
        {
            
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                //Call the method of the security and get the list of securities
                obj.GetMarketPrice();
                RePopulate();

            }));
        }

        private bool radioNewButton;

        public bool RadioNewButton
        {
            get { return radioNewButton; }
            set { radioNewButton = value; }
        }

        private bool radioOpenButton;

        public bool RadioOpenButton
        {
            get { return radioOpenButton; }
            set { radioOpenButton = value; }
        }


        private bool radioAllButton;

        public bool RadioAllButton
        {
            get { return radioAllButton; }
            set { radioAllButton = value; }
        }


        private bool sendBtnEnabled;

        public bool SendBtnEnabled
        {
            get { return sendBtnEnabled; }
            set
            {
                sendBtnEnabled = value;
                RaisePropertyChanged("SendBtnEnabled");
            }
        }

        private OrderViewModel selectedItem;
        public OrderViewModel SelectedItem
        {
            get
            {

                return selectedItem;
            }
            set
            {
                selectedItem = value;


                RaisePropertyChanged("SelectedItem");
            }
        }

        public void LoadAllOrders()
        {
            if (clientModel != null)
            {

                TotalOrders.Clear();
                OrderUpdatedList.Clear();
                var portfolio = dalObject.GetPortfolioByClientID(clientModel.ClientID);
                ApplicationState.SetValue("portfolioId", portfolio.PortfolioID);
                var orders = dalObject.GetAllOrdersByPortfolioID(portfolio.PortfolioID);

                foreach (var item in orders)
                {
                    //OrderList.Add(Mapper.Map<Order, OrderModel>(item));
                    //orderModel = new OrderModel();
                    // orderModel.OrderID = item.OrderID;
                    // orderModel.Side = item.Side;
                    // orderModel.SecurityID = item.SecurityID;
                    // String s = dalObject.GetSecurityNameByID(item.SecurityID);
                    //SecurityName = s;
                    orderViewModel = new OrderViewModel();
                    orderViewModel.OrderID = item.OrderID;
                    orderViewModel.Side = item.Side;
                    orderViewModel.TotalQuantity = item.TotalQuantity;
                    orderViewModel.OpenQuantity = item.OpenQuantity;
                    orderViewModel.StopPrice = item.StopPrice;
                    orderViewModel.LimitPrice = item.LimitPrice;
                    orderViewModel.Notes = item.Notes;
                    orderViewModel.Notify = item.Notify;
                    orderViewModel.SecurityID = item.SecurityID;
                    orderViewModel.OrderType = item.OrderType;
                    orderViewModel.OrderQualifier = item.OrderQualifier;
                    orderViewModel.AccountType = item.AccountType;
                    orderViewModel.StatusID = item.StatusID;


                    orderViewModel.SecurityName = dalObject.GetSecurityNameByID(item.SecurityID);
                    var securityObj = dalObject.GetSecurityByID(item.SecurityID);
                    orderViewModel.Symbol = securityObj.SecuritySymbol;
                    orderViewModel.StatusName = dalObject.GetStatusNameByID(item.StatusID);
                    TotalOrders.Add(orderViewModel);
                    OrderUpdatedList.Add(Mapper.Map<Order, OrderModel>(item));
                    //   OrderDeletedList.Add(Mapper.Map<Order,OrderModel>(item));
                }
            }


            OrderViewList.Clear();
            foreach (var item in TotalOrders)
            {
                OrderViewList.Add(item);
            }

        }

        private string searchText = null;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        //private int orderID=1;
        public int OrderID
        {
            get { return orderViewModel.OrderID; }
            set
            {
                orderViewModel.OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        public string Side
        {
            get
            {
                return orderViewModel.Side;
            }
            set
            {
                orderViewModel.Side = value;

                RaisePropertyChanged("Side");
            }
        }

        //public int SecurityID
        //{
        //    get {
        //        MessageBox.Show(SecurityID.ToString());
        //        return orderModel.SecurityID; }
        //    set { orderModel.SecurityID = value;
        //    RaisePropertyChanged("SecurityID");

        //    }
        //}



        //private string security;
        public string SecurityName
        {
            get
            {
                return orderViewModel.SecurityName;
            }
            set
            {
                orderViewModel.SecurityName = value;
                RaisePropertyChanged("SecurityName");
            }
        }

        public Nullable<decimal> MarketPrice
        {
            get
            {
                return orderViewModel.MarketPrice;
            }
            set
            {
                orderViewModel.MarketPrice = value;
                RaisePropertyChanged("MarketPrice");
            }
        }


        public Nullable<decimal> Position
        {
            get
            {
                return orderViewModel.Position;
            }
            set
            {
                orderViewModel.Position = value;
                RaisePropertyChanged("Position");
            }
        }

        public string StatusName
        {
            get
            {
                return orderViewModel.StatusName;
            }
            set
            {
                orderViewModel.StatusName = value;
                RaisePropertyChanged("StatusName");
            }
        }
        //private void LoadSecurityName()
        //{

        //   security = dalObject.GetSecurityNameByID(SecurityID);
        //}

        public List<String> Strings { get; set; }

        private ICommand openCreateOrd;
        public ICommand OpenCreateOrder
        {
            get
            {
                if (openCreateOrd == null)
                    openCreateOrd = new RelayCommand(p => OpenCreate());
                return openCreateOrd;
            }

        }

        private void OpenCreate()
        {
            //if (RadioNewButton == true)
            //{
            //    dialogService.ShowDialog<CreateOrderViewModel>(ViewType.CreateOrderView, null, () => LoadAllOrders());
            //}
            //else if (RadioOpenButton == true)
            //{
            //    dialogService.ShowDialog<CreateOrderViewModel>(ViewType.CreateOrderView, null, () => LoadAllOrders());
            //}
            //else
            //{
            //    if (RadioAllButton == true)
            //        dialogService.ShowDialog<CreateOrderViewModel>(ViewType.CreateOrderView, null, () => LoadAllOrders());
            //}

            try
            {
                dialogService.ShowDialog<CreateOrderViewModel>(ViewType.CreateOrderView, null, () => LoadAllOrders());
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }

        }

        private ICommand newCommand;
        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                    newCommand = new RelayCommand(p => New());
                return newCommand;
            }

        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(p => Delete());
                return deleteCommand;
            }

        }

        private ICommand openCommand;
        public ICommand OpenCommand
        {
            get
            {
                if (openCommand == null)
                    openCommand = new RelayCommand(p => Open());
                return openCommand;
            }

        }

        private ICommand allCommand;
        public ICommand AllCommand
        {
            get
            {
                if (allCommand == null)
                    allCommand = new RelayCommand(p => All());
                return allCommand;
            }

        }

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(p => Search());
                return searchCommand;
            }
        }

        private ICommand sendCommand;
        public ICommand SendCommand
        {
            get
            {
                if (sendCommand == null)
                    sendCommand = new RelayCommand(p => Send());
                return sendCommand;
            }
        }

        private void Send()
        {
            try
            {
                int count = 0;

                //  for (int i=0, j = 0; i < OrderViewList.Count; i++,j++)


                foreach (var item in OrderViewList)
                {

                    foreach (var item1 in OrderUpdatedList)
                    {

                        if (item.IsSelected == true && item.OrderID == item1.OrderID)
                        {
                            item.StatusName = "OPEN";
                            int id = dalObject.GetStatusIdByName(item.StatusName);
                            item1.StatusID = id;
                            dalObject.UpdateOrder(Mapper.Map<OrderModel, Order>(item1));
                            count++;
                        }
                    }

                }
                // New();

                //    LoadAllOrders();
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.SendException);
            }


        }

        private void Search()
        {
            try
            {
                stateOfRadioButton = EnumRadioButtonState.Search;
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private ICommand openGraph;
        public ICommand OpenGraph
        {
            get
            {
                if (openGraph == null)
                    openGraph = new RelayCommand(p => OpenGraphWindow());
                return openGraph;
            }
            set { openGraph = value; }
        }

        private void OpenGraphWindow()
        {
            //GraphViewModel graph = new GraphViewModel();
            try
            {
                dialogService.ShowDialog<GraphViewModel>(ViewType.GraphView, null, null);
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private ICommand viewOrderCommand;
        public ICommand ViewOrderCommand
        {
            get
            {
                if (viewOrderCommand == null)
                    viewOrderCommand = new RelayCommand(p => ViewOrder());
                return viewOrderCommand;
            }
        }

        private void ViewOrder()
        {
            try
            {
                OrderModel orderModel = new OrderModel()
                   {

                       OrderID = selectedItem.OrderID,
                       SecurityID = selectedItem.SecurityID,
                       Side = selectedItem.Side,
                       OrderType = selectedItem.OrderType,
                       OrderQualifier = selectedItem.OrderQualifier,
                       AccountType = selectedItem.AccountType,
                       OpenQuantity = selectedItem.OpenQuantity,
                       StopPrice = selectedItem.StopPrice,
                       LimitPrice = selectedItem.LimitPrice,
                       Notes = selectedItem.Notes,
                       Notify = selectedItem.Notify,
                       StatusID = selectedItem.StatusID
                   };

                ViewEquityOrderViewModel viewEquityOrderViewModel = new ViewEquityOrderViewModel(orderModel);
                dialogService.ShowDialog<ViewEquityOrderViewModel>(ViewType.ViewOrderView, viewEquityOrderViewModel, LoadAllOrders);
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private void Open()
        {

            try
            {
                stateOfRadioButton = EnumRadioButtonState.Open;
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private void All()
        {

            try
            {
                stateOfRadioButton = EnumRadioButtonState.All;
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private void New()
        {
            try
            {
                stateOfRadioButton = EnumRadioButtonState.New;
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        //     public Radio SelectedRadioButton { get; set; }

        //private Radio selectedRadioButton;

        //public Radio SelectedRadioButton
        //{
        //    get { return selectedRadioButton; }
        //    set { selectedRadioButton = value;
        //    RaisePropertyChanged("SelectedRadioButton");
        //    }
        //}

        public void RePopulate()
        {
            try
            {
                OrderViewList.Clear();
                //            LoadAllOrders();

                switch (stateOfRadioButton)
                {
                    case EnumRadioButtonState.All:

                        if (securities != null)
                        {
                            foreach (var order in TotalOrders)
                            {
                                foreach (var security in securities)
                                {
                                    if (order.SecurityID == security.SecurityID && order.StatusName == "EXECUTED")
                                    {
                                        if (security.MarketPrice < 0)
                                            security.MarketPrice = security.MarketPrice * (-1);

                                        order.MarketPrice = security.MarketPrice + r.Next(-50,50);
                                        order.LastTradedPrice = security.LastTradedPrice;
                                        order.Position = (order.MarketPrice - order.LastTradedPrice) * (order.TotalQuantity - order.OpenQuantity);
                                        OrderViewList.Add(order);
                                    }
                                    else if (order.SecurityID == security.SecurityID)
                                    {
                                        if (security.MarketPrice < 0)
                                            security.MarketPrice = security.MarketPrice * (-1);

                                        order.MarketPrice = security.MarketPrice + r.Next(-50, 50);
                                        order.LastTradedPrice = security.LastTradedPrice;
                                        //order.Position = (order.MarketPrice - order.LastTradedPrice) * (order.TotalQuantity - order.OpenQuantity);
                                        OrderViewList.Add(order);
                                    }
                                }
                            }
                        }
                        else
                        {
                            LoadAllOrders();
                        }
                        break;

                    case EnumRadioButtonState.New:

                        if (securities != null)
                        {

                            foreach (var order in TotalOrders)
                            {
                                foreach (var security in securities)
                                {
                                    if (order.SecurityID == security.SecurityID && order.StatusName == "NEW")
                                    {
                                        if (security.MarketPrice < 0)
                                            security.MarketPrice = security.MarketPrice * (-1);

                                        order.MarketPrice = security.MarketPrice + r.Next(-50, 50);
                                        order.LastTradedPrice = security.LastTradedPrice;
                                        //    order.Position = (order.MarketPrice - order.LastTradedPrice) * (order.TotalQuantity - order.OpenQuantity);
                                        OrderViewList.Add(order);
                                    }

                                }
                            }
                        }
                        break;

                    case EnumRadioButtonState.Open:

                        if (securities != null)
                        {

                            foreach (var order in TotalOrders)
                            {
                                foreach (var security in securities)
                                {
                                    if (order.SecurityID == security.SecurityID && order.StatusName == "OPEN")
                                    {
                                        if (security.MarketPrice < 0)
                                            security.MarketPrice = security.MarketPrice * (-1);

                                        order.MarketPrice = security.MarketPrice + r.Next(-50, 50);
                                        order.LastTradedPrice = security.LastTradedPrice;
                                        // order.Position = (order.MarketPrice - order.LastTradedPrice) * (order.TotalQuantity - order.OpenQuantity);
                                        OrderViewList.Add(order);
                                    }
                                }
                            }
                        }

                        break;

                    case EnumRadioButtonState.Search:

                        foreach (var item in TotalOrders)
                        {
                            if (SearchText == item.SecurityName)
                            {
                                OrderViewList.Add(item);
                            }
                        }
                        break;


                    default:
                        break;
                }

            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }
        }

        private void Delete()
        {
            try
            {

                ObservableCollection<OrderViewModel> listAllOrders = new ObservableCollection<OrderViewModel>();
                ObservableCollection<OrderModel> listAllUpdatedOrders = new ObservableCollection<OrderModel>();

                listAllOrders = OrderViewList;
                listAllUpdatedOrders = OrderUpdatedList;
                MessageBoxResult result = dialogService.MessageResultAlert("Are you sure you want to delete the order(s)?");
                if (result == MessageBoxResult.Yes)
                {

                    foreach (var item in OrderViewList)
                    {
                        foreach (var item1 in OrderUpdatedList)
                        {
                            if (item.IsSelected == true && item.OrderID == item1.OrderID)
                            {


                                dalObject.DeleteOrder(Mapper.Map<OrderModel, Order>(item1));



                                //   LoadAllOrders();
                                //    count++;
                            }
                        }
                    }
                }


                if (RadioNewButton == true)
                {
                    New();
                    LoadAllOrders();
                }

                if (RadioOpenButton == true)
                {
                    Open();
                    LoadAllOrders();
                }

                if (RadioAllButton == true)
                {
                    All();
                    LoadAllOrders();
                }
            }
            catch (Exception)
            {

                ex = new ExceptionHandler(codes.GenericException);
            }

        }

        ////public void SendResult(List<SecurityMarketServiceReference.SecurityMarketPriceSecurityForClient> result)
        //    public void SendResult(List<SecurityMarketServiceReference.Security> result)
        //{
        //    // securities.Clear();


       
        //}


            public void SendResult(SecurityMarketPrice.SecurityForClient[] result)
            {
                try
                {
                    securities = new List<Security>();

                    foreach (var item in result)
                    {
                        if (item.MarketPrice == null)
                        {
                            item.MarketPrice = 0;
                        }

                        securities.Add(new Security()
                        {
                            SecurityID = item.SecurityID,
                            SecurityName = item.SecurityName,
                            MarketPrice = item.MarketPrice.Value,
                            LastTradedPrice = item.LastTradedPrice

                        });
                    }
                }
                catch (Exception)
                {

                    ex = new ExceptionHandler(codes.GenericException);
                }
            }
    }
}



