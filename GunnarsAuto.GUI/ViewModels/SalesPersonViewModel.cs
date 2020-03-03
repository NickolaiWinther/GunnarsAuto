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
    class SalesPersonViewModel : INotifyPropertyChanged
    {
        private SalesPerson selectedSalesPerson;
        private List<Sale> sales;
        private List<SalesPerson> salesPersons;

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


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
