using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Guest
    {
        public int GuestID{ get; set; }
        public int BookingID { get; set; }
        public string GuestTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassportNo { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
