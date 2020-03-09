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
        SalesViewModel salesViewModel = new SalesViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = salesViewModel;
        }

        private void CreateCarButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCarWindow createCarWindow = new CreateCarWindow(salesViewModel);
            createCarWindow.ShowDialog();
            SalesDataGrid.ItemsSource = salesViewModel.Sales;
        }

        private void SalesPersonsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            salesViewModel.SelectedSalesPerson = SalesPersonsComboBox.SelectedItem as SalesPerson;
            SalesDataGrid.ItemsSource = salesViewModel.Sales;
            CreateCarButton.IsEnabled = true;
            
        }

        private void SellCarButton_Click(object sender, RoutedEventArgs e)
        {
            SellCarWindow sellCarWindow = new SellCarWindow(salesViewModel);
            sellCarWindow.ShowDialog();
            SalesDataGrid.ItemsSource = salesViewModel.Sales;
            SellCarButton.IsEnabled = false;
        }

        private void SalesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            salesViewModel.SelectedSale = SalesDataGrid.SelectedItem as Sale;
            if (salesViewModel.SelectedSale is null|| salesViewModel.SelectedSale.IsSold == false)
            {
                SellCarButton.IsEnabled = true;
            }
            else
            {
                SellCarButton.IsEnabled = false;
            }
        }
    }
}
