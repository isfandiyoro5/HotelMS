using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class BookingRoomRepository : IBookingRoomRepository
    {
        private readonly HotelDbContext _context;
        private readonly ILogger<BookingRoomRepository> _logger;

        public BookingRoomRepository(HotelDbContext context, ILogger<BookingRoomRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddBookingRoomAsync(BookingRoom bookingRoom)
        {
            try
            {
                _context.BookingRooms.Add(bookingRoom);
                await _context.SaveChangesAsync();
                _logger.LogInformation("BookingRoom muvaffaqiyatli qo'shildi");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("BookingRoomni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingRoomni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("BookingRoomni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingRoomni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task DeleteBookingRoomAsync(BookingRoom bookingRoom)
        {
            try
            {
                _context.BookingRooms.Remove(bookingRoom);
                await _context.SaveChangesAsync();
                _logger.LogInformation("BookingRoom muvaffaqiyatli o'chirildi");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("BookingRoomni databazadan o'chirishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingRoomni o'chirishda xatolik bor. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("BookingRoomni o'chirishda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingRoomni o'chirishda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task UpdateBookingRoomAsync(BookingRoom bookingRoom)
        {
            try
            {
                _context.BookingRooms.Update(bookingRoom);
                await _context.SaveChangesAsync();
                _logger.LogInformation("BookingRoom muvaffaqiyatli o'zgartirildi");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("BookingRoomni databazaga yangilashda xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingRoomni yangilashda xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("BookingRoomni yangilashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingRoomni yangilashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<BookingRoom>> GetAllBookingRoomsByBookingIdAsync(int id)
        {
            return await _context.BookingRooms
                .Include(u => u.Booking)
                .Include(u => u.Room)
                .AsSplitQuery()
                .Where(u => u.BookingId == id)
                .ToListAsync();
        }
    }
}
