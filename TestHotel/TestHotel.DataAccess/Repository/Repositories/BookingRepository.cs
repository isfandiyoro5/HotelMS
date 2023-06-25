using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ILogger<BookingRepository> _logger;
        private readonly HotelDbContext _context;
        private readonly IBookingRoomRepository _bookingRoomrepository;
        BookingRoom bookingRoom = new BookingRoom();

        public BookingRepository(HotelDbContext context, ILogger<BookingRepository> logger, IBookingRoomRepository bookingRoomrepository)
        {
            _logger = logger;
            _context = context;
            _bookingRoomrepository = bookingRoomrepository;
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                for(int i = 0; i < booking.RoomId.Count(); i++)
                {
                    bookingRoom.BookingId = booking.BookingId;
                    bookingRoom.RoomId = booking.RoomId[i];
                    await _bookingRoomrepository.AddBookingRoomAsync(bookingRoom);
                }
                _logger.LogInformation("Booking muvaffaqiyatli qo'shildi");
                return booking.BookingId;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Bookingni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bookingni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                for (int i = 0; i < booking.RoomId.Count(); i++)
                {
                    bookingRoom.BookingId = booking.BookingId;
                    bookingRoom.RoomId = booking.RoomId[i];
                    await _bookingRoomrepository.DeleteBookingRoomAsync(bookingRoom);
                }
                _logger.LogInformation("Booking muvaffaqiyatli o'chirildi");
                return booking.BookingId;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Bookingni databazadan o'chirishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni o'chirishda xatolik bor. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bookingni o'chirishda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni o'chirishda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            try
            {
                return await _context.Bookings
                    .Include(u => u.Bill)
                    .Include(u => u.Guest)
                    .Include(u => u.Hotel)
                    .Include(u => u.BookingRooms)
                    .AsSplitQuery()
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Barcha Bookinglarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Barcha Bookinglarni olishda xatolik yuz berdi. Iltimos qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Bookinglarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Barcha Bookinglarni olishda xatolik yuz berdi. Iltimos qayta urinib ko'ring");
            }
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("BookingById muvaffaqiyatli topildi");
                return await _context.Bookings
                    .Include(u => u.Bill)
                    .Include(u => u.Guest)
                    .Include(u => u.Hotel)
                    .Include(u => u.BookingRooms)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.BookingId == id);
            }
            catch (DbException ex)
            {
                _logger.LogError("BookingById ni databazadan olishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingById ni olishda xatolik bor. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("BookingById ni olishda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingById ni olishda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
                for (int i = 0; i < booking.RoomId.Count(); i++)
                {
                    bookingRoom.BookingId = booking.BookingId;
                    bookingRoom.RoomId = booking.RoomId[i];
                    await _bookingRoomrepository.UpdateBookingRoomAsync(bookingRoom);
                }
                _logger.LogInformation("Booking muvaffaqiyatli yangilandi");
                return booking.BookingId;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Bookingni databazaga yangilashda xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni yangilashda xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bookingni yangilashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni yangilashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}