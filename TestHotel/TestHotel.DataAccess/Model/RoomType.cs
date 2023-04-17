using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class RoomType
    {
        public string RoomTypes { get; set; }
        public int RoomPrice { get; set; }
        public int DefaultRoomPrice { get; set; }
        public string RoomImg { get; set; }
        public string RoomsDesc { get; set; }

        public Room Room { get; set; }
    }
}
