﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
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
			};
		}

		public void AddReservation(Reservation reservation)
		{
			_dataContext.AddReservation(reservation);
		}

	}
}
