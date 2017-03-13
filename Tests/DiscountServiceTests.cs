using System;
using System.Linq;
using NUnit.Framework;

namespace Hotel.Tests
{
	[TestFixture]
	class DiscountServiceTests
	{

		[Test]
		public void Should_ReturnBirdayDiscount_IfTodayIsCustomersBirthday()
		{
			var customer = new Customer();
			customer.DateOfBirth = new DateTime(1980, 4, 1);
			var _dateTimeServiceMock = new DateTimeServiceMock();
			var discountService = new DiscountService(_dateTimeServiceMock);
			var birthdayDiscount = new Discount("Birthday", 0.95);
			discountService.BirthdayDiscount = birthdayDiscount;

			var discountsToReturn = discountService.CheckForDiscounts(customer);

			Assert.AreEqual(birthdayDiscount, discountsToReturn.Single());
		}
	}
}

