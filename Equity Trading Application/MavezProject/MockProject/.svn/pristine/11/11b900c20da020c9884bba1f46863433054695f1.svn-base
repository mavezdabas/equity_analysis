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
using EquityTradingApplication.ViewModels;
using System.ComponentModel;

namespace EquityTradingApplication.content
{
    /// <summary>
    /// Interaction logic for OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl 
    {
        public bool IsReadOnlyForEditableField { get; set; }
        public bool IsReadOnlyForNonEditableFields { get; set; }
        public bool IsReadOnlyForEditableFieldsForOpenOrder { get; set; }
        public bool IsEnabledForUserControlEditableFields { get; set; }
        public bool IsEnabledForUserControlNonEditableFields { get; set; }
        public string SaveButtonText { get; set; }
        public string CancelButtonText { get; set; }
        public string WindowName { get; set; }
        public OrderUserControl()
        {
            InitializeComponent();
            IsEnabled = true;
            IsReadOnlyForEditableField = false;
            IsReadOnlyForEditableFieldsForOpenOrder = false;
            IsReadOnlyForNonEditableFields = false;
            IsEnabledForUserControlEditableFields = true;
            IsEnabledForUserControlNonEditableFields = true;
            SaveButtonText = "Save";
            CancelButtonText = "Cancel";
        }

    
    }
}
