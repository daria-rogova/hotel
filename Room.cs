using System;

namespace Hotel
{
    public class Room
    {
	    public Guid Guid { get; set; }
	    public int Number { get; set; }
        public int AdultsCapacity { get; set; }
        public int ChildCapacity { get; set; }
        public RoomLevel Level { get; set; }
        public double Price { get; set; }
        public bool IsFree { get; set; }

        public Room()
        {
			Guid = Guid.NewGuid();
            AdultsCapacity = 2;
            ChildCapacity = 0;
            Level = RoomLevel.Economy;
            IsFree = true;
            Price = 0;
            Number = -1;
        }

        public Room(int Number, int AdultsCapacity, int ChildCapacity, RoomLevel RoomLevel, double Price, bool IsFree)
        {
			this.Guid = Guid.NewGuid();
            this.Number = Number;
            this.AdultsCapacity = AdultsCapacity;
            this.ChildCapacity = ChildCapacity;
            this.Level = RoomLevel;
            this.Price = Price;
            this.IsFree = IsFree;
        }
    }

}
