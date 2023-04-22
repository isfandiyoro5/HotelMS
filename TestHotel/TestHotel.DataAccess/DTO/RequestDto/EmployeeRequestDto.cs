using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.DTO.RequestDto
{
    internal class EmployeeRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Salary { get; set; }
    }
}
