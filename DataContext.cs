using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public interface IDataContext 
    {
        void AddRoom(Room room);
        void AddDiscount(Discount discount);
	    void AddCustomer(Customer customer);
	    void AddReservation(Reservation reservation);

        List<Room> GetRooms();
        List<Discount> GetDiscounts();
	    List<Customer> GetCustomers();
	    List<Reservation> GetReservations();
    }

    public class DataContext : IDataContext
    {
        private readonly List<Room> _rooms;
        private readonly List<Discount> _discounts;
	    private readonly List<Customer> _customers;
	    private readonly List<Reservation> _reservetions;

        public DataContext() 
        {
	        _rooms = new List<Room>();
	        _discounts = new List<Discount>();
	        _customers = new List<Customer>();
	        _reservetions = new List<Reservation>();
        }

        public void AddRoom(Room room) 
        {
            _rooms.Add(room);
        }

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
        }

	    public void AddCustomer(Customer customer)
	    {
		    _customers.Add(customer);
	    }

	    public void AddReservation(Reservation reservation)
	    {
		    _reservetions.Add(reservation);
	    }

	    public List<Room> GetRooms() 
        {
            return _rooms;
        }

        public List<Discount> GetDiscounts()
        {
            return _discounts;
        }

	    public List<Customer> GetCustomers()
	    {
		    return _customers;
	    }

	    public List<Reservation> GetReservations()
	    {
		    return _reservetions;
	    }
    }

}
