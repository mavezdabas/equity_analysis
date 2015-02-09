using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTraderMainWindow.Model
{
    public class PortfolioModel
    {

        public int PortfolioID
        {
            get;
            set;
        }


        public string PortfolioName
        {
            get;
            set;
        }


        public Nullable<int> ClientID
        {
            get;
            set;
        }
    }
}
