using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer;

namespace AutoAllocationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExecuteBlockService" in both code and config file together.
    [ServiceContract]
    public interface IExecuteBlockService
    {
        [OperationContract]
        ConfirmationMessage ExecuteBlock(List<Block> blockList);
        [OperationContract]
        void ExecutionOfBlock(List<Block> blockListToExecute);
        [OperationContract]
        void Polling();
    }

    [DataContract]
    public class ConfirmationMessage
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
