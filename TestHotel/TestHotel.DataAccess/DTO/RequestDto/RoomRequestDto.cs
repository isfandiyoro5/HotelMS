using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.DTO.RequestDto
{
    internal class RoomRequestDto
    {
        public int RoomNumber { get; set; }

        public RoomTypes RoomTypes { get; set; }
    }
}
