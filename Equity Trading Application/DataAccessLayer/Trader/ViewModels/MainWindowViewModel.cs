using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Collections.ObjectModel;
using PortfolioManager.Helpers;
using System.Windows.Input;
using EquityTradingApplication.Commands;
using System.Windows;
using Trader.Helpers;
using PortfolioManagerWindow.Helpers;
using System.Timers;
using System.Windows.Threading;

namespace Trader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        PortfolioDAL dalObject;

        private readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);

        private GridDetailsBLock selectedRow;
        public GridDetailsBLock SelectedRow
        {
            get { return selectedRow; }
            set
            {
                selectedRow = value;
                RaisePropertyChanged("SelectedRow");
                RowChanged();
            }

        }

        private GridDetailsBLock selectedItemUpdate;
        public GridDetailsBLock SelectedItemUpdate
        {
            get { return selectedItemUpdate; }
            set { selectedItemUpdate = value;
            RaisePropertyChanged("SelectedItemUpdate");
            UpdateRowSelected();
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get {

                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(p=>DeleteBlock());
                return deleteCommand; }
        }
        
        private ObservableCollection<GridFields> listToDisplay;
        public ObservableCollection<GridFields> ListToDisplay
        {
            get { return listToDisplay; }
            set { listToDisplay = value; }
        }

        private ObservableCollection<GridDetailsBLock> updateBlockList;
        public ObservableCollection<GridDetailsBLock> UpdateBlockList
        {
            get { return updateBlockList; }
            set { updateBlockList = value; }
        }

        private ObservableCollection<GridDetailsBLock> executedBlocks;
        public ObservableCollection<GridDetailsBLock> ExecutedBlocks
        {
            get { return executedBlocks; }
            set { executedBlocks = value; }
        }

        private ObservableCollection<GridFields> createBLockList;
        public ObservableCollection<GridFields> CreateBLockList
        {
            get { return createBLockList; }
            set { createBLockList = value; }
        }

        private Visibility visible=Visibility.Hidden;
        public Visibility Visible
        {
            get { return visible; }
            set { visible=value;
            RaisePropertyChanged("Visible");
            }
        }

        private string x = "HELLo";
        public string X
        {
            get { return x; }
            set
            {
                x = value;
                RaisePropertyChanged("X");
            }
        }

        private ICommand sendCommand;
        public ICommand SendCommand
        {
            get
            {
                if (sendCommand == null)
                    sendCommand = new RelayCommand(p => SendForExecution());

                return sendCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(p => Update());

                return updateCommand;
            }
        }

        private ICommand doneUpdatingCommand;
        public ICommand DoneUpdatingCommand
        {
            get
            {
                if (doneUpdatingCommand == null)
                    doneUpdatingCommand = new RelayCommand(p => DoneUpdate());

                return doneUpdatingCommand;
            }
        }

        private ICommand cancelUpdatingCommand;
        public ICommand CancelUpdatingCommand
        {
            get
            {
                if (cancelUpdatingCommand == null)
                    cancelUpdatingCommand = new RelayCommand(p => CancelUpdate());

                return cancelUpdatingCommand;
            }
        }    

        private ObservableCollection<GridFields> details;
        public ObservableCollection<GridFields> Details
        {
            get { return details; }
            set { details = value; }
        }

        private ObservableCollection<GridDetailsBLock> listToDisplayBlocks;
        public ObservableCollection<GridDetailsBLock> ListToDisplayBlocks
        {
            get { return listToDisplayBlocks; }
            set { listToDisplayBlocks = value; }
        }

        private ICommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                if (createCommand == null)
                    createCommand = new RelayCommand(p => CreateBlock());
                return createCommand;
            }
        }

        public MainWindowViewModel()
        {
            dalObject = new PortfolioDAL();
            listToDisplay = new ObservableCollection<GridFields>();
            createBLockList = new ObservableCollection<GridFields>();
            listToDisplayBlocks = new ObservableCollection<GridDetailsBLock>();
            details = new ObservableCollection<GridFields>();
            updateBlockList = new ObservableCollection<GridDetailsBLock>();
            executedBlocks = new ObservableCollection<GridDetailsBLock>();

            DisplayBlocks();    

            timer.Interval = new TimeSpan(0, 0, 10);

            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();

            List<Block> blocks = dalObject.GetAllBlocks();

            foreach (var item in blocks)
            {
                if (item.StatusId == 4)
                {
                    string symbol = dalObject.GetSymbolFromBlockID(item.BlockID);

                    executedBlocks.Add(new GridDetailsBLock()
                    {
                        BlockID = item.BlockID,
                        LimitPrice = item.LimitPrice,
                        StopPrice = item.StopPrice,
                        Symbol = symbol
                    });
                }
            }

        }

        private void DisplayBlocks()
        {
            listToDisplay.Clear();
            listToDisplayBlocks.Clear();

            List<Order> list = dalObject.GetAllOrders();

            foreach (var item in list)
            {
                Stock stock = dalObject.GetStockById((int)item.StockID);

                string stockName = stock.StockName;
                string stockSymbol = stock.StockSymbol;
                decimal? marketPrice = stock.MarketPrice;

                string statusName = dalObject.GetStatusByStatusId((int)item.StatusID);

                if (dalObject.GetStatusByStatusId((int)item.StatusID) == "Open" && item.BlockID == -1)
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

            List<Block> blocks = dalObject.GetAllBlocks();
            foreach (var item in blocks)
            {
                if (item.BlockID != -1 && item.StatusId != 4)
                {
                    string stockSymbol = dalObject.GetSymbolFromBlockID(item.BlockID);

                    listToDisplayBlocks.Add(
                        new GridDetailsBLock()
                        {
                            BlockID = item.BlockID,
                            Symbol = stockSymbol,
                            LimitPrice = item.LimitPrice,
                            StopPrice = item.StopPrice
                        }
                        );
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            executedBlocks.Clear();
            List<Block> blocks = dalObject.GetAllBlocks();
            foreach (var item in blocks)
            {
                if (item.StatusId == 4)
                {
                    string symbol = dalObject.GetSymbolFromBlockID(item.BlockID);

                    executedBlocks.Add(new GridDetailsBLock()
                    {
                        BlockID = item.BlockID,
                        LimitPrice = item.LimitPrice,
                        StopPrice = item.StopPrice,
                        Symbol = symbol
                    });

                }
            }

            DisplayBlocks();
        }

        private void CreateBlock()
        {
            createBLockList.Clear();

            //MessageBox.Show(listToDisplay.Count(q=>q.IsSelected==true).ToString());
            foreach (var item in listToDisplay)
            {
                if (item.IsSelected == true)
                    createBLockList.Add(item);
            }

            //if all the orders are of the buy side of the sell side(constraint)
            if (createBLockList.All(q => dalObject.GetSideByOrderID(q.OrderID) == "BUY") || createBLockList.All(q => dalObject.GetSideByOrderID(q.OrderID) == "SELL"))
            {

                Block block = new Block();
                block.BlockID = dalObject.GetMaxBlockID();

                if (createBLockList.All(q => dalObject.GetSideByOrderID(q.OrderID) == "BUY"))
                {
                    block.LimitPrice = createBLockList.Min(q => dalObject.GetLimitPriceByOrderId(q.OrderID));
                    block.StopPrice = createBLockList.Max(q => dalObject.GetStopPriceByOrderId(q.OrderID));
                }
                else if (createBLockList.All(q => dalObject.GetSideByOrderID(q.OrderID) == "SELL"))
                {
                    block.LimitPrice = createBLockList.Max(q => dalObject.GetLimitPriceByOrderId(q.OrderID));
                    block.StopPrice = createBLockList.Min(q => dalObject.GetStopPriceByOrderId(q.OrderID));
                }

                //which orders are part of this block   
                foreach (var item in createBLockList)
                {
                    block.Orders += item.OrderID;
                    block.Side = dalObject.GetSideByOrderID(item.OrderID);
                    block.Orders += " ";
                }
                dalObject.InsertBlock(block);

                //Updating the block id of the orders                
                foreach (var item in createBLockList)
                {
                    Order o = dalObject.GetOrderByOrderId(item.OrderID);
                    o.BlockID = block.BlockID;
                    dalObject.UpdateOrder(o);
                }
            }

            DisplayBlocks();
        }

        private void RowChanged()
        {
            details.Clear();

            string orders = dalObject.GetOrdersStringFromBlockID(SelectedRow.BlockID);
            string[] Orders = orders.Split(' ');

            for (int i = 0; i < Orders.Length - 1; i++)
            {
                int orderID = int.Parse(Orders[i]);
                details.Add(new GridFields()
                {
                    OrderID = dalObject.GetOrderByOrderId(orderID).OrderID,
                    Name = dalObject.GetStockNameByID((int)dalObject.GetOrderByOrderId(orderID).StockID),
                    
                }
               );
            }
        }

        private void Update()
        {
            updateBlockList.Clear();
            Visible = Visibility.Visible;
            Block block = dalObject.GetBlockByBlockId(SelectedRow.BlockID);

            updateBlockList.Add(new GridDetailsBLock() { 
            BlockID = block.BlockID,
            LimitPrice = block.LimitPrice,
            StopPrice = block.StopPrice,
            Symbol = dalObject.GetSymbolFromBlockID(block.BlockID)
            });


        }

        private void DoneUpdate()
        {
            foreach (var item in updateBlockList)
            {
                decimal? stopP = item.StopPrice;
                decimal? limitP = item.LimitPrice;
                int blockID = item.BlockID;

                Block block = dalObject.GetBlockByBlockId(blockID);
                block.LimitPrice = limitP;
                block.StopPrice = stopP;
                
                dalObject.UpdateBlock(block);
            }

            listToDisplayBlocks.Clear();

            List<Block> blocks = dalObject.GetAllBlocks();
            foreach (var item in blocks)
            {
                if (item.BlockID != -1)
                {
                    string stockSymbol = dalObject.GetSymbolFromBlockID(item.BlockID);

                    listToDisplayBlocks.Add(
                        new GridDetailsBLock()
                        {

                            BlockID = item.BlockID,
                            Symbol = stockSymbol,
                            LimitPrice = item.LimitPrice,
                            StopPrice = item.StopPrice
                        }
                        );
                }

            }
            Visible = Visibility.Hidden;
        }

        private void CancelUpdate()
        {
            Visible = Visibility.Hidden;        
        }

        public void UpdateRowSelected()
        {
            foreach (var item in updateBlockList)
            {
                MessageBox.Show(item.StopPrice.ToString());
            }
        }

        private void DeleteBlock()
        {
            foreach (var item in listToDisplayBlocks)
            {
                if (item.IsSelected == true)
                {
                 string orders = dalObject.GetOrdersStringFromBlockID(item.BlockID);
                 string[] Orders = orders.Split(' ');

                 for (int i = 0; i < Orders.Length - 1; i++)
                 {
                     int orderID = int.Parse(Orders[i]);
                     Order order = dalObject.GetOrderByOrderId(orderID);
                     order.BlockID = -1;
                     dalObject.UpdateOrder(order);
                 }
                
                }   
                    dalObject.DeleteBlock(dalObject.GetBlockByBlockId(item.BlockID));
               
            }
            DisplayBlocks();
        }

        public void SendForExecution()
        {
            int blockID = SelectedRow.BlockID;
            string orders = dalObject.GetOrdersStringFromBlockID(blockID);

            string[] Orders = orders.Split(' ');

            for (int i = 0; i < Orders.Length - 1; i++)
            {
                int orderID = int.Parse(Orders[i]);
                Order order = dalObject.GetOrderByOrderId(orderID);
                order.StatusID = 3;
                dalObject.UpdateOrder(order);
            }
        }
    }
}
