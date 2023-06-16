namespace TestHotel.DataAccess.Model
{
    public class Room
    {
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public RoomTypes RoomType { get; set; }

        public Occupancy Occupancy { get; set; }

        public double RoomPrice { get; set; }

        public string RoomImage { get; set; }

        public string RoomsDescription { get; set; }


        public List<Booking> Bookings { get; set; }

        public Hotel Hotel { get; set; }
    }

    public enum Occupancy
    {
        Empty,
        Busy
    }

    public enum RoomTypes
    {
        Standard,
        Deluxe,
        JuniorSuite,
        SeniorSuite
    }
}
