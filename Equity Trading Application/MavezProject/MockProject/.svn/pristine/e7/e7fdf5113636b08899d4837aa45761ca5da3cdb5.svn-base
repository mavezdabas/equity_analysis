using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ExecutionTraderDataAccessLayer;
using ExecutionTraderMainWindow.Model;

namespace ExecutionTraderMainWindow.ViewModel
{
    public class AllocatedOrdersViewModel:ViewModelBase
    {
        private AllocatedOrdersModel allocatedOrder;
        public ObservableCollection<AllocatedOrdersModel> AllocatedOrders { get; set; }
        public ObservableCollection<ExecutedBlocksModel> ExecutedBlocks { get; set; }
        public ObservableCollection<OrderModel> Orders { get; set; }
        public AllocatedOrdersViewModel()
        {
            AllocatedOrders = new ObservableCollection<AllocatedOrdersModel>();
            ExecutedBlocks = new ObservableCollection<ExecutedBlocksModel>();
            Orders = new ObservableCollection<OrderModel>();
        }



        public int AllocationId
        {
            get { return allocatedOrder.AllocationId; }
            set { allocatedOrder.AllocationId = value;
            RaisePropertyChanged("AllocationId");
            }
        }
       

        public int ExecutionId
        {
            get { return allocatedOrder.ExecutionId; }
            set { allocatedOrder.ExecutionId= value;
            RaisePropertyChanged("ExecutionId");
            }
        }

        

        public int BlockId
        {
            get { return allocatedOrder.BlockId; }
            set { allocatedOrder.BlockId = value;
            RaisePropertyChanged("BlockId");
            }
        }

        public int OrderId
        {
            get { return OrderId; }
            set
            {
                OrderId = value;
                RaisePropertyChanged("OrderId");
            }
        }

        public int Status
        {
            get { return allocatedOrder.Status; }
            set { allocatedOrder.Status = value;
            RaisePropertyChanged("Status");
            }
        }

      
        public string Side
        {
            get { return Side; }
            set { Side = value;
            RaisePropertyChanged("Side");
            }
        }
        

        public int AllocatedQuantity
        {
            get { return allocatedOrder.AllocatedQuantity; }
            set { allocatedOrder.AllocatedQuantity = value;
            RaisePropertyChanged("AllocatedQuantity");
            }
        }

        
        public int Symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        
        public int PortfolioManager
        {
            get { return PortfolioManager; }
            set { PortfolioManager = value; }
        }
        
        
        
        

    }
}
