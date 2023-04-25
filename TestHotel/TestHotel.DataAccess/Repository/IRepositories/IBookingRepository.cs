using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IBookingRepository
    {
        public int AddBooking(Booking booking);

        public Booking GetBookingById(int id);

        public List<Booking> GetAllBookings();

        public int UpdateBooking(Booking booking);

        public int DeleteBooking(Booking booking);
    }
}
