using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.Entities
{
    public class SalesPerson
    {
		private int id;
		private string firstname;
		private string lastname;
		private string initials;

		/// <summary>
		/// Should only be used in SalesPersonRepository
		/// </summary>
		public SalesPerson() { }

		public SalesPerson(int id, string firstName, string lastname, string initials)
		{
			Id = id;
			Firstname = firstName;
			Lastname = lastname;
			Initials = initials;
		}

        #region Properties

        public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Firstname
		{
			get { return firstname; }
			set {
				var validationResult = ValidateFirstname(value);
				if (!validationResult.isValid)
					throw new ArgumentException(validationResult.errorMessage, nameof(Firstname));

				firstname = value;
			}
		}

		public string Lastname
		{
			get { return lastname; }
			set
			{
				var validationResult = ValidateLastname(value);
				if (!validationResult.isValid)
					throw new ArgumentException(validationResult.errorMessage, nameof(Lastname));

				lastname = value;
			}
		}

		public string Initials
		{
			get { return initials; }
			set
			{
				var validationResult = ValidateLastname(value);
				if (!validationResult.isValid)
					throw new ArgumentException(validationResult.errorMessage, nameof(Initials));

				initials = value;
			}
		}

        #endregion


        #region Validation methods

        public static (bool isValid, string errorMessage) ValidateFirstname(string firstname)
		{
			if (firstname.Length < 2 || firstname == null)
				return (false, "Fornavnet må ikke være under 2 karaktere lang");

			if (firstname.Any(Char.IsDigit))
				return (false, "Fornavnet må ikke indeholde tal");

			return (true, String.Empty);
		}

		public static (bool isValid, string errorMessage) ValidateLastname(string lastname)
		{
			if (lastname.Length < 2 || lastname == null)
				return (false, "Efternavnet må ikke være under 2 karaktere lang");

			if (lastname.Any(Char.IsDigit))
				return (false, "Efternavnet må ikke indeholde tal");

			return (true, String.Empty);
		}

		public static (bool isValid, string errorMessage) ValidateInitials(string initials)
		{
			if (initials.Length != 4 || initials == null)
				return (false, "Initialer skal være 4 karaktere lang");

			if (initials.Any(Char.IsDigit))
				return (false, "Initialer må ikke indeholde tal");

			return (true, String.Empty);
		}

		#endregion
	}
}
