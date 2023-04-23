using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.ResponseDto
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}
