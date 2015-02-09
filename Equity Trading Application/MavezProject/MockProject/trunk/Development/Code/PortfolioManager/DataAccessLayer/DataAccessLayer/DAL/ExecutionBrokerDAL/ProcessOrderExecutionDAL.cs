using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class ProcessOrderExecutionDAL:IProcessOrderExecutionDAL
    {

        public void UpdateInBlockTable(Block blockToUpdate)
        {
            using (EquityTradingDBEntities ctx = new EquityTradingDBEntities())
            {
                ctx.Blocks.Attach(blockToUpdate);
                ctx.ObjectStateManager.ChangeObjectState(blockToUpdate, System.Data.EntityState.Modified);
                ctx.SaveChanges();
            }
        }

        public void UpdateExecutedBlockInTable(ExecutedBlock blockToUpdate)
        {
            using (EquityTradingDBEntities update = new EquityTradingDBEntities())
            {
                update.ExecutedBlocks.Attach(blockToUpdate);
                update.ObjectStateManager.ChangeObjectState(blockToUpdate, System.Data.EntityState.Modified);
                update.SaveChanges();
            }
        }

        public void InsertExecutedBlockInTable(ExecutedBlock blockToUpdate)
        {
            using (EquityTradingDBEntities update = new EquityTradingDBEntities())
            {
                update.ExecutedBlocks.AddObject(blockToUpdate);
                update.SaveChanges();
            }
        }
    }
}
