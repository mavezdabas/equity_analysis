using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccessLayer;

namespace AutoAllocationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurityMarketPrice" in both code and config file together.
    
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface ISecurityMarketPrice
    {
        [OperationContract(IsOneWay = true)]
        void GetMarketPrice();
    }
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendResult(List<AutoAllocationService.SecurityMarketPrice.SecurityForClient> result);

        //[OperationContract(IsOneWay = true)]
        //void SendResult(List<Security> result);
    }



}
