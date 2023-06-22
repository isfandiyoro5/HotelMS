using System.ComponentModel.DataAnnotations.Schema;

namespace TestHotel.DataAccess.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

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
