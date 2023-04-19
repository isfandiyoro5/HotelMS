using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Room
    {
        public int RoomNumber { get; set; }
        public Enum RoomTypes { get; set; }
        public int RoomTypeID { get; set; }
        public int HotelId { get; set; }
        public string Occupancy { get; set; }

        public List<RoomType> roomType { get; set; }
        public List<Booking> bookings { get; set; }
        public Hotel Hotel { get; set; } 
    }
}
