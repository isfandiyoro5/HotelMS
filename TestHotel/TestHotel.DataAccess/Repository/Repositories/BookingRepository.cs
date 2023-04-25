using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.DbConnection;
using Microsoft.EntityFrameworkCore;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
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

        public List<Booking> GetAllBookings() => _context.Bookings
            .Include(u => u.Bills)
            .Include(u => u.Guests)
            .Include(u => u.Hotel)
            .Include(u => u.Room)
            .ToList();

        public Booking GetBookingById(int id) => _context.Bookings
            .Include(u => u.Bills)
            .Include(u => u.Guests)
            .Include(u => u.Hotel)
            .Include(u => u.Room)
            .FirstOrDefault(u => u.BookingId == id);

        public int UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
            return booking.BookingId;
        }
    }
}
