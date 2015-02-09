using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioManagerWindow.Helpers;
using PortfolioManager.Helpers;
using System.Collections.ObjectModel;
using PortfolioManager.Models;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using DataAccessLayer;

namespace PortfolioManager.ViewModels
{
    enum RadioState { New, Open, All, Search }

    public class MainWindowViewModel : ViewModelBase
    {
        private PortfolioDAL dalObject;
        IModelDialogService dialogService;
        Random r;
        RadioState state = RadioState.All;

        private readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
        public ObservableCollection<Quote> Quotes { get; set; }

        //List of orders from DAL
        private ObservableCollection<OrderModel> listFromDAL;
        public ObservableCollection<OrderModel> ListFromDAL
        {
            get { return listFromDAL; }
            set { listFromDAL = value; }
        }

        private GridFields  selectedItem;
        public GridFields  SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value;
            RaisePropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<AllData> allSecurities;
        public ObservableCollection<AllData> AllSecurities
        {
            get { return allSecurities; }
            set { allSecurities = value; }
        }

        private List<string> symbols;
        public List<string> Symbols
        {
            get { return symbols; }
            set { symbols = value; }
        }

        private ObservableCollection<PieChartData> listForPieChart;
        public ObservableCollection<PieChartData> ListForPieChart
        {
            get { return listForPieChart; }
            set { listForPieChart = value; }
        }

        private string high;
        public string High
        {
            get { return high; }
            set
            {
                high = value;
                RaisePropertyChanged("High");

            }
        }

        private decimal? currentPrice;
        public decimal? CurrentPrice
        {
            get { return currentPrice; }
            set
            {
                currentPrice = value;
                RaisePropertyChanged("CurrentPrice");
            }
        }

        private string low;
        public string Low
        {
            get { return low; }
            set
            {
                low = value;
                RaisePropertyChanged("Low");
            }

        }

        private string change;
        public string Change
        {
            get { return change; }
            set
            {
                change = value;
                RaisePropertyChanged("Change");
            }
        }

        private string changePercent;
        public string ChangePercent
        {
            get { return changePercent; }
            set
            {
                changePercent = value;
                RaisePropertyChanged("ChangePercent");
            }
        }

        private string stockExchange;
        public string StockExchange
        {
            get { return stockExchange; }
            set
            {
                stockExchange = value;
                RaisePropertyChanged("StockExchange");
            }
        }

        private string previousClose;
        public string PreviousClose
        {
            get { return previousClose; }
            set
            {
                previousClose = value;
                RaisePropertyChanged("PreviousClose");
            }
        }

        private string symbolSearched;
        public string SymbolSearched
        {
            get { return symbolSearched; }
            set
            {
                symbolSearched = value;
                RaisePropertyChanged("SymbolSearched");
            }
        }

        private string searchText = "AAPL";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        private string searchTextOrder = "AAPL";
        public string SearchTextOrder
        {
            get { return searchTextOrder; }
            set
            {
                searchTextOrder = value;
                RaisePropertyChanged("SearchTextOrder");
            }
        }

        private string pERatio;
        public string PERatio
        {
            get
            {
                return pERatio;
            }

            set
            {
                pERatio = value;
                RaisePropertyChanged("PERatio");

            }
        }

        private string ePS;

        public string EPS
        {
            get { return ePS; }
            set
            {
                ePS = value;
                RaisePropertyChanged("EPS");
            }
        }

        private bool flag;
        public bool Flag
        {
            get { return flag; }
            set
            {
                flag = value;
                RaisePropertyChanged("Flag");
            }
        }

        private ObservableCollection<GridFields> listToDisplay;
        public ObservableCollection<GridFields> ListToDisplay
        {
            get { return listToDisplay; }
            set { listToDisplay = value; }
        }

        private ImageBrush brushGraph;
        public ImageBrush BrushGraph
        {
            get { return brushGraph; }
            set { brushGraph = value; }
        }

        private ObservableCollection<ChartDetails> listForCharts;
        public ObservableCollection<ChartDetails> ListForCharts
        {
            get { return listForCharts; }
            set { listForCharts = value; }
        }

        private bool visibilityOfChart;
        public bool VisibilityOfChart
        {
            get { return visibilityOfChart; }
            set
            {
                visibilityOfChart = value;
                RaisePropertyChanged("VisibilityOfChart");
            }
        }

