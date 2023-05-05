using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Data.SqlClient;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ILogger<HotelRepository> _logger;
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context, ILogger<HotelRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Hotel muvaffaqiyatli qo'shildi");
                return hotel.HotelId;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Hotelni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Hotelni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Hotel muvaffaqiyatli o'chirildi");
                return hotel.HotelId;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Hotelni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Hotelni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            try
            {
                return await _context.Hotels
                    .Include(u => u.Rooms)
                    .Include(u => u.Bookings)
                    .Include(u => u.Employees)
                    .AsSplitQuery()
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Hotellarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotellarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Hotellarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotellarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id), "Id parameter is required.");
                }

                _logger.LogInformation("Hotel muvaffaqiyatli topildi");
                return await _context.Hotels
                    .Include(u => u.Rooms)
                    .Include(u => u.Bookings)
                    .Include(u => u.Employees)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.HotelId == id);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan Hotellar boʻyicha Hotelni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan Hotelni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Hotel muvaffaqiyatli yangilandi");
                return hotel.HotelId;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Hotelni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Hotelni yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
