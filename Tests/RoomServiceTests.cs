using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;

namespace Hotel
{

    [TestFixture]
    public class RoomServiceTests
    {
        private IDataContext _dataContext;
        private RoomService _roomService;
	    private IDateTimeService _dateTimeService;
	    private static DateTime _firstOfMay2017 = new DateTime(2017, 5, 1);

	    [SetUp]
        public void SetUp()
        {
            _dataContext = new DataContext();
			_dateTimeService = new DateTimeService();
            _roomService = new RoomService(_dataContext, _dateTimeService);
        }

        [Test]
        public void When_UserInputsValidDiscountCode_Expect_ServiceReturnsPricesWithDiscount() 
        {
            _dataContext.AddRoom(new Room(101, 2, 0, RoomLevel.Standard, 100, true));
            Discount discount = new Discount("10%", 0.9);
            _dataContext.AddDiscount(discount);
            string dicountCode = "10%";

            List<RoomViewModel> roomsViewModelsToReturn = _roomService.GetFreeRooms(dicountCode);

            Assert.AreEqual(_dataContext.GetRooms().First().Price * discount.DiscountMultiplier, roomsViewModelsToReturn.First().Price);
        }

        [Test]
        public void When_UserInputsInvalidDiscountCode_Expect_ServiceReturnsPricesWithDiscount()
        {
            _dataContext.AddRoom(new Room(101, 2, 0, RoomLevel.Standard, 100, true));
            string invalidDiscountCode = "16%";

            List<RoomViewModel> roomsViewModelsToReturn = _roomService.GetFreeRooms(invalidDiscountCode);

            Assert.AreEqual(_dataContext.GetRooms().First().Price, roomsViewModelsToReturn.First().Price);
        }

		//TODO: Ask questions on this test
		[Test]
	    public void When_UserInputsDiscountAndTimePeriod_Expect_ServiseReturnsNotReservedRooms()
	    {
			var freeRoom = new Room(101, 2, 0, RoomLevel.Economy, 1000, true);
			var freeRoomViewModel = new RoomViewModel{Price = freeRoom.Price, RoomLevel = freeRoom.Level};
			var reservedRoom = new Room(102, 2, 1, RoomLevel.Standard, 2000, true);
			_dataContext.AddRoom(freeRoom);
			_dataContext.AddRoom(reservedRoom);
			var reservedTimePeriod = new TimePeriod(_firstOfMay2017, _firstOfMay2017.AddDays(7));
			var reservation = new Reservation(reservedRoom, new Customer(), reservedTimePeriod);
			_dataContext.AddReservation(reservation);

		 
			var freeRooms = _roomService.GetFreeRooms(string.Empty, _firstOfMay2017, _firstOfMay2017);

			Assert.AreEqual(freeRoomViewModel.Price, freeRooms.Single().Price);
			Assert.AreEqual(freeRoomViewModel.RoomLevel, freeRooms.Single().RoomLevel);
	    }




    }
}
