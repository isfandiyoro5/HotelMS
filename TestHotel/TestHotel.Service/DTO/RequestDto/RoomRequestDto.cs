using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoomRequestDto
    {
        public int RoomNumber { get; set; }

        public RoomTypes RoomTypes { get; set; }
    }
}
