using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
	//Из ООП используется инкапсуляция
	//Из SOLID - DIP, так как ReservationService не зависит от реализации IDataContext
	public class ReservationService
	{
		private IDataContext _dataContext;

		public ReservationService(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public Reservation CreateReservation()
		{
			return new Reservation
			{
				Guid = Guid.NewGuid(),
				Room = null,
				TimePeriod = null,
				Customer = null
			};
		}

		public void AddReservation(Reservation reservation)
		{
			_dataContext.AddReservation(reservation);
		}

	}
}
