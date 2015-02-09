using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class ExecutedBlockDAL : IExecutedBlockDAL
    {


        public void UpdateExecutedBlock(ExecutedBlock executedBlockToUpdate)
        {
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                context.ExecutedBlocks.Attach(executedBlockToUpdate);
                context.ObjectStateManager.ChangeObjectState(executedBlockToUpdate, System.Data.EntityState.Modified);
                context.SaveChanges();
            }
        }


        public ExecutedBlock GetBlockFromTable()
        {
            ExecutedBlock blockToExpire = null;
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                blockToExpire = (from block in context.ExecutedBlocks
                                 where block.Status == 1
                                 select block).FirstOrDefault();
            }
            return blockToExpire;
        }
    }
}
