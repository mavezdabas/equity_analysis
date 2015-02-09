using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public interface IBlockDAL
    {
        List<Block> GetAllPartiallyExecutedBlock();
        
    }
}
