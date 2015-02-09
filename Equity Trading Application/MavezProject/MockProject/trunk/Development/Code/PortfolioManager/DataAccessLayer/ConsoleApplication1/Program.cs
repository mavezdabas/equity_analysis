using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceReference.IExecuteBlockService obj = new ServiceReference.ExecutedBlock(AutoAllocateService.SecurityConfigurationDetails);
            ServiceReference.ExecuteBlockServiceClient obj = new ServiceReference.ExecuteBlockServiceClient();
            ServiceReference.Block[] blockList = new ServiceReference.Block[10];
            obj.ExecuteBlock(blockList);

            
                  
        }
    }
}
