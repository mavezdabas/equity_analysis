using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTraderMainWindow.Helpers
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
