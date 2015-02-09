using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ExecutionTraderMainWindow.Commands;
using ExecutionTraderMainWindow.Helpers;
using ExecutionTraderDataAccessLayer;
using System.Collections.ObjectModel;
using ExecutionTraderMainWindow.Model;


namespace ExecutionTraderMainWindow.ViewModel
{
    class MainWindowExecutionTraderViewModel : ViewModelBase
    {
        #region properties
        ExecutionTraderDAL dalObject = new ExecutionTraderDAL();
        public ObservableCollection<BlockModel> blockList {get;set;}
        public ObservableCollection<OrderModel> openOrdersList { get; set; }
        public ObservableCollection<ExecutedBlocksModel> executedBlockList { get; set; }
        public ObservableCollection<AllocatedOrdersModel> allocatedOrders { get; set; }
        public BlockModel SelectedBlock { get; set; }
        public List<OrderModel> SelectedOrders { get; set; }
        public List<BlockModel> GetAllBlocks { get; set; }
        public BlockModel selectedBlock { get; set; }
        public BlockModel blockByBlockId;
        public List<SecurityModel> securitiesList { get; set; }
        public SecurityModel selectedSecurity { get; set; }
        public List<string> blockStatusList { get; set; }
        public string selectedBlockStatus { get; set; }
        public List<string> blockSideList { get; set; }
        public string selectedBlockSide { get; set; }

        public MainWindowExecutionTraderViewModel()
        {
            blockList = new ObservableCollection<BlockModel>();
            openOrdersList = new ObservableCollection<OrderModel>();
            executedBlockList = new ObservableCollection<ExecutedBlocksModel>();
            allocatedOrders = new ObservableCollection<AllocatedOrdersModel>();
            dialogService = new ModalDialogService();
            GetAllBlocks = new List<BlockModel>();
            securitiesList = new List<SecurityModel>();
            SelectedOrders = new List<OrderModel>();
            
            LoadAllBlocks();
            LoadAllExecutedBlocks();
            
            LoadAllOpenOrders();
            LoadAllocatedOrders();
            LoadAllComboBox();
          }

        private void LoadAllocatedOrders()
        {
            dalObject.DisplayAllocatedOrders().ForEach(e => allocatedOrders.Add(Converter.ConvertAllocatedOrdersToAllocatedOrdersModel(e)));
            
          
        }
        private void LoadAllComboBox()
        {


            foreach (var item in dalObject.DisplayBlocks())
            {
                GetAllBlocks.Add(Converter.ConvertBlockToBlockModel(item));
            }
            foreach (var selectedSecurityy in dalObject.GetAllSecurities())
            {
                securitiesList.Add(Converter.ConvertSecurityToSecurityModel(selectedSecurityy));

            }
            Array blockStatusArray = Enum.GetValues(typeof(BlockStatusEnum));
            blockStatusList = new List<string>(blockStatusArray.Length);
            for (int i = 0; i < blockStatusArray.Length; i++)
            {
                blockStatusList.Add(blockStatusArray.GetValue(i).ToString());
            }


            blockSideList = new List<string>(new string[] { "BUY", "SELL" });

        }

        private void LoadAllExecutedBlocks()
        {
            dalObject.DisplayExecutedBlocks().ForEach(e => executedBlockList.Add(Converter.ConvertExecutedBlockToExecutedBlockModel(e)));
        }

        private void LoadAllOpenOrders()
        {
            dalObject.DisplayOpenOrders().ForEach(e => openOrdersList.Add(Converter.ConvertOrderToOrderModel(e)));
        }

        private void LoadAllBlocks()
        {
           List<Block> ListOfBlocks=  dalObject.DisplayBlocks(); //.ForEach(e => blockList.Add(e));
           foreach (var item in ListOfBlocks)
           {
               blockList.Add(Converter.ConvertBlockToBlockModel(item));
           }
        }

        private IModalDialogService dialogService;

        private ICommand openEditBlockViewCommand;

