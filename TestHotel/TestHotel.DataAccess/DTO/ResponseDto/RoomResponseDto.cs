using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.DTO.ResponseDto
{
    internal class RoomResponseDto
    {
        public int RoomTypeID { get; set; }

        public int HotelId { get; set; }

        public string Occupancy { get; set; }
    }
}
