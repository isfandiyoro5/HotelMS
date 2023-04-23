using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoomTypeRequestDto
    {
        public RoomTypes RoomTypes { get; set; }

        public string RoomsDescription { get; set; }
    }
}
