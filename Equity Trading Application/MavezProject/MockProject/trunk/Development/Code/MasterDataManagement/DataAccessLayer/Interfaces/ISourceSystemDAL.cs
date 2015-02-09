using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonContracts;

namespace DataAccessLayer.Interfaces
{
    public interface ISourceSystemDAL
    {

        List<SourceSystemPOCO> DisplaySourceSystemName();
        string GetSourceSystemName(int sourceSystemId);
    }
}
