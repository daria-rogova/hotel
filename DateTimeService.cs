using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
	public interface IDateTimeService
	{
		DateTime Today();
	}

	public class DateTimeService : IDateTimeService
	{
		public DateTime Today()
		{
			return DateTime.Today;
		}
	}
	
}
