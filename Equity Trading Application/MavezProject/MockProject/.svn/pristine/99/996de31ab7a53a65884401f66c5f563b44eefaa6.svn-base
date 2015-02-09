using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquityTradingApplication.Helpers
{
   public class CustomEventHelper
    {
        public delegate void RequestCloseEventHandler(
     RequestCloseEventArgs e);

        public class RequestCloseEventArgs
        {
            public bool DialogResult { get; set; }

            public RequestCloseEventArgs(bool dialogResult)
            {
                this.DialogResult = dialogResult;
            }
        }
    }
}