        private Visibility visibilityOfLabelPanel;
        public Visibility VisibilityOfLabelPanel
        {
            get { return visibilityOfLabelPanel; }
            set
            {
                visibilityOfLabelPanel = value;
                RaisePropertyChanged("VisibilityOfLabelPanel");
            }
        }

        private bool enableChartButton;
        public bool EnableChartButton
        {
            get { return enableChartButton; }
            set
            {
                enableChartButton = value;
                RaisePropertyChanged("EnableChartButton");
            }
        }

        //Dummy data

        //Commands

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

        private ICommand sendCommand;
        public ICommand SendCommand
        {
            get
            {
                if (sendCommand == null)
                    sendCommand = new RelayCommand(p => SendOrder());

                return sendCommand;
            }
        }

        private ICommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                if (createCommand == null)
                    createCommand = new RelayCommand(p => CreateOrder());

                return createCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(p => UpdateOrder());

                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(p => DeleteOrder());

                return deleteCommand;
            }
        }

        private ICommand oneDayCommand;
        public ICommand OneDayCommand
        {
            get
            {
                if (oneDayCommand == null)
                    oneDayCommand = new RelayCommand(p => OneDayGraph());
                return oneDayCommand;
            }

        }

        private ICommand fiveDayCommand;
        public ICommand FiveDayCommand
        {
            get
            {
                if (fiveDayCommand == null)
                    fiveDayCommand = new RelayCommand(p => FiveDayGraph());
                return fiveDayCommand;
            }

        }

        private ICommand threeMonthCommand;
        public ICommand ThreeMonthCommand
        {
            get
            {
                if (threeMonthCommand == null)
                    threeMonthCommand = new RelayCommand(p => ThreeMonthGraph());
                return threeMonthCommand;
            }

        }

        private ICommand sixMonthCommand;
        public ICommand SixMonthCommand
        {
            get
            {
                if (sixMonthCommand == null)
                    sixMonthCommand = new RelayCommand(p => SixMonthGraph());
                return sixMonthCommand;
            }

        }

        private ICommand oneYearCommand;
        public ICommand OneYearCommand
        {
            get
            {
                if (oneYearCommand == null)
                    oneYearCommand = new RelayCommand(p => OneYearGraph());
                return oneYearCommand;
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

        private ICommand searchCommandOrder;
        public ICommand SearchCommandOrder
        {
            get
            {
                if (searchCommandOrder == null)
                    searchCommandOrder = new RelayCommand(p => SearchOrder());

                return searchCommandOrder;
            }
        }

        private void Search()
        {
            listForCharts.Clear();

            if (SearchText != null && SearchText != "")
            {
                SymbolSearched = SearchText;

                EnableChartButton = true;

                Image image = new Image();
                if (SearchText != null)
                {
                    //confirm if it's a symbol or not
                    image.Source = new BitmapImage(new Uri("http://chart.finance.yahoo.com/c/3m/" + SearchText));
                    brushGraph.ImageSource = image.Source;
                }
                EPS = Quotes.First(q => q.Symbol == SearchText).EarningsShare.ToString();
                PERatio = Quotes.First(q => q.Symbol == SearchText).PeRatio.ToString();
                High = Quotes.First(q => q.Symbol == SearchText).DailyHigh.ToString();
                Low = Quotes.First(q => q.Symbol == SearchText).DailyLow.ToString();
                StockExchange = Quotes.First(q => q.Symbol == SearchText).StockExchange.ToString();
                PreviousClose = Quotes.First(q => q.Symbol == SearchText).PreviousClose.ToString();
                Change = Quotes.First(q => q.Symbol == SearchText).Change.ToString();
                ChangePercent = Quotes.First(q => q.Symbol == SearchText).ChangeInPercent.ToString();

                //PieChartData data = new PieChartData();
                //data.Name= "Volume";
                //data.Value = Quotes.First(q => q.Symbol == SearchText).Volume;

                List<PieChartData> pieChart = new List<PieChartData>()
               {
                 new PieChartData(){ Name= "Volume", Value=Quotes.First(q => q.Symbol == SearchText).Volume},
                 new PieChartData(){ Name= "AverageDailyVolume", Value=Quotes.First(q => q.Symbol == SearchText).AverageDailyVolume}
               };

                ListForPieChart.Clear();

                foreach (var item in pieChart)
                {
                    ListForPieChart.Add(item);
                }

                CurrentPrice = Quotes.First(q => q.Symbol == SearchText).PreviousClose + Quotes.First(q => q.Symbol == SearchText).Change;

                ListForCharts.Add(new ChartDetails() { NameOfStock = "YearlyHigh", NetPnL = Quotes.First(q => q.Symbol == SearchText).YearlyHigh });
                ListForCharts.Add(new ChartDetails() { NameOfStock = "YearlyLow", NetPnL = Quotes.First(q => q.Symbol == SearchText).YearlyLow });
                ListForCharts.Add(new ChartDetails() { NameOfStock = "ChangeFromYearlyHigh", NetPnL = Quotes.First(q => q.Symbol == SearchText).ChangeFromYearHigh });
                ListForCharts.Add(new ChartDetails() { NameOfStock = "ChangeFromYearlyLow", NetPnL = Quotes.First(q => q.Symbol == SearchText).ChangeFromYearLow });
            }

        }

        private void SearchOrder()
        {
            state = RadioState.Search;

            listToDisplay.Clear();
            List<Order> list = dalObject.GetAllOrders();

            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                if (stockSymbol == SearchTextOrder)
                {
                    listToDisplay.Add(new GridFields()
                    {
                        OrderID = item.OrderID,
                        Name = stockName,
                        Symbol = stockSymbol,
                        MarketPrice = marketPrice,
                        Status = statusName
                    });
                }
            }

        }

        private void OneYearGraph()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("http://chart.finance.yahoo.com/c/1y/" + SearchText));
            brushGraph.ImageSource = image.Source;
        }

        private void SixMonthGraph()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("http://chart.finance.yahoo.com/c/6m/" + SearchText));
            brushGraph.ImageSource = image.Source;
        }

        private void ThreeMonthGraph()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("http://ichart.finance.yahoo.com/c/3m/" + SearchText));
            brushGraph.ImageSource = image.Source;
        }

        private void FiveDayGraph()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("http://ichart.finance.yahoo.com/w?s=" + SearchText));
            brushGraph.ImageSource = image.Source;
        }

        private void OneDayGraph()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("http://ichart.yahoo.com/t?s=" + SearchText));
            brushGraph.ImageSource = image.Source;
        }

        public MainWindowViewModel()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("G:\\Resume\\DOCUMENTS\\DOCUMENTS\\REASON\\RAHANUMAamp.wav");

            string connectionString = "Server=storefileinfo.netne.net;Database=a3026020_JCdata;Uid:a3026020_sql1091;web1091;";


            // player.Load();
            //player.Play();
            //System.Media.SystemSounds.Beep.Play();

            ListForPieChart = new ObservableCollection<PieChartData>();
            listToDisplay = new ObservableCollection<GridFields>();
            Quotes = new ObservableCollection<Quote>();
            dialogService = new ModelDialogService();

            //Some example tickers
            Quotes.Add(new Quote("AAPL"));
            Quotes.Add(new Quote("MSFT"));
            Quotes.Add(new Quote("INTC"));
            Quotes.Add(new Quote("IBM"));
            Quotes.Add(new Quote("RVBD"));
            Quotes.Add(new Quote("AMZN"));
            Quotes.Add(new Quote("BIDU"));
            Quotes.Add(new Quote("SINA"));
            Quotes.Add(new Quote("THI"));
            Quotes.Add(new Quote("NVDA"));
            Quotes.Add(new Quote("AMD"));
            Quotes.Add(new Quote("DELL"));
            Quotes.Add(new Quote("WMT"));
            Quotes.Add(new Quote("GLD"));
            Quotes.Add(new Quote("SLV"));
            Quotes.Add(new Quote("V"));
            Quotes.Add(new Quote("ITC"));
            Quotes.Add(new Quote("MCD"));

            //getting the data from yahoo finance..!
            YahooStockEngine.Fetch(Quotes);

            //poll every 'x' seconds
            timer.Interval = new TimeSpan(0, 0, 60);
            timer.Tick += (o, e) => YahooStockEngine.Fetch(Quotes);
            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();

            brushGraph = new ImageBrush();
            allSecurities = new ObservableCollection<AllData>();
            listForCharts = new ObservableCollection<ChartDetails>();


            dalObject = new PortfolioDAL();
            r = new Random();

            symbols = new List<string>();
            symbols = dalObject.GetAllSymbols();

           
            foreach (var item in Quotes)
            {
                allSecurities.Add(new AllData() { 
                Name=item.Name,
                Symbol = item.Symbol,
                PreviousClose = item.PreviousClose,
                MarketPrice = item.PreviousClose+item.Change,
                Volume = item.Volume,
                Change = item.Change,
                ChangePercent = item.ChangePercent,
                });
            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            listToDisplay.Clear();
            allSecurities.Clear();
            //Stock s = new Stock();
            //s.StockID = 1;
            //s.StockSymbol = "AAPL";
            //s.StockName = "Apple";
            //s.MarketPrice = Quotes.First(q => q.Symbol == s.StockSymbol).Change + Quotes.First(q => q.Symbol == s.StockSymbol).PreviousClose+r.Next(-3,3);
            //dalObject.UpdateStock(s);

            List<Stock> stocks = dalObject.GetAllStocks();
            foreach (var item in stocks)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);
               // Quote q = Quotes.First(quote => quote.Symbol == stock.StockSymbol);
                //stock.MarketPrice = q.Change + q.PreviousClose;

                //Add other thing if required..
                dalObject.UpdateStock(stock);
            }


            List<Order> list = dalObject.GetAllOrders();


            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                switch (state)
                {
                    case RadioState.New:
                        if (dalObject.GetStatusByStatusId((int)item.StatusID) == "New")
                        {
                            listToDisplay.Add(new GridFields()
                            {
                                OrderID = item.OrderID,
                                Name = stockName,
                                Symbol = stockSymbol,
                                MarketPrice = marketPrice,
                                Status = statusName
                            });
                        }
                        break;

                    case RadioState.Open:
                        if (dalObject.GetStatusByStatusId((int)item.StatusID) == "Open")
                        {
                            listToDisplay.Add(new GridFields()
                            {
                                OrderID = item.OrderID,
                                Name = stockName,
                                Symbol = stockSymbol,
                                MarketPrice = marketPrice,
                                Status = statusName
                            });
                        }
                        break;

                    case RadioState.All:

                        listToDisplay.Add(new GridFields()
                        {
                            OrderID = item.OrderID,
                            Name = stockName,
                            Symbol = stockSymbol,
                            MarketPrice = marketPrice,
                            Status = statusName
                        });

                        break;

                    case RadioState.Search:

                        if (stockSymbol == SearchTextOrder)
                        {
                            listToDisplay.Add(new GridFields()
                            {
                                OrderID = item.OrderID,
                                Name = stockName,
                                Symbol = stockSymbol,
                                MarketPrice = marketPrice,
                                Status = statusName
                            });
                        }

                        break;

                    default:
                        break;

                }
            }

            // MessageBox.Show(dalObject.GetStockNameByOrderID(1));

            allSecurities.Clear();
            foreach (var item in Quotes)
            {
                allSecurities.Add(new AllData()
                {
                    Name = item.Name,
                    Symbol = item.Symbol,
                    MarketPrice = item.PreviousClose + item.Change,
                    Volume = item.Volume,
                    Change = item.Change,
                    ChangePercent = item.ChangePercent

                });
            }

            Search();

        }
    
        private void CreateOrder()
        {
            dialogService.ShowDialog<CreateOrderViewModel>(ViewType.CreateOrderView, null, null);
            Refresh();
        }

        private void UpdateOrder()
        {
            Order order = dalObject.GetOrderByOrderId(SelectedItem.OrderID);
            UpdateOrderViewModel vModel = new UpdateOrderViewModel();
            
            vModel.OrderId = order.OrderID.ToString();
            
            if (order.Side == "BUY")
                vModel.Buy = true;
            else
                vModel.Sell = true;
            vModel.OwnedQuantity = order.OwnedQuantity.ToString();
            vModel.Status = dalObject.GetStatusByStatusId((int)order.StatusID);

            vModel.SelectedType = order.Type;
            vModel.Quantity = order.Quantity.ToString();
            vModel.Notes = order.Notes;

            if (vModel.SelectedType == "StopLimit")
            {
                vModel.LimitEnabled = true;
                vModel.StopEnabled = true;
            }
            else if (vModel.SelectedType == "Limit")
            {
                vModel.LimitEnabled = true;
            }
            else if (vModel.SelectedType == "Stop")
            {
                vModel.StopEnabled = true;
            }

            if (order.Qualifier == "GTC")
                vModel.GTC = true;
            else
                vModel.GTD = true;

            dialogService.ShowDialog<UpdateOrderViewModel>(ViewType.UpdateOrderView, vModel, null);
            Refresh();    
        
        }

        private void DeleteOrder()
        {
            foreach (var item in listToDisplay)
            {
                if (item.IsSelected == true)
                    dalObject.DeleteOrder(dalObject.GetOrderByOrderId(item.OrderID));
            }

            Refresh();
        }

        private void SendOrder()
        {
            int count = 0;
        
            foreach (var item in listToDisplay)
            {
                if (item.IsSelected == true && item.Status == "New")
                {
                count++;
                Order order = dalObject.GetOrderByOrderId(item.OrderID);
                order.StatusID = 2;
                dalObject.UpdateOrder(order);
                }
            }
            MessageBox.Show(count.ToString());
            Refresh();
        }

        private void New()
        {
            state = RadioState.New;

            listToDisplay.Clear();
            List<Order> list = dalObject.GetAllOrders();

            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                if (dalObject.GetStatusByStatusId((int)item.StatusID) == "New")
                {
                    listToDisplay.Add(new GridFields()
                    {
                        OrderID = item.OrderID,
                        Name = stockName,
                        Symbol = stockSymbol,
                        MarketPrice = marketPrice,
                        Status = statusName
                    });
                }
            }
        }

        private void Open()
        {
            listToDisplay.Clear();
            state = RadioState.Open;

            List<Order> list = dalObject.GetAllOrders();

            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                if (dalObject.GetStatusByStatusId((int)item.StatusID) == "Open")
                {
                    listToDisplay.Add(new GridFields()
                    {
                        OrderID = item.OrderID,
                        Name = stockName,
                        Symbol = stockSymbol,
                        MarketPrice = marketPrice,
                        Status = statusName
                    });
                }
            }

        }

        private void Refresh()
        {

            listToDisplay.Clear();
            List<Order> list = dalObject.GetAllOrders();


            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                switch (state)
                {
                    case RadioState.New:
                        if (dalObject.GetStatusByStatusId((int)item.StatusID) == "New")
                        {
                            listToDisplay.Add(new GridFields()
                            {
                                OrderID = item.OrderID,
                                Name = stockName,
                                Symbol = stockSymbol,
                                MarketPrice = marketPrice,
                                Status = statusName
                            });
                        }
                        break;

                    case RadioState.Open:
                        if (dalObject.GetStatusByStatusId((int)item.StatusID) == "Open")
                        {
                            listToDisplay.Add(new GridFields()
                            {
                                OrderID = item.OrderID,
                                Name = stockName,
                                Symbol = stockSymbol,
                                MarketPrice = marketPrice,
                                Status = statusName
                            });
                        }
                        break;

                    case RadioState.All:

                        listToDisplay.Add(new GridFields()
                        {
                            OrderID = item.OrderID,
                            Name = stockName,
                            Symbol = stockSymbol,
                            MarketPrice = marketPrice,
                            Status = statusName
                        });

                        break;

                    case RadioState.Search:

                        if (stockSymbol == SearchTextOrder)
                        {
                            listToDisplay.Add(new GridFields()
                            {
                                OrderID = item.OrderID,
                                Name = stockName,
                                Symbol = stockSymbol,
                                MarketPrice = marketPrice,
                                Status = statusName
                            });
                        }

                        break;

                    default:
                        break;

                }
            }
        }
        
        private void All()
        {
            listToDisplay.Clear();
            state = RadioState.All;

            List<Order> list = dalObject.GetAllOrders();

            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                listToDisplay.Add(new GridFields()
                    {
                        OrderID = item.OrderID,
                        Name = stockName,
                        Symbol = stockSymbol,
                        MarketPrice = marketPrice,
                        Status = statusName
                    });

            }

        }
    }
}
