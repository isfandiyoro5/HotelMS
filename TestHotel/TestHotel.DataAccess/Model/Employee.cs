using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    public class Employee
    {
        public int EmployeeID{ get; set; }
        
        public int HotelId { get; set; }
        
        public int RoleID { get; set; }

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
        
        public double Salary { get; set; }


        public Hotel Hotel { get; set; }
        
        public Role Role { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
