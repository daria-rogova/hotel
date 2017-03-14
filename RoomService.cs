using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
	//В этом классе используется парадигма ООП:
	// полиморфизм: методы GetFreeRooms имеют одинаковое имя и разные входные параметры
	//Инкапсуляция: RoomService использует IDataContext, для корректного использования IDataContext _dataContext
	//Имеет модификатор доступа Private


	//SOLID -> DIP -> RoomService не зависит от реализации IDataContext и IDateTimeService

    public class RoomService
    {
        private IDataContext _dataContext;
	    private IDateTimeService _dateTimeService;

	    public RoomService(IDataContext dataContext, IDateTimeService dateTimeService)
        {
            this._dataContext = dataContext;
	        this._dateTimeService = dateTimeService;
        }

        public List<RoomViewModel> GetFreeRooms(string discountCode)
        {
            var rooms = _dataContext.GetRooms();
	        var reservations = _dataContext.GetReservations();
	        var todayTimePeriod = new TimePeriod (_dateTimeService.Today(), _dateTimeService.Today());
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
			var askedTimePeriod = new TimePeriod(startDate, endDate);
		    
			var allrooms = _dataContext.GetRooms();
		    var reservations = _dataContext.GetReservations();
		    
			var roomsToReturn = allrooms.Where(r => !reservations.Any(rsv => rsv.Room == r && rsv.TimePeriod.OverlapsWith(askedTimePeriod)));

		    var discount = _dataContext.GetDiscounts().FirstOrDefault(d => d.DiscountCode == discountCode);

		    if (discount != null)
		    {
				var freeRoomViewModels = roomsToReturn.ToList().Select(r => new RoomViewModel { Price = r.Price * discount.DiscountMultiplier, RoomLevel = r.Level });
			    return freeRoomViewModels.ToList();
		    }

			return roomsToReturn.Select(r => new RoomViewModel{RoomLevel = r.Level, Price = r.Price}).ToList();
	    }

    }
}
