using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquityTradingApplication.Exceptions
{
    class CustomException:Exception
    {
        public string exceptionMessage;
        public CustomException()
        {

        }

        public CustomException(string exceptionMessage)
        {
            this.exceptionMessage = exceptionMessage;
        }
    }
}
