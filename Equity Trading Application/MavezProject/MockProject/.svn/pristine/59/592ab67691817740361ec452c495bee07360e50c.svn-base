using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DAL.ExecutionBrokerDAL
{
    public class BlockDAL : IBlockDAL
    {

        public List<Block> GetAllPartiallyExecutedBlock()
        {
            List<Block> blockList = null;
            using (EquityTradingDBEntities context = new EquityTradingDBEntities())
            {
                blockList = (from block in context.Blocks
                             where block.BlockStatus == 5 || block.BlockStatus == 2 //Partially Executed Block
                             select block).ToList();
                
            }
            return blockList;
        }

        
    }
}
