using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTraderMainWindow.Model
{
   public class AllocatedOrdersModel
    {
        public int ExecutionId { get; set; }
        public int AllocationId { get; set; }
        public int BlockId { get; set; }
        public int Status { get; set; }
        public int AllocatedQuantity { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal TransactionPrice { get; set; }
        public BlockModel Block { get; set; }
        public ExecutedBlocksModel ExecutedBlock { get; set; }
        public OrderModel Order { get; set; }
    }
}
