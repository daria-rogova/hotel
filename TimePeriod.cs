using System;

namespace Hotel
{
	public class TimePeriod
	{
		public DateTime StartDate { get; set;}
		public DateTime EndDate { get; set; }

		public TimePeriod()
		{
			
		}

		public TimePeriod(DateTime StartDate, DateTime EndDate)
		{
			this.StartDate = StartDate;
			this.EndDate = EndDate;
		}

		public bool IfIncludesPeriod(TimePeriod timePeriod)
		{
			if ((this.StartDate.CompareTo(timePeriod.StartDate) <= 0) && (this.EndDate.CompareTo(timePeriod.EndDate) >= 0))
				return true;
			return false;
		}

		public bool OverlapsWith(TimePeriod timePeriod)
		{
			if ((StartDate.CompareTo(timePeriod.StartDate) <= 0 && EndDate.CompareTo(timePeriod.StartDate) >= 0)
			    || (StartDate.CompareTo(timePeriod.EndDate) <= 0 && EndDate.CompareTo(timePeriod.EndDate) >= 0))
				return true;
			return false;
		}
	}
}