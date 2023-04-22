using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.DTO.RequestDto
{
    internal class HotelRequestDto
    {
        public string HotelName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int NumberOfRooms { get; set; }

        public string PhoneNumber { get; set; }
    }
}
