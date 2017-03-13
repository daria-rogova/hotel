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
        private IDataContext dataContext;
        private FreeRoomService freeRoomService;

        [SetUp]
        public void SetUp()
        {
            dataContext = new DataContext();
            freeRoomService = new FreeRoomService(dataContext);
        }

        [Test]
        public void When_UserInputsValidDiscountCode_Expect_ServiceReturnsPricesWithDiscount() 
        {
            dataContext.AddRoom(new Room(101, 2, 0, RoomLevel.Standard, 100, true));
            Discount discount = new Discount("10%", 0.9);
            dataContext.AddDiscount(discount);
            string dicountCode = "10%";

            List<RoomViewModel> roomsViewModelsToReturn = freeRoomService.GetFreeRooms(dicountCode);

            Assert.AreEqual(dataContext.GetRooms().First().Price * discount.DiscountMultiplier, roomsViewModelsToReturn.First().Price);
        }

        [Test]
        public void When_UserInputsInvalidDiscountCode_Expect_ServiceReturnsPricesWithDiscount()
        {
            dataContext.AddRoom(new Room(101, 2, 0, RoomLevel.Standard, 100, true));
            string invalidDiscountCode = "16%";

            List<RoomViewModel> roomsViewModelsToReturn = freeRoomService.GetFreeRooms(invalidDiscountCode);

            Assert.AreEqual(dataContext.GetRooms().First().Price, roomsViewModelsToReturn.First().Price);
        }




    }
}
