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
using System.Windows.Shapes;
using PortfolioManagerWindow.Helpers;
using PortfolioManager.ViewModels;

namespace PortfolioManager.Views
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window,IModelWindow
    {
        public CreateOrder()
        {
            InitializeComponent();
            CreateOrderViewModel vModel = new CreateOrderViewModel();
            this.DataContext = vModel;
            vModel.Close += new Action(vModel_Close);
        }

        void vModel_Close()
        {
            this.Close();
        }
    }
}
