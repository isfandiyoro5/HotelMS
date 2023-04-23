using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.ResponseDto
{
    public class GuestResponseDto
    {
        public int GuestID { get; set; }

        public int BookingID { get; set; }

        public GuestPriority GuestPriority { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
