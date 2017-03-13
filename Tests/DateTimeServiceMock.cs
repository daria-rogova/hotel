using System;

namespace Hotel.Tests
{
	public class DateTimeServiceMock : IDateTimeService
	{
		private static DateTime _todayDateTime = new DateTime(1980, 4, 1);

		public DateTime Today()
		{
			return _todayDateTime;
		}
	}
}