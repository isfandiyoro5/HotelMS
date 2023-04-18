using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Booking
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int RoomNumber { get; set; }
        public DataTime BookingDate { get; set; }
        public DataTime BookingTime { get; set; }
        public DataTime ArrivalDate { get; set; }
        public DataTime DepartureDate { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
        //public string SpecialRequest { get; set; }

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public List<Guest> Guests { get; set;}
        public List<Bill> Bills { get; set;}
    }
}
