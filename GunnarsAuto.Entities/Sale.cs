using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.Entities
{
    public class Sale
    {
		private int id;
		private decimal buyPrice;
		private decimal? sellPrice;
		private bool isSold;
		private SalesPerson salesPerson;
		private Car car;
		private DateTime buyDate;
		private DateTime? sellDate;

		/// <summary>
		/// Should only be used in SaleRepository
		/// </summary>
		public Sale() { }

		public Sale(int id, decimal buyPrice, decimal sellPrice, bool isSold, SalesPerson salesPerson, Car car)
		{
			Id = id;
			BuyPrice = buyPrice;
			SellPrice = sellPrice;
			IsSold = isSold;
			SalesPerson = salesPerson;
			Car = car;
		}

		public Sale(decimal buyPrice, SalesPerson salesPerson, Car car)
		{
			BuyPrice = buyPrice;
			SalesPerson = salesPerson;
			Car = car;

		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public decimal BuyPrice
		{
			get { return buyPrice; }
			set { buyPrice = value; }
		}

		public decimal? SellPrice
		{
			get { return sellPrice; }
			set { sellPrice = value; }
		}
		public DateTime BuyDate
		{
			get { return buyDate; }
			set { buyDate = value; }
		}

		public DateTime? SellDate
		{
			get { return sellDate; }
			set { sellDate = value; }
		}

		public bool IsSold
		{
			get { return isSold; }
			set { isSold = value; }
		}

		public SalesPerson SalesPerson
		{
			get { return salesPerson; }
			set { salesPerson = value; }
		}

		public Car Car
		{
			get { return car; }
			set { car = value; }
		}


		#region Validation Methods





		#endregion
	}
}
