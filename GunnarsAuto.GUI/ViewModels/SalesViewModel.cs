using GunnarsAuto.DAL;
using GunnarsAuto.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.GUI.ViewModels
{
    public class SalesViewModel : INotifyPropertyChanged
    {
        private SalesPerson selectedSalesPerson;
        private List<Sale> sales;
        private List<SalesPerson> salesPersons;
        private Sale selectedSale;

        public SalesPerson SelectedSalesPerson
        {
            get { return selectedSalesPerson; }
            set
            {
                selectedSalesPerson = value;
                OnPropertyChanged(nameof(SelectedSalesPerson));
            }
        }

        public List<Sale> Sales
        {
            get
            {
                sales = new SaleRepository().GetSalesBySalesPersonsId(SelectedSalesPerson);
                return sales;
            }
            set
            {
                sales = value;
            }
        }

        public List<SalesPerson> SalesPersons
        {
            get
            {
                salesPersons = new SalesPersonRepository().GetAllSalesPersons();
                return salesPersons;
            }
            set
            {
                salesPersons = value;
            }
        }

        public Sale SelectedSale
        {
            get { return selectedSale; }
            set
            {
                selectedSale = value;
                OnPropertyChanged(nameof(SelectedSale));
            }
        }


        public void CreateSale(Sale newSale)
        {
            SaleRepository saleRepository = new SaleRepository();
            newSale.SalesPerson = SelectedSalesPerson;
            saleRepository.CreateSale(newSale);
        }

        public void SellCar(Sale sale)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
