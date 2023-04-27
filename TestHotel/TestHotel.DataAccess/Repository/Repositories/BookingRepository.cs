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

        public async Task<int> AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.BookingId;
        }

        public async Task<int> DeleteBookingAsync(Booking booking)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return booking.BookingId;
        }

        public async Task<List<Booking>> GetAllBookingsAsync() => await _context.Bookings
            .Include(u => u.Bills)
            .Include(u => u.Guests)
            .Include(u => u.Hotel)
            .Include(u => u.Room)
            .ToListAsync();

        public async Task<Booking> GetBookingByIdAsync(int id) => await _context.Bookings
            .Include(u => u.Bills)
            .Include(u => u.Guests)
            .Include(u => u.Hotel)
            .Include(u => u.Room)
            .FirstOrDefaultAsync(u => u.BookingId == id);

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking.BookingId;
        }
    }
}
