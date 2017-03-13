using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
	public class CustomerService
	{
		private readonly IDataContext dataContext;

		public CustomerService(IDataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		public List<Customer> GetCustomers()
		{
			return dataContext.GetCustomers();
		}

		public bool AddCustomer(Customer customer)
		{
			if (!dataContext.GetCustomers()
				.Any(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName
				          && c.DateOfBirth.Equals(customer.DateOfBirth)))
			{
				dataContext.AddCustomer(customer);
				return true;
			}
			return false;
		}
	}
}
