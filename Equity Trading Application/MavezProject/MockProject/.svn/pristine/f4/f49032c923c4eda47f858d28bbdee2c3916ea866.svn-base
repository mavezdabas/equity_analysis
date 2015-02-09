using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExecutionTraderDataAccessLayer;
using System.Collections.ObjectModel;
using ExecutionTraderMainWindow.Model;
using ExecutionTraderMainWindow.Helpers;
using System.Windows.Input;
using ExecutionTraderMainWindow.Commands;

namespace ExecutionTraderMainWindow.ViewModel
{
    class AddOrdersToBlockViewModel
    {
        public ObservableCollection<BlockModel> blockList { get; set; }
        ExecutionTraderDAL dalObject;
        List<Order> ordersList;
        public Block selectedBlock { get; set; }
        public AddOrdersToBlockViewModel(List<Order> orders)
        {
            int securityID = orders[0].SecurityID;
            string side = orders[0].Side;
            dalObject = new ExecutionTraderDAL();
            blockList = new ObservableCollection<BlockModel>();
            ordersList = new List<Order>();
            ordersList = orders;

            foreach (var block in dalObject.GetBlocksBySecurityIDAndSide(securityID, side))
            {
                blockList.Add(Converter.ConvertBlockToBlockModel(block));
            }
        }

        private ICommand addToBlockCmnd;

        public ICommand AddToBlockCmnd
        {
            get
            {
                if (addToBlockCmnd == null)
                    addToBlockCmnd = new RelayCommand(p => AddToBlock());
                return addToBlockCmnd;
            }

        }
        void AddToBlock()
        {
            dalObject = new ExecutionTraderDAL();
            foreach (var order in ordersList)
            {
                order.BlockID = selectedBlock.BlockID;
            }
            dalObject.UpdateOrders(ordersList);
            


        }
    }
}
