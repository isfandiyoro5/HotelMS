namespace TestHotel.DataAccess.Model
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int HotelId { get; set; }

        public int GuestId { get; set; }

        public List<int> RoomsId { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }


        public List<Room> Rooms { get; set; }

        public Hotel Hotel { get; set; }

        public Guest Guest { get; set; }

        public Bill Bill { get; set; }
    }
}
