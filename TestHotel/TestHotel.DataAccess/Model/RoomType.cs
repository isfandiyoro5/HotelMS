﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }

        public RoomTypes RoomTypes { get; set; }

        public double RoomPrice { get; set; }

        public string RoomImage { get; set; }

        public string RoomsDescription { get; set; }


        public Room Room { get; set; }
    }
}
