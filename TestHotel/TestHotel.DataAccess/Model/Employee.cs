using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthdayData { get; set; }
        public enum Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }

        public Hotel Hotel { get; set; }
        public List<Roles> Role { get; set; }
    }
}
