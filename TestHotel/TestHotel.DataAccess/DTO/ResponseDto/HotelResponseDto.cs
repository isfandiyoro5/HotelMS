using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.DTO.ResponseDto
{
    internal class HotelResponseDto
    {
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public StarRating StarRating { get; set; }
    }
}
