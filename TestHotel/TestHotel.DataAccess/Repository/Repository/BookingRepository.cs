using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _context;

        public BookingRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking.BookingId;
        }

        public int DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return booking.BookingId;
        }

        public List<Booking> GetAllBookings() => _context.Bookings.Include(u => u.Bills).ThenInclude(u => u.Guest)
            .Include(u => u.Hotel).ThenInclude(u => u.Rooms).ToList();

        public Booking GetBookingById(int id) => _context.Bookings.Include(u => u.Bills).ThenInclude(u => u.Guest)
            .Include(u => u.Hotel).ThenInclude(u => u.Rooms).FirstOrDefault(u => u.BookingId == id);

        public int UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
            return booking.BookingId;
        }
    }
}
