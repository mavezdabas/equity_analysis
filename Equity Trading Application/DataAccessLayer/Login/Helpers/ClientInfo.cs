using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Input;

namespace EquityTradingApplication.Helpers
{
    public class ClientInfo
    {
        public ClientInfo()
        {

        }

        public ImageSource Image { get; set; }
        public ICommand OpenCommand { get; set; }
        public string ClientName { get; set; }
    }
}
