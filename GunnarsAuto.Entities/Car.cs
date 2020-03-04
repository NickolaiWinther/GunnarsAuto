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
			set
			{
				var validationResult = ValidateMake(value);
				if (!validationResult.isValid)
					throw new ArgumentException(validationResult.errorMessage, nameof(Make));

				make = value;
			}
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

        #region Validation methods

        public static (bool isValid, string errorMessage) ValidateMake(string make)
		{
			if (make.Length < 2 || make == null)
				return (false, "Bilmærket må ikke være under 2 karaktere lang");

			if (make.Any(Char.IsDigit))
				return (false, "Bilmærket må ikke indeholde tal");

			return (true, String.Empty);
		}

		public static (bool isValid, string errorMessage) ValidateModel(string model)
		{
			if (model.Length < 2 || model == null)
				return (false, "Modellen må ikke være under 2 karaktere lang");

			if (model.Any(Char.IsDigit))
				return (false, "Modellen må ikke indeholde tal");

			return (true, String.Empty);
		}

		public static (bool isValid, string errorMessage) ValidateVIN(string vin)
		{
			if (vin.Length != 17 || vin == null)
				return (false, "Stelnummer skal være 17 karaktere lang");

			return (true, String.Empty);
		}
		public static (bool isValid, string errorMessage) ValidateRegistryNumber(string registryNumber)
		{
			if (registryNumber.Length != 7 || registryNumber == null)
				return (false, "Registreringsnummber skal være 7 karaktere lang");

			return (true, String.Empty);
		}

		#endregion
	}
}
