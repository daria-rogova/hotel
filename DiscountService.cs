using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
	public class DiscountService
	{
		private IDateTimeService _dateTimeService;

		public Discount BirthdayDiscount { get; set; }

		public DiscountService(IDateTimeService dateTimeService)
		{
			_dateTimeService = dateTimeService;
		}

		public List<Discount> CheckForDiscounts(Customer customer)
		{
			var discounts = new List<Discount>();
			CheckForBirthdayDiscount(customer, discounts);
			return discounts;
		}

		private void CheckForBirthdayDiscount(Customer customer, List<Discount> discounts)
		{
			var today = _dateTimeService.Today();
			if (customer.DateOfBirth.Month == today.Month && customer.DateOfBirth.Day == today.Day)
				discounts.Add(BirthdayDiscount);
		}
	}
}
