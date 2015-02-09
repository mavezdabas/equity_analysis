using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public interface IProcessOrderExecutionDAL
    {
        void UpdateInBlockTable(Block blockToUpdate);
        void UpdateExecutedBlockInTable(ExecutedBlock blockToUpdate);
        void InsertExecutedBlockInTable(ExecutedBlock blockToUpdate);
    }
}
