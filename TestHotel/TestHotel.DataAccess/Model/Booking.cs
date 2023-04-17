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
        public int HotelCode { get; set; }
        public int GuestId { get; set; }
        public int RoomNo { get; set; }
        public int BookingDate { get; set; }
        public int BookingTime { get; set; }
        public int ArrivalDate { get; set; }
        public int DepartureDate { get; set; }
        public int EstArrivalTime { get; set; }
        public int EstDepartureTime { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; }
        public string SpecialReq { get; set; }

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public List<Guest> Guests { get; set;}
        public List<Bill> Bills { get; set;}
    }
}
