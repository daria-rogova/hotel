using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Hotel.Tests
{
	[TestFixture]
	public class ReservationServiceTests
	{
		private IDataContext _dataContext;
		private ReservationService _reservationService;

		
		[SetUp]
		public void SetUp()
		{
			_dataContext = new DataContext();
			_reservationService = new ReservationService(_dataContext);
		}

		private void FillReservation(Reservation reservation)
		{
			reservation.Room = new Room(201, 2, 0, RoomLevel.Economy, 1000, true);
			reservation.Customer = new Customer
			{
				Guid = Guid.NewGuid(),
				DateOfBirth = new DateTime(1980, 1, 2),
				FirstName = "Jhon",
				LastName = "Gray"
			};
			reservation.TimePeriod = new TimePeriod{StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(7)};
		}


		[Test]
		public void Should_ReturnRservationWithNotEmptyGuid()
		{
			var reservation = _reservationService.CreateReservation();
			
			Assert.AreNotEqual(Guid.Empty, reservation.Guid);
		}

		[Test]
		public void Should_AddReservation()
		{
			var reservation = _reservationService.CreateReservation();
			FillReservation(reservation);
			
			_reservationService.AddReservation(reservation);

			Assert.AreEqual(_dataContext.GetReservations().Single(), reservation);
		}
	}
}