        public ICommand OpenEditBlockViewCommand
        {
            get
            {
                if (openEditBlockViewCommand == null)
                    openEditBlockViewCommand = new RelayCommand(p => OpenEditBlockView());
                return openEditBlockViewCommand;
            }
        }

        private ICommand openCreateBlockViewCommand;
        public ICommand OpenCreateBlockViewCommand
        {
            get
            {
                if (openCreateBlockViewCommand == null)
                    openCreateBlockViewCommand = new RelayCommand(p => OpenCreateBlockView());
                return openCreateBlockViewCommand;
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
        #endregion
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
            foreach (var item in dalObject.GetFilteredBlocks(selectedBlock.BlockId, selectedSecurity.SecurityID, selectedBlockStatusInInt, selectedBlockSide))
            {
                blockList.Add(Converter.ConvertBlockToBlockModel(item));
            }

        }

        

        private void OpenEditBlockView()
        {
            EditBlockViewModel vmodel = new EditBlockViewModel(SelectedBlock);
           if(vmodel!=null) dialogService.ShowDialog<EditBlockViewModel>
               (ViewType.EditBlockView, vmodel, () => LoadAllGrids());
        }

        private void OpenCreateBlockView()
        {
            GetSelectedOrders();
            
            CreateBlockWindowViewModel vmodel = new CreateBlockWindowViewModel(SelectedOrders);
            if (vmodel != null) dialogService.ShowDialog<CreateBlockWindowViewModel>
                   (ViewType.CreateBlockView, vmodel, () => LoadAllGrids());
        }

        

        private void GetSelectedOrders()
        {
            foreach (var orders in openOrdersList)
            {
                if (orders.IsSelected == true)
                {
                    SelectedOrders.Add(orders);
                }
            }
           
        }

        private void LoadAllGrids()
        {
            blockList.Clear();
            openOrdersList.Clear();
            LoadAllBlocks();
            LoadAllOpenOrders();
        //    for (int y = 1; y < 20; y++)
        //    {
        //        Block Block = new Block();
        //        Block.BlockId = 2356 * y / 56 * 3;
        //        Block.Side = "Sell";
        //        Block.SecurityId = 1124;
        //        if (y % 2 == 0) Block.Status = "NEW"; else Block.Status = "PROPOSED";
        //        Block.LimitPrice = 124.23m * Convert.ToDecimal(y) / 10m; ;
        //        Block.StopPrice = 120.00m * Convert.ToDecimal(y) / 10m;
        //        Block.TotalQuantity = 7500;
        //        Block.OpenQuantity = 1500;
        //        Block.ExecutedQuantity = 6000;
        //        Block.Orders = new List<Orders>();

        //        for (int x = 1; x <= 3; x++)
        //        {
        //            Orders newOrder = new Orders();
        //            newOrder.BlockId = 22356;
        //            if (x / 2 == 0) newOrder.OrderId = x * 7;
        //            else newOrder.OrderId = x * 14;
        //            newOrder.SecurityId = 1124;
        //            newOrder.Side = "Sell";
        //            newOrder.LimitPrice = 124.23m + 1m * (Convert.ToDecimal(x) / 4m);
        //            newOrder.StopPrice = 120.00m + 1m * (Convert.ToDecimal(x) / 4m);
        //            Block.Orders.Add(newOrder);
        //        }

        //        BlockList.Add(Block);
        //    }


        //    for (int x = 1; x < 232; x++)
        //    {
        //        Orders newOrder = new Orders();
        //        newOrder.BlockId = null;
        //        if (x / 2 == 0) newOrder.OrderId = x * 7;
        //        else newOrder.OrderId = x * 14;
        //        newOrder.SecurityId = 1124;
        //        newOrder.Side = "Sell";
        //        newOrder.LimitPrice = 124.23m + 1m * (Convert.ToDecimal(x) / 4m);
        //        newOrder.StopPrice = 120.00m + 1m * (Convert.ToDecimal(x) / 4m);
        //        OpenOrders.Add(newOrder);
        //    }
        }


    }
}

       
       
        

