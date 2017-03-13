using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Hotel.Tests
{
	[TestFixture]
	public class TimePeriodTests
	{
		private TimePeriod _year2012Period;

		[SetUp]
		public void SetUp()
		{
			_year2012Period = new TimePeriod { EndDate = new DateTime(2012, 12, 31), StartDate = new DateTime(2012, 1, 1) };
		}

		[Test]
		public void IncludePeriod_ReturnsTrue_ForEqualTimePeriods()
		{
			var period = new TimePeriod{EndDate = new DateTime(2012, 12, 31), StartDate = new DateTime(2012,1,1)};

			var ifIncludesPeriod = _year2012Period.IfIncludesPeriod(period);

			Assert.IsTrue(ifIncludesPeriod);
		}

		[Test]
		public void IncludePeriod_ReturnsFalse_IfPeriodDoesntIncludeOtherPeriod()
		{
			var period = new TimePeriod{EndDate = new DateTime(2011, 12, 31), StartDate = new DateTime(2011, 1, 1)};
			
			var ifIncludesPeriod = _year2012Period.IfIncludesPeriod(period);

			Assert.IsFalse(ifIncludesPeriod);
		}

		[Test]
		public void OverlapsWith_ReturnsFalse_ForNotOverlappigTimePeriods()
		{
			var period = new TimePeriod { EndDate = new DateTime(2011, 12, 31), StartDate = new DateTime(2011, 1, 1) };

			var ifOverlaps = _year2012Period.OverlapsWith(period);

			Assert.IsFalse(ifOverlaps);
		}

		[Test]
		public void OverlapsWith_ReturnsTrue_ForOverlappigTimePeriods()
		{
			var period = new TimePeriod { EndDate = new DateTime(2013, 11, 1), StartDate = new DateTime(2012, 6, 1) };

			var ifOverlaps = _year2012Period.OverlapsWith(period);

			Assert.IsTrue(ifOverlaps);
		}

		[Test]
		public void OverlapsWith_ReturnsTrue_IfAPeriodIncludsAnotherPeriod()
		{
			var period = new TimePeriod { EndDate = new DateTime(2012, 11, 1), StartDate = new DateTime(2012, 6, 1) };

			var ifOverlaps = _year2012Period.OverlapsWith(period);

			Assert.IsTrue(ifOverlaps);
		}
	}
}
