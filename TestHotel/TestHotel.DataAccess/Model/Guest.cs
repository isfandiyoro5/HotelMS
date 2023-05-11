using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    public class Guest
    {
        public int GuestId { get; set; }
        
        public int BookingId { get; set; }
        
        public GuestPriority GuestPriority { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public Gender Gender { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string PassportNumber { get; set; }

        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }


        public List<Booking> Bookings { get; set; }
        
        public List<Bill> Bills { get; set; }
    }

    public enum GuestPriority
    {
        Standart,
        CIP,
        VIP,
        DIP
    }
}
