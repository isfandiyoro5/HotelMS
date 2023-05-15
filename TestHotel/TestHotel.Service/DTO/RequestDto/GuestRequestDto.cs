using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class GuestRequestDto
    {
        public GuestPriority GuestPriority { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PassportNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
