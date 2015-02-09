using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace BrokerSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
        ServiceReference.MyServiceClient obj;
        public MainWindow()
        {
            InitializeComponent();
            obj = new ServiceReference.MyServiceClient();
            timer.Interval = new TimeSpan(0, 0, 10);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            obj.GetData();
        }
    }
}
