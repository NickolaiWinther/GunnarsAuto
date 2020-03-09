using GunnarsAuto.DAL;
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
    /// Interaction logic for SellCar.xaml
    /// </summary>
    public partial class SellCarWindow : Window
    {
        SalesViewModel SalesViewModel;
        public SellCarWindow(SalesViewModel salesViewModel)
        {
            InitializeComponent();
            DataContext = salesViewModel;
            SalesViewModel = salesViewModel;


            //salesViewModel.SellCar();
        }


        private void SellCarButton_Click(object sender, RoutedEventArgs e)
        {
            new SaleRepository().UpdateSale(SalesViewModel.SelectedSale);
            MessageBox.Show("Bilen er solgt!", "Solgt", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
