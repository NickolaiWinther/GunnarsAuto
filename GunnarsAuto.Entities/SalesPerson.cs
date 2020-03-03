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
			FirstName = firstName;
			Lastname = lastname;
			Initials = initials;
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string FirstName
		{
			get { return firstname; }
			set { firstname = value; }
		}

		public string Lastname
		{
			get { return lastname; }
			set { lastname = value; }
		}

		public string Initials
		{
			get { return initials; }
			set { initials = value; }
		}
	}
}
