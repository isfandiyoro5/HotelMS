using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.ResponseDto
{
    public class RoomTypeResponseDto
    {
        public int RoomTypeId { get; set; }

        public double RoomPrice { get; set; }

        public string RoomImage { get; set; }//biz uchun shart emas bolyabti
    }
}
