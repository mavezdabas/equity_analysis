using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ExecutionTraderMainWindow.Commands;
using ExecutionTraderMainWindow.Helpers;
using DataAccessLayer;
using System.Collections.ObjectModel;
using ExecutionTraderMainWindow.Model;
using System.Windows;
using System.Timers;


namespace ExecutionTraderMainWindow.ViewModel
{
    public class MainWindowExecutionTraderViewModel : ViewModelBase
    {
        #region properties

        Action<string> popup = (Action<string>)(msg => MessageBox.Show(msg));
        Func<string, string, bool> confirm = (Func<string, string, bool>)((msg, capt) =>
                             MessageBox.Show(msg, capt, MessageBoxButton.YesNo) ==
                                    MessageBoxResult.Yes);
        ExecutionTraderDAL dalObject = new ExecutionTraderDAL();
        public ObservableCollection<BlockModel> blockList { get; set; }
        public ObservableCollection<OrderModel> openOrdersList { get; set; }
        public ObservableCollection<ExecutedBlocksModel> executedBlockList { get; set; }
        public ObservableCollection<AllocatedOrdersModel> allocatedOrders { get; set; }
        public List<BlockModel> selectedBlockList { get; set; }
        public BlockModel SelectedBlock { get; set; }
        public List<OrderModel> SelectedOrders { get; set; }
        public ObservableCollection<BlockModel> GetAllBlocks { get; set; }
        private BlockModel selectedBlock;
        private OrderModel selectedOrder;
        public ObservableCollection<OrderModel> GetAllOrders { get; set; }
        public BlockModel SelectedExecutedBlock { get; set; }
        public OrderModel SelectedAllocatedOrder { get; set; }

