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
using ExecutionTraderMainWindow.Helpers;

namespace ExecutionTraderMainWindow.Views
{
    /// <summary>
    /// Interaction logic for EditBlockView.xaml
    /// </summary>
    public partial class EditBlockView : Window, IModalWindow
    {
        public EditBlockView()
        {
            InitializeComponent();
        }

        private void ExpanderCollapse(object sender, RoutedEventArgs e)
        {
            EditBlockDataGrid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
        }

        private void ExpanderExpanded(object sender, RoutedEventArgs e)
        {
            EditBlockDataGrid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
        }

      
    }
}
