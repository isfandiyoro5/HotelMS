using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }

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
        
        public StarRating StarRating { get; set; }


        public List<Room> Rooms { get; set; }
        
        public List<Booking> Bookings { get; set; }
        
        public List<Employee> Employees { get; set; }
    }

    public enum StarRating
    {
       Star_2, 
       Star_3,
       Star_4,
       Star_5
    }
}
