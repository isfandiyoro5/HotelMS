using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto
{
    public class HotelRequestDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string HotelName { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string Address { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string City { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string Country { get; set; }

        public int NumberOfRooms { get; set; }

        public string PhoneNumber { get; set; }
    }
}
