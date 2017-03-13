using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Hotel
{
	[TestFixture]
	public class CustomerServiceTests
	{
		private DataContext _dataContext;
		private CustomerService _customerService;

		[SetUp]
		public void SetUp()
		{
			_dataContext = new DataContext();
			_customerService = new CustomerService(_dataContext);
		}

		[Test]
		public void testAddNewCustomer()
		{
			var customer = new Customer
			{
				Guid = Guid.NewGuid(),
				DateOfBirth = new DateTime(1970, 1, 1),
				FirstName = "Jhon",
				LastName = "Gray"
			};

			_customerService.AddCustomer(customer);

			Assert.AreEqual(customer, _dataContext.GetCustomers().FirstOrDefault());
		}


		[Test]
		public void testReturnAllCustomers()
		{
			var customer1 = new Customer
			{
				Guid = Guid.NewGuid(),
				DateOfBirth = new DateTime(1970, 1, 1),
				FirstName = "Jhon",
				LastName = "Gray"
			};
			var customer2 = new Customer
			{
				Guid = Guid.NewGuid(),
				DateOfBirth = new DateTime(1950, 2, 1),
				FirstName = "Irvin",
				LastName = "Show"
			};
			_dataContext.AddCustomer(customer1);
			_dataContext.AddCustomer(customer2);

			var customersToReturn = _customerService.GetCustomers();

			Assert.AreEqual(2, customersToReturn.Count);
		}

		[Test]
		public void testDoNotAddCustomersWithSameFullNameAndSameDateOfBirth()
		{
			var customer = new Customer
			{
				Guid = Guid.NewGuid(),
				DateOfBirth = new DateTime(1970, 1, 1),
				FirstName = "Jhon",
				LastName = "Gray"
			};
			var customerWithSameNameAndDateOfBirth = new Customer
			{
				Guid = Guid.NewGuid(),
				DateOfBirth = new DateTime(1970, 1, 1),
				FirstName = "Jhon",
				LastName = "Gray"
			};

			_customerService.AddCustomer(customer);

			Assert.AreEqual(false, _customerService.AddCustomer(customerWithSameNameAndDateOfBirth));
		}
	}
}
