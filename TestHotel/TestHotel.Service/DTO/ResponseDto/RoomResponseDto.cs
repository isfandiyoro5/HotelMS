using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.ResponseDto
{
    public class RoomResponseDto
    {
        public int RoomTypeID { get; set; }

        public int HotelId { get; set; }

        public Occupancy Occupancy { get; set; }
    }
}
