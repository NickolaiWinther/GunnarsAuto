using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.Entities
{
    public class Car
    {
		private int id;
		private string make;
		private string model;
		private string vin;
		private string registryNumber;
		private bool isUsed;

		/// <summary>
		/// Should only be used in CarRepository
		/// </summary>
		public Car() { }

		public Car(int id, string make, string model, string vin, string registryNumber, bool isUsed)
		{
			Id = id;
			Make = make;
			Model = model;
			VIN = vin;
			RegistryNumber = registryNumber;
			IsUsed = isUsed;
		}

		public Car(string make, string model, string vin, string registryNumber, bool isUsed)
		{
			Make = make;
			Model = model;
			VIN = vin;
			RegistryNumber = registryNumber;
			IsUsed = isUsed;
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Make
		{
			get { return make; }
			set { make = value; }
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public string VIN
		{
			get { return vin; }
			set { vin = value; }
		}

		public string RegistryNumber
		{
			get { return registryNumber; }
			set { registryNumber = value; }
		}

		public bool IsUsed
		{
			get { return isUsed; }
			set { isUsed = value; }
		}
	}
}
