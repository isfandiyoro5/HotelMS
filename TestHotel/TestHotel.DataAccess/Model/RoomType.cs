using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class RoomType
    {
        public int RoomTypesID { get; set: }
        public enum RoomTypes { get; set; }
        public int RoomPrice { get; set; }
        public string RoomImg { get; set; }
        public string RoomsDescription { get; set; }

        public Room Room { get; set; }
    }
}
