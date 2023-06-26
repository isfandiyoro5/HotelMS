using Microsoft.EntityFrameworkCore;

namespace TestHotel.DataAccess.Model
{
    public class BookingRoom
    {
        public int BookingRoomId { get; set; }

        public int BookingId { get; set; }

        public int RoomId { get; set; }


        public Booking Booking { get; set; }

        public Room Room { get; set; }
    }
}
