using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
	public class Customer
	{
		public Guid Guid { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Customer()
		{
			Guid = Guid.NewGuid();
			FirstName = String.Empty;
			LastName = String.Empty;
			DateOfBirth = DateTime.MinValue;
		}
	}
}
