using GunnarsAuto.Entities;
using GunnarsAuto.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GunnarsAuto.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SalesPersonViewModel salesPersonViewModel = new SalesPersonViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = salesPersonViewModel;
        }

        private void CreateCarButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCarWindow createCarWindow = new CreateCarWindow();
            createCarWindow.Show();
        }

        private void SalesPersonsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            salesPersonViewModel.SelectedSalesPerson = SalesPersonsComboBox.SelectedItem as SalesPerson;
            SalesDataGrid.ItemsSource = salesPersonViewModel.Sales;
            CreateCarButton.IsEnabled = true;
            
        }
    }
}
