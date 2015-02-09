using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        ServiceHost host = null;
        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(EquityTradingService.PortfolioService));
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
            host = null;
        }
    }
}
