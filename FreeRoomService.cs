using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class FreeRoomService
    {
        private IDataContext _dataContext;

        public FreeRoomService(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public List<RoomViewModel> GetFreeRooms(string discountCode)
        {
            var rooms = _dataContext.GetRooms();
	        var reservations = _dataContext.GetReservations();
	        var todayTimePeriod = new TimePeriod {StartDate = DateTime.Today, EndDate = DateTime.Today};
			var freeRooms = rooms.Where(r => !reservations.Any(rsv => rsv.Room == r && rsv.TimePeriod.IfIncludesPeriod(todayTimePeriod)));

            var discount = _dataContext.GetDiscounts().FirstOrDefault(d => d.DiscountCode == discountCode);

            if (discount != null)
            {
				var freeRoomViewModels = freeRooms.ToList().Select(r => new RoomViewModel { Price = r.Price * discount.DiscountMultiplier, RoomLevel = r.Level });
                return freeRoomViewModels.ToList();
            }
            return rooms.Select(r => new RoomViewModel{Price = r.Price, RoomLevel = r.Level}).ToList();
        }

	    public List<RoomViewModel> GetFreeRooms(string discountCode, DateTime startDate, DateTime endDate)
	    {
			var askedTimePeriod = new TimePeriod{StartDate = startDate, EndDate = endDate};
		    
			var allrooms = _dataContext.GetRooms();
		    var reservations = _dataContext.GetReservations();
		    
			var roomsToReturn = allrooms.Where(r => !reservations.Any(rsv => rsv.Room == r && !rsv.TimePeriod.OverlapsWith(askedTimePeriod)));
			
			return roomsToReturn.Select(r => new RoomViewModel{RoomLevel = r.Level, Price = r.Price}).ToList();
	    }



    }
}
