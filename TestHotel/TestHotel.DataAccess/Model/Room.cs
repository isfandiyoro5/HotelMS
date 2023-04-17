using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Room
    {
        public int RoomNo { get; set; }
        public string RoomTypes { get; set; }
        public int HotelCode { get; set; }
        public string Occupancy { get; set; }

        public List<RoomType> roomTypes { get; set; }
        public List<Booking> bookings { get; set; }
        public Hotel Hotel { get; set; } 
    }
}
