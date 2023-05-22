using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ILogger<BookingService> _logger;

        public BookingService(BookingRepository bookingRepository, ILogger<BookingService> logger)
        {
            _bookingRepository = bookingRepository;
            _logger = logger;
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            try
            {
                return await _bookingRepository.AddBookingAsync(booking);
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

        public async Task<int> UpdateBookingAsync(int id)
        {
            try
            {
                var bookingResult = await GetBookingByIdAsync(id);
                if (bookingResult is not null)
                {
                    return await _bookingRepository.UpdateBookingAsync(bookingResult);
                }
                else
                {
                    throw new Exception("Update uchun Booking mavjud emas");
                }
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

        public async Task<int> DeleteBookingAsync(int id)
        {
            try
            {
                var bookingResult = await GetBookingByIdAsync(id);
                if (bookingResult is not null)
                {
                    return await _bookingRepository.DeleteBookingAsync(bookingResult);

                }
                else
                {
                    throw new Exception("Delet uchun Booking mavjud emas");
                }
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

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            try
            {
                return await _bookingRepository.GetBookingByIdAsync(id);
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

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            try
            {
                return await _bookingRepository.GetAllBookingsAsync();
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
    }
}
