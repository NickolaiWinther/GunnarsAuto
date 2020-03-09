using GunnarsAuto.DAL;
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
using System.Windows.Shapes;

namespace GunnarsAuto.GUI
{
    /// <summary>
    /// Interaction logic for CreateCarWindow.xaml
    /// </summary>
    public partial class CreateCarWindow : Window
    {
        SalesViewModel salesViewModel;
        public CreateCarWindow(SalesViewModel salesViewModel)
        {
            this.salesViewModel = salesViewModel;
            InitializeComponent();
            DataContext = this.salesViewModel;
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            Sale newSale = new Sale()
            {
                BuyPrice = decimal.Parse(BuyPriceTextBox.Text),
                Car = new Car()
                {
                    Make = MakeTextBox.Text,
                    Model = ModelTextBox.Text,
                    VIN = VINTextBox.Text,
                    RegistryNumber = RegistryNumberTextBox.Text,
                    IsUsed = (bool)IsUsedCheckBox.IsChecked
                }
            };
            salesViewModel.CreateSale(newSale);
            MessageBox.Show("Oprettelse lykkedes!", "Opret", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
