using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Hotel
    {
        public int HotelCode { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int NumRooms { get; set; }
        public string PhoneNo { get; set; }
        public int StarRating { get; set; }

        public List<Room> Rooms { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
