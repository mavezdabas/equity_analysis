//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DataAccessLayer
{
    public partial class OrderAllocation
    {
        #region Primitive Properties
    
        public virtual int AllocationID
        {
            get;
            set;
        }
    
        public virtual int ExecutionID
        {
            get { return _executionID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_executionID != value)
                    {
                        if (ExecutedBlock != null && ExecutedBlock.ExecutedBlockID != value)
                        {
                            ExecutedBlock = null;
                        }
                        _executionID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _executionID;
    
        public virtual int BlockID
        {
            get { return _blockID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_blockID != value)
                    {
                        if (Block != null && Block.BlockID != value)
                        {
                            Block = null;
                        }
                        _blockID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _blockID;
    
        public virtual int Status
        {
            get;
            set;
        }
    
        public virtual int AllocatedQuantity
        {
            get;
            set;
        }
    
        public virtual decimal TransactionFee
        {
            get;
            set;
        }
    
        public virtual decimal TransactionPrice
        {
            get;
            set;
        }
    
        public virtual Nullable<int> OrderID
        {
            get { return _orderID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_orderID != value)
                    {
                        if (Order != null && Order.OrderID != value)
                        {
                            Order = null;
                        }
                        _orderID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _orderID;

        #endregion
        #region Navigation Properties
    
        public virtual Block Block
        {
            get { return _block; }
            set
            {
                if (!ReferenceEquals(_block, value))
                {
                    var previousValue = _block;
                    _block = value;
                    FixupBlock(previousValue);
                }
            }
        }
        private Block _block;
    
        public virtual ExecutedBlock ExecutedBlock
        {
            get { return _executedBlock; }
            set
            {
                if (!ReferenceEquals(_executedBlock, value))
                {
                    var previousValue = _executedBlock;
                    _executedBlock = value;
                    FixupExecutedBlock(previousValue);
                }
            }
        }
        private ExecutedBlock _executedBlock;
    
        public virtual Order Order
        {
            get { return _order; }
            set
            {
                if (!ReferenceEquals(_order, value))
                {
                    var previousValue = _order;
                    _order = value;
                    FixupOrder(previousValue);
                }
            }
        }
        private Order _order;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupBlock(Block previousValue)
        {
            if (previousValue != null && previousValue.OrderAllocations.Contains(this))
            {
                previousValue.OrderAllocations.Remove(this);
            }
    
            if (Block != null)
            {
                if (!Block.OrderAllocations.Contains(this))
                {
                    Block.OrderAllocations.Add(this);
                }
                if (BlockID != Block.BlockID)
                {
                    BlockID = Block.BlockID;
                }
            }
        }
    
        private void FixupExecutedBlock(ExecutedBlock previousValue)
        {
            if (previousValue != null && previousValue.OrderAllocations.Contains(this))
            {
                previousValue.OrderAllocations.Remove(this);
            }
    
            if (ExecutedBlock != null)
            {
                if (!ExecutedBlock.OrderAllocations.Contains(this))
                {
                    ExecutedBlock.OrderAllocations.Add(this);
                }
                if (ExecutionID != ExecutedBlock.ExecutedBlockID)
                {
                    ExecutionID = ExecutedBlock.ExecutedBlockID;
                }
            }
        }
    
        private void FixupOrder(Order previousValue)
        {
            if (previousValue != null && previousValue.OrderAllocations.Contains(this))
            {
                previousValue.OrderAllocations.Remove(this);
            }
    
            if (Order != null)
            {
                if (!Order.OrderAllocations.Contains(this))
                {
                    Order.OrderAllocations.Add(this);
                }
                if (OrderID != Order.OrderID)
                {
                    OrderID = Order.OrderID;
                }
            }
            else if (!_settingFK)
            {
                OrderID = null;
            }
        }

        #endregion
    }
}