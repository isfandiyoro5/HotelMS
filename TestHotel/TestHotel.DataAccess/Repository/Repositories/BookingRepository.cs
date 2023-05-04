using Microsoft.AspNetCore.Http;
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
                _logger.LogInformation("Booking muvaffaqiyatli qo'shildi");
                return booking.BookingId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> DeleteBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Booking muvaffaqiyatli o'chirildi");
                return booking.BookingId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            try
            {
               return await _context.Bookings
                .Include(u => u.Bills)
                .Include(u => u.Guests)
                .Include(u => u.Hotel)
                .Include(u => u.Room)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("BookingById muvaffaqiyatli topildi");
                return await _context.Bookings
                    .Include(u => u.Bills)
                    .Include(u => u.Guests)
                    .Include(u => u.Hotel)
                    .Include(u => u.Room)
                    .FirstOrDefaultAsync(u => u.BookingId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Booking muvaffaqiyatli yangilandi");
                return booking.BookingId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}