        Timer timer = new System.Timers.Timer(30000);
        public MainWindowExecutionTraderViewModel()
        {
            blockList = new ObservableCollection<BlockModel>();
            openOrdersList = new ObservableCollection<OrderModel>();
            executedBlockList = new ObservableCollection<ExecutedBlocksModel>();
            allocatedOrders = new ObservableCollection<AllocatedOrdersModel>();
            dialogService = new ModalDialogService();
            GetAllBlocks = new ObservableCollection<BlockModel>();
            securitiesList = new List<SecurityModel>();
            SelectedOrders = new List<OrderModel>();
            blockIDInOrderAllocations = new ObservableCollection<int>();
            allocatedOrdersSecurityList = new ObservableCollection<SecurityModel>();
            GetAllOrders = new ObservableCollection<OrderModel>();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            LoadAllComboBox();
            LoadAllBlocks();
            LoadAllExecutedBlocks();
            LoadAllOpenOrders();
            LoadAllocatedOrders();
            ShowGraph();
            
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)(() => ReloadAllGrids()));
        }


        public BlockModel SelectedBlock1
        {
            get { return selectedBlock; }
            set
            {
                selectedBlock = value;
                RaisePropertyChanged("SelectedBlock1");
            }
        }
        private OrderModel selectedOrderForComboBox;
        public OrderModel SelectedOrderForComboBox
        {
            get { return selectedOrder; }
            set
            {
                selectedOrderForComboBox = value;
                RaisePropertyChanged("SelectedOrderForComboBox");
            }
        }
        public OrderModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                RaisePropertyChanged("SelectedOrder");
            }
        }


        //public BlockModel blockByBlockId;
        public List<SecurityModel> securitiesList { get; set; }
        private SecurityModel selectedSecurity;

        public SecurityModel SelectedSecurity
        {
            get { return selectedSecurity; }
            set
            {
                selectedSecurity = value;
                RaisePropertyChanged("SelectedSecurity");
            }
        }
        private SecurityModel selectedSecurity1;

        public SecurityModel SelectedSecurity1
        {
            get { return selectedSecurity1; }
            set
            {
                selectedSecurity1 = value;
                RaisePropertyChanged("SelectedSecurity1");
            }
        }
        public ObservableCollection<string> blockStatusList { get; set; }
        private string selectedBlockStatus;

        public string SelectedBlockStatus
        {
            get { return selectedBlockStatus; }
            set
            {
                selectedBlockStatus = value;
                RaisePropertyChanged("SelectedBlockStatus");
            }
        }
        public ObservableCollection<string> blockSideList { get; set; }
        private string selectedBlockSide;

        public string SelectedBlockSide
        {
            get { return selectedBlockSide; }
            set
            {
                selectedBlockSide = value;
                RaisePropertyChanged("SelectedBlockSide");
            }
        }
        public List<string> orderSideList { get; set; }
        private string selectedOrderSide;

        public string SelectedOrderSide
        {
            get { return selectedOrderSide; }
            set
            {
                selectedOrderSide = value;
                RaisePropertyChanged("SelectedOrderSide");
            }
        }

        public ObservableCollection<int> blockIDInOrderAllocations { get; set; }
        private string selectedBlockIDInOrderAlocations;
        private string selectedOrderAllocationsSide;

        public string SelectedOrderAllocationsSide
        {
            get { return selectedOrderAllocationsSide; }
            set
            {
                selectedOrderAllocationsSide = value;
                RaisePropertyChanged("SelectedOrderAllocationsSide");
            }
        }

        public string SelectedBlockIDInOrderAlocations
        {
            get { return selectedBlockIDInOrderAlocations; }
            set
            {
                selectedBlockIDInOrderAlocations = value;
                RaisePropertyChanged("SelectedBlockIDInOrderAlocations");
            }
        }
        public ObservableCollection<SecurityModel> allocatedOrdersSecurityList { get; set; }
        private SecurityModel selectedSecurityInOrderAllocations;

        public SecurityModel SelectedSecurityInOrderAllocations
        {
            get { return selectedSecurityInOrderAllocations; }
            set
            {
                selectedSecurityInOrderAllocations = value;
                RaisePropertyChanged("SelectedSecurityInOrderAllocations");
            }
        }

        private List<OrderModel> ordersToBeDeleted { get; set; }



        private void LoadAllocatedOrders()
        {
            dalObject.DisplayAllocatedOrders().ForEach(e => allocatedOrders.Add(Converter.ConvertAllocatedOrdersToAllocatedOrdersModel(e)));
            blockIDInOrderAllocations.Clear();
            allocatedOrdersSecurityList.Clear();
            LoadAllocationFilters();

        }
        private void LoadAllComboBox()
        {
            LoadOrderFilters();

            LoadBlockFilters();

            LoadAllocationFilters();
            blockSideList = new ObservableCollection<string>(new string[] { "BUY", "SELL" });
            orderSideList = new List<string>(new string[] { "BUY", "SELL" });
            Array blockStatusArray = Enum.GetValues(typeof(BlockStatusEnum));
            blockStatusList = new ObservableCollection<string>();
            for (int i = 0; i < blockStatusArray.Length; i++)
            {
                blockStatusList.Add(blockStatusArray.GetValue(i).ToString());
            }
        }

        private void LoadAllocationFilters()
        {
            foreach (var blockID in dalObject.GetBlockIDFromOrderAllocations())
            {

                blockIDInOrderAllocations.Add(blockID);
            }
            foreach (var security in dalObject.GetSecurityFromOrderAllocations())
            {
                allocatedOrdersSecurityList.Add(Converter.ConvertSecurityToSecurityModel(security));
            }
        }

        private void LoadBlockFilters()
        {
            foreach (var item in dalObject.DisplayBlocks())
            {
                GetAllBlocks.Add(Converter.ConvertBlockToBlockModel(item));
            }

        
           
        }

        private void LoadOrderFilters()
        {
            var orders = dalObject.DisplayOrders();
            foreach (var item in orders)
            {
                if (item.Status.StatusName.Equals("OPEN") && item.BlockID == null)
                    GetAllOrders.Add(Converter.ConvertOrderToOrderModel(item));
            }
            

            foreach (var selectedSecurityy in dalObject.GetAllSecurities())
            {
                securitiesList.Add(Converter.ConvertSecurityToSecurityModel(selectedSecurityy));

            }
        }

        private void LoadAllExecutedBlocks()
        {
            dalObject.DisplayExecutedBlocks().ForEach(e => executedBlockList.Add(Converter.ConvertExecutedBlockToExecutedBlockModel(e)));
        }

        private void LoadAllOpenOrders()
        {
            dalObject.DisplayOpenOrders().ForEach(e => openOrdersList.Add(Converter.ConvertOrderToOrderModel(e)));
            GetAllOrders.Clear();
            securitiesList.Clear();
            LoadOrderFilters();
        }

        private void LoadAllBlocks()
        {
            List<Block> ListOfBlocks = dalObject.DisplayBlocks(); //.ForEach(e => blockList.Add(e));
            foreach (var item in ListOfBlocks)
            {
                blockList.Add(Converter.ConvertBlockToBlockModel(item));
            }
            GenerateProposedBlocks();
            GetAllBlocks.Clear();
            LoadBlockFilters();
        }

        private void GenerateProposedBlocks()
        {
            List<OrderModel> openOrdersList = new List<OrderModel>();
            dalObject.DisplayOpenOrders().ForEach(e => openOrdersList.Add(Converter.ConvertOrderToOrderModel(e)));
            List<BlockModel> ProposedBlockList = new List<BlockModel>();
            BlockModel dummyblock = new BlockModel();
            ProposedBlockList.Add(dummyblock);
            foreach (var order in openOrdersList)
            {
                int flag = -1;
                foreach (var block in ProposedBlockList)
                {
                    if (order.Side == block.BlockSide && order.SecurityId == block.SecurityId)
                    {
                        block.Orders.Add(order);
                        flag = 1;
                    }

                }
                if (flag == -1)
                {
                    BlockModel newBlock = new BlockModel();
                    newBlock.BlockSide = order.Side;
                    newBlock.BlockId = null;
                    newBlock.BlockStatus = BlockStatusEnum.Proposed.ToString();
                    newBlock.ExecutedQuantity = newBlock.ExecutedQuantity + order.AllocatedQuantity;
                    newBlock.OpenQuantity = newBlock.OpenQuantity + order.OpenQuantity;
                    newBlock.TotalQuantity = newBlock.TotalQuantity + order.TotalQuantity;
                    newBlock.SecurityId = order.SecurityId;
                    newBlock.security = order.Security;
                    newBlock.Orders = new ObservableCollection<OrderModel>();
                    newBlock.Orders.Add(order);
                    newBlock.AllocatedOrders = null;
                    newBlock.ExecutedBlocks = null;
                    newBlock.StopPrice = Convert.ToDecimal(order.StopPrice);
                    newBlock.LimitPrice = Convert.ToDecimal(order.LimitPrice);

                    ProposedBlockList.Add(newBlock);
                }
            }
            ProposedBlockList.Remove(dummyblock);
            foreach (var block in ProposedBlockList)
            {
                blockList.Add(block);
            }
        }

        private IModalDialogService dialogService;

        private ICommand openEditBlockViewCommand;
        public ICommand OpenEditBlockViewCommand
        {
            get
            {
                if (openEditBlockViewCommand == null)
                    openEditBlockViewCommand = new RelayCommand(p => SetEditBlockViewForEditButton(), p => OpenEditBlockView());
                return openEditBlockViewCommand;
            }
        }
        private bool SetEditBlockView()
        {

            if (SelectedBlock != null)
            {
                if (SelectedBlock.BlockStatus.Equals(BlockStatusEnum.New.ToString())) return true;
                else return false;
            }

            else return false;
        }

        private bool SetEditBlockViewForEditButton()
        {
            int selectcount = 0;
            foreach (var block in blockList)
            {
                if (block.IsSelected == true) selectcount++;
            }
            if (SelectedBlock != null && selectcount == 1)
            {
                if (SelectedBlock.BlockStatus.Equals(BlockStatusEnum.New.ToString())) return true;
                else return false;
            }

            else return false;
        }

        private ICommand openCreateBlockViewCommand;
        public ICommand OpenCreateBlockViewCommand
        {
            get
            {
                if (openCreateBlockViewCommand == null)
                    openCreateBlockViewCommand = new RelayCommand(p => SetCreateBlockView(), p => OpenCreateBlockView());
                return openCreateBlockViewCommand;
            }
        }

        private SecurityModel GetBlockSecurity()
        {
            if (SelectedOrders != null)
            {
                int firstBlockSecurity = SelectedOrders.First().SecurityId;
                if (SelectedOrders.All(e => e.SecurityId == firstBlockSecurity))
                    return SelectedOrders.First().Security;
                else return null;
            }
            else return null;
        }

        private string GetBlockSide()
        {
            if (SelectedOrders != null)
            {
                var firstBlockSide = SelectedOrders.First().Side;
                if (SelectedOrders.All(e => e.Side == firstBlockSide))
                    return firstBlockSide;
                else return string.Empty;
            }
            else return string.Empty;

        }

        private ICommand openAddToBlockViewCommand;
        public ICommand OpenAddToBlockViewCommand
        {
            get
            {
                if (openAddToBlockViewCommand == null)
                    openAddToBlockViewCommand = new RelayCommand(p => SetCreateBlockView(), p => OpenAddToBlockView());
                return openAddToBlockViewCommand;
            }
        }

        private void OpenAddToBlockView()
        {
            ObservableCollection<BlockModel> blocks = new ObservableCollection<BlockModel>();
            GetSelectedOrders();

            foreach (var block in blockList)
            {
                if (block.BlockId > 0)
                {
                    if (block.BlockSide.Equals(SelectedOrders[0].Side) && block.SecurityId == SelectedOrders[0].SecurityId && block.BlockStatus.Equals(BlockStatusEnum.New.ToString()))
                        blocks.Add(block);
                }
                else break;

            }
            if (blocks.Count > 0)
            {
                AddOrdersToBlockViewModel vmodel = new AddOrdersToBlockViewModel(popup, confirm, SelectedOrders, blocks);
                if (vmodel != null) dialogService.ShowDialog<AddOrdersToBlockViewModel>
                       (ViewType.AddToBlockView, vmodel, () => LoadAllGrids());
            }
            else
            {
                popup("Sorry!! No such block exists.");
            }
        }
        private ICommand filterCommand;
        public ICommand FilterCommand
        {
            get
            {
                if (filterCommand == null)
                    filterCommand = new RelayCommand(p => DisplayFilteredBlocksOnGrid());
                return filterCommand;
            }
        }

        private ICommand filterOrdersCommand;
        public ICommand FilterOrdersCommand
        {
            get
            {
                if (filterOrdersCommand == null)
                    filterOrdersCommand = new RelayCommand(p => DisplayFilteredOrdersOnGrid());
                return filterOrdersCommand;
            }
        }

        private ICommand filterOrderAllocationsCommand;
        public ICommand FilterOrderAllocationsCommand
        {

            get
            {
                if (filterOrderAllocationsCommand == null)
                    filterOrderAllocationsCommand = new RelayCommand(p => DisplayFilteredOrderAllocationsOnGrid());
                return filterOrderAllocationsCommand;
            }
        }
        private ICommand refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                if (refreshCommand == null)
                    refreshCommand = new RelayCommand(p => RefreshOrderAllocations());

                return refreshCommand;
            }

        }
        private ICommand refreshCommandBlockGrid;

        public ICommand RefreshCommandBlockGrid
        {
            get
            {
                if (refreshCommandBlockGrid == null)
                    refreshCommandBlockGrid = new RelayCommand(p => RefreshBlockGrid());
                return refreshCommandBlockGrid;
            }

        }
        private ICommand refreshCommandOrderGrid;

        public ICommand RefreshCommandOrderGrid
        {
            get
            {
                if (refreshCommandOrderGrid == null)
                    refreshCommandOrderGrid = new RelayCommand(p => RefreshOrderGrid());
                return refreshCommandOrderGrid;
            }

        }


        #endregion
        void RefreshBlockGrid()
        {
            SelectedBlock1 = null;
            SelectedSecurity = null;
            SelectedBlockStatus = null;
            SelectedBlockSide = null;
            LoadAllBlocks();
        }
        void RefreshOrderGrid()
        {
            SelectedOrderForComboBox = null;
            SelectedSecurity1 = null;
            SelectedOrderSide = null;
            DisplayFilteredOrdersOnGrid();
        }
        void RefreshOrderAllocations()
        {
            SelectedBlockIDInOrderAlocations = null;
            SelectedSecurityInOrderAllocations = null;
            SelectedOrderAllocationsSide = null;
            DisplayFilteredOrderAllocationsOnGrid();

        }
        void DisplayFilteredOrderAllocationsOnGrid()
        {
            int selectedBlockIDInOrderAlocationsInInt;
            if (SelectedBlockIDInOrderAlocations == null)
                selectedBlockIDInOrderAlocationsInInt = 0;
            else
                selectedBlockIDInOrderAlocationsInInt = Convert.ToInt32(SelectedBlockIDInOrderAlocations);
            if (SelectedSecurityInOrderAllocations == null)
                SelectedSecurityInOrderAllocations = new SecurityModel();

            allocatedOrders.Clear();
            foreach (var item in dalObject.GetFilteredOrderAllocations(Convert.ToInt32(selectedBlockIDInOrderAlocations),
                selectedSecurityInOrderAllocations.SecurityID, selectedOrderAllocationsSide))
            {
                allocatedOrders.Add(Converter.ConvertAllocatedOrdersToAllocatedOrdersModel(item));
            }
        }
        void DisplayFilteredBlocksOnGrid()
        {
            int selectedBlockStatusInInt;
            //blockByBlockId = Converter.ConvertBlockToBlockModel(dalObject.GetBlockByBlockID(selectedBlock.BlockId));
            //blockList.Clear();
            //blockList.Add(blockByBlockId);
            //blockByBlockId = Converter.ConvertBlockToBlockModel
            //    (dalObject.GetFilteredBlocks(selectedBlock.BlockId,selectedBlock.SecurityId));
            if (selectedBlock == null)
                selectedBlock = new BlockModel();
            if (selectedSecurity == null)
                selectedSecurity = new SecurityModel();
            if (selectedBlockStatus == null)
            {
                selectedBlockStatusInInt = 0;
            }
            else
            {
                selectedBlockStatusInInt = (int)(Enum.Parse(typeof(BlockStatusEnum), selectedBlockStatus));
            }

            blockList.Clear();
            foreach (var item in dalObject.GetFilteredBlocks(Convert.ToInt32(selectedBlock.BlockId), selectedSecurity.SecurityID, selectedBlockStatusInInt, selectedBlockSide))
            {
                blockList.Add(Converter.ConvertBlockToBlockModel(item));
            }
            //GenerateProposedBlocks();
        }

        void DisplayFilteredOrdersOnGrid()
        {
            if (selectedOrderForComboBox == null)
                selectedOrderForComboBox = new OrderModel();
            if (selectedSecurity1 == null)
                selectedSecurity1 = new SecurityModel();
            openOrdersList.Clear();
            foreach (var item in dalObject.GetFilteredOrders(selectedOrderForComboBox.OrderId, selectedSecurity1.SecurityID, selectedOrderSide))
            {
                openOrdersList.Add(Converter.ConvertOrderToOrderModel(item));
            }

        }



        private void OpenEditBlockView()
        {
            EditBlockViewModel vmodel = new EditBlockViewModel(popup, confirm, SelectedBlock);
            if (vmodel != null) dialogService.ShowDialog<EditBlockViewModel>
                   (ViewType.EditBlockView, vmodel, () => LoadAllGrids());
        }

        private void OpenCreateBlockView()
        {
            GetSelectedOrders();

            CreateBlockWindowViewModel vmodel = new CreateBlockWindowViewModel(popup, confirm, SelectedOrders);
            if (vmodel != null) dialogService.ShowDialog<CreateBlockWindowViewModel>
                   (ViewType.CreateBlockView, vmodel, () => LoadAllGrids());
        }



        private void GetSelectedOrders()
        {
            SelectedOrders = new List<OrderModel>();
            foreach (var orders in openOrdersList)
            {
                if (orders.IsSelected == true)
                {
                    SelectedOrders.Add(orders);
                }
            }

        }
        private void ReloadAllGrids()
        {
            if (SelectedBlock == null && SelectedBlock1 == null && SelectedSecurity == null && SelectedBlockSide == null && SelectedBlockStatus == null)
            {
                blockList.Clear();
                LoadAllBlocks();
                
            }
            if (SelectedOrder == null && SelectedOrderForComboBox == null && SelectedSecurity1 == null && SelectedOrderSide == null)
            {
                openOrdersList.Clear();
                LoadAllOpenOrders();
            }

            if (SelectedExecutedBlock == null)
            {
                executedBlockList.Clear();
                LoadAllExecutedBlocks();
            }
            if (SelectedAllocatedOrder == null && SelectedOrderAllocationsSide == null && SelectedSecurityInOrderAllocations == null && SelectedBlockIDInOrderAlocations == null)
            {
                allocatedOrders.Clear();
                LoadAllocatedOrders();
            }
            ShowGraph();
            

        }
        private void LoadAllGrids()
        {
            SelectedOrderForComboBox = null;
            SelectedSecurity1 = null;
            SelectedOrderSide = null;
            blockList.Clear();
            openOrdersList.Clear();
            LoadAllBlocks();
            LoadAllOpenOrders();
            executedBlockList.Clear();
            LoadAllExecutedBlocks();
            allocatedOrders.Clear();
            LoadAllocatedOrders();
            ShowGraph();

        }

        private ICommand sendForExecutionCommand;
        public ICommand SendForExecutionCommand
        {
            get
            {
                if (sendForExecutionCommand == null)
                    sendForExecutionCommand = new RelayCommand(p => SetEditBlockView(), p => SendForExecution());
                return sendForExecutionCommand;
            }
        }

        //private void SendForExecution()
        //{
        //    if (SendForExecutionMessageBox())
        //    {
        //        GetSelectedBlocks();
        //        foreach (var block in selectedBlockList)
        //        {
        //            block.BlockStatus = BlockStatusEnum.Sent_For_Execution.ToString();
        //            foreach (var order in block.Orders)
        //            {
        //                order.StatusId = 3;
        //                order.Status.StatusID = 3;
        //            }
        //            dalObject.UpdateOrders(Converter.ConvertOrderModelListToOrderList(block.Orders.ToList()));

        //            dalObject.EditBlock(Converter.ConvertBlockModelToBlock(block));
        //        }
        //    }

        //    LoadAllGrids();
        //}


        private void SendForExecution()
        {
            if (SendForExecutionMessageBox())
            {
                ServiceReference3.ExecuteBlockServiceClient obj = new ServiceReference3.ExecuteBlockServiceClient();
                List<ServiceReference3.Block> selectedBlockServiceList = new List<ServiceReference3.Block>();
                GetSelectedBlocks();
                foreach (var block in selectedBlockList)
                {
                    block.BlockStatus = BlockStatusEnum.Sent_For_Execution.ToString();
                    foreach (var order in block.Orders)
                    {
                        order.StatusId = 3;
                        order.Status.StatusID = 3;
                    }
                    dalObject.UpdateOrders(Converter.ConvertOrderModelListToOrderList(block.Orders.ToList()));

                    dalObject.EditBlock(Converter.ConvertBlockModelToBlock(block));
                }

                foreach (var block in selectedBlockList)
                {
                    List<ServiceReference3.Order> selectedOrderServiceList = new List<ServiceReference3.Order>();
                    foreach (var order in block.Orders)
                    {
                        selectedOrderServiceList.Add(
                            new ServiceReference3.Order()
                            {
                                AccountType = order.AccountType,
                                AllocatedQuantity = order.AllocatedQuantity,
                                BlockID = order.BlockId,
                                BookTime = order.BookTime,
                                ClientID = order.ClientId,
                                LimitPrice = order.LimitPrice,
                                ManagerID = order.ManagerId,
                                Notes = order.Notes,
                                Notify = order.Notify,
                                OpenQuantity = order.OpenQuantity,
                                OrderID = order.OrderId,
                                OrderQualifier = order.OrderQualifier,
                                OrderType = order.OrderType,
                                PortfolioID = order.PortfolioId,
                                SecurityID = order.SecurityId,
                                Side = order.Side,
                                StatusID = order.StatusId,
                                StopPrice = order.StopPrice,
                                TotalQuantity = order.TotalQuantity,
                                TraderID = order.TraderId,
                                TransactionPrice = order.TransactionPrice,
                                TransactionTime = order.TransactionTime,
                                //Block = Converter.ConvertBlockToBlockModel(order.Block),
                                //Client = Converter.ConvertClientToClientModel(order.Client),
                                //Portfolio = Converter.ConvertPortfolioToPortfolioModel(order.Portfolio),
                                //Manager = Converter.ConvertUserToUserModel(order.User),
                                //Trader = Converter.ConvertUserToUserModel(order.User1),
                                //Security = Converter.ConvertSecurityToSecurityModel(order.Security),
                                //Status = Converter.ConvertStatusToStatusModel(order.Status)
                            });


                    }
                    selectedBlockServiceList.Add(
                        new ServiceReference3.Block()
                        {

                            BlockID = block.BlockId.Value,
                            BlockSide = block.BlockSide,
                            BlockStatus =(int)(Enum.Parse(typeof(BlockStatusEnum), block.BlockStatus)),
                            ExecutedQuantity = block.ExecutedQuantity,
                            TotalQuantity = block.TotalQuantity,
                            OpenQuantity = block.OpenQuantity,
                            LimitPrice = block.LimitPrice,
                            StopPrice = block.StopPrice,
                            TraderID = block.TraderId,
                            SecurityID = block.SecurityId,
                            //Security = Converter.ConvertSecurityToSecurityModel(block.Security),
                            Orders = selectedOrderServiceList
                            //ExecutedBlocks=(ObservableCollection<ExecutedBlocksModel>)block.ExecutedBlocks,
                            //AllocatedOrders=(ObservableCollection<AllocatedOrdersModel>)block.OrderAllocations,
                        });
                }

               // obj.ExecuteBlock(selectedBlockServiceList);


            }

            LoadAllGrids();
        }

        private bool SendForExecutionMessageBox()
        {
            return confirm("Are you sure you want to send the selected block(s) for execution?", "Confirm!");
        }

        private void GetSelectedBlocks()
        {
            selectedBlockList = new List<BlockModel>();
            foreach (var block in blockList)
            {
                if (block.IsSelected == true)
                    selectedBlockList.Add(block);
            }

        }

        private ICommand deleteBlocksCommand;

        public ICommand DeleteBlocksCommand
        {
            get
            {
                if (deleteBlocksCommand == null)
                    deleteBlocksCommand = new RelayCommand(p => SetEditBlockView(), p => DeleteSelectedBlocks());
                return deleteBlocksCommand;
            }

        }
        private void DeleteSelectedBlocks()
        {
            if (DeleteSelectedBlocksMessageBox())
            {
                ordersToBeDeleted = new List<OrderModel>();
                OrderModel deleteOrder;
                selectedBlockList = new List<BlockModel>();
                foreach (var block in blockList)
                {
                    if (block.IsSelected == true)
                    {
                        selectedBlockList.Add(block);
                    }

                }
                foreach (var block in selectedBlockList)
                {
                    foreach (var order in block.Orders)
                    {
                        deleteOrder = order;
                        deleteOrder.BlockId = null;
                        ordersToBeDeleted.Add(deleteOrder);
                    }
                    dalObject.UpdateOrders(Converter.ConvertOrderModelListToOrderList(ordersToBeDeleted));
                    ordersToBeDeleted.Clear();
                    dalObject.DeleteBlock(Converter.ConvertBlockModelToBlock(block));
                }

                LoadAllGrids();
            }

        }

        private bool DeleteSelectedBlocksMessageBox()
        {
            return confirm("Are you sure you want to cancel these block?", "Confirm Action!");
        }


        private bool SetCreateBlockView()
        {
            GetSelectedOrders();
            if (SelectedOrders.Count > 0)
            {

                string checkside = SelectedOrders[0].Side;
                int checksecurity = SelectedOrders[0].SecurityId;
                foreach (var order in SelectedOrders)
                {
                    if (!(checkside.Equals(order.Side) && checksecurity == order.SecurityId)) { SelectedOrders.Clear(); return false; }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        private int executedOrdersCount;

        public int ExecutedOrdersCount
        {
            get { return executedOrdersCount; }
            set
            {
                executedOrdersCount = value;
                RaisePropertyChanged("ExecutedOrdersCount");
            }
        }

        private int sentForExecutionCount;


        public int SentForExecutionCount
        {
            get { return sentForExecutionCount; }
            set
            {
                sentForExecutionCount = value;
                RaisePropertyChanged("SentForExecutionCount");
            }
        }
        private int openOrdersCount;

        public int OpenOrdersCount
        {
            get { return openOrdersCount; }
            set
            {
                openOrdersCount = value;
                RaisePropertyChanged("OpenOrdersCount");
            }
        }
        private int expiredOrdersCount;

        public int ExpiredOrdersCount
        {
            get { return expiredOrdersCount; }
            set
            {
                expiredOrdersCount = value;
                RaisePropertyChanged("ExpiredOrdersCount");
            }
        }

        private int partialOrdersCount;

        public int PartialOrdersCount
        {
            get { return partialOrdersCount; }
            set
            {
                partialOrdersCount = value;
                RaisePropertyChanged("PartiallyExecutedOrdersCount");
            }
        }
        public ObservableCollection<KeyValuePair<string, int>> ordersCountList { get; set; }
        private void ShowGraph()
        {
            ordersCountList = new ObservableCollection<KeyValuePair<string, int>>();
            ExecutedOrdersCount = dalObject.DisplayAllocatedOrders().Count();
            OpenOrdersCount = dalObject.DisplayOpenOrders().Count();
            SentForExecutionCount = dalObject.DisplaySentOrders().Count();
            ExpiredOrdersCount = dalObject.DisplayExpiredOrders().Count();
            PartialOrdersCount = dalObject.DisplayPartiallyExecutedOrders().Count();
            ordersCountList.Add(new KeyValuePair<string, int>("OpenOrders", openOrdersCount));
            ordersCountList.Add(new KeyValuePair<string, int>("ExecutedOrders", ExecutedOrdersCount));
            ordersCountList.Add(new KeyValuePair<string, int>("SentForExecution", SentForExecutionCount));
            ordersCountList.Add(new KeyValuePair<string, int>("ExpiredOrders", ExpiredOrdersCount));
            ordersCountList.Add(new KeyValuePair<string, int>("PartiallyExecutedOrders", PartialOrdersCount));

        }

    }
}





