using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ILogger<BookingRepository> _logger;
        private readonly HotelDbContext _context;

        public BookingRepository(HotelDbContext context, ILogger<BookingRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                _logger.LogInformation("AddBookingAsync() Chaqirildi");
                return booking.BookingId;
            }
            catch
            {
                _logger.LogError("AddBookingAsync() Qo'shilmadi");
                throw new Exception("Booking qo'shilmadi");
            }
        }

        public async Task<int> DeleteBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteBookingAsync() Chaqirildi");
                return booking.BookingId;
            }
            catch
            {
                _logger.LogError("DeleteBookingAsync() O'chirilmadi");
                throw new Exception("Booking o'chirilmadi");
            }
        }

        public async Task<List<Booking>> GetAllBookingsAsync() => await _context.Bookings
            .Include(u => u.Bills)
            .Include(u => u.Guests)
            .Include(u => u.Hotel)
            .Include(u => u.Room)
            .ToListAsync();

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetBookingByIdAsync() Chaqirildi");
                return await _context.Bookings
                    .Include(u => u.Bills)
                    .Include(u => u.Guests)
                    .Include(u => u.Hotel)
                    .Include(u => u.Room)
                    .FirstOrDefaultAsync(u => u.BookingId == id);
            }
            catch
            {
                _logger.LogError("DeleteBookingByIdAsync() Topilmadi");
                throw new Exception("Booking ID topilmadi");
            }
        }

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateBookingAsync() Chaqirildi");
                return booking.BookingId;
            }
            catch
            {
                _logger.LogError("UpdateBookingAsync() O'zgartirilmadi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
