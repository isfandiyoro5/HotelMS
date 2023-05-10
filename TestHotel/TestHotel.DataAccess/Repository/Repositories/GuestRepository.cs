using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly ILogger<GuestRepository> _logger;
        private readonly HotelDbContext _context;

        public GuestRepository(HotelDbContext context, ILogger<GuestRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddGuestAsync(Guest guest)
        {
            try
            {
                _context.Guests.Add(guest);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Guest muvaffaqiyatli qo'shildi");
                return guest.GuestID;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Guestni databazaga qoʻshishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni databazaga qoʻshishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Guestni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteGuestAsync(Guest guest)
        {
            try
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Guest muvaffaqiyatli o'chirildi");
                return guest.GuestID;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Guestni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Guestni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            try
            {
                return await _context.Guests
                    .Include(u => u.Bookings)
                    .Include(u => u.Bills)
                    .AsSplitQuery()
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Guestlarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestlarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Guestlarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestlarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Guest muvaffaqiyatli topildi");
                return await _context.Guests
                    .Include(u => u.Bookings)
                    .Include(u => u.Bills)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.GuestID == id);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan GetGuestByIdAsync boʻyicha Billni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("GetGuestByIdAsync olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan GetGuestByIdAsync olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("GetGuestByIdAsync olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateGuestAsync(Guest guest)
        {
            try
            {
                _context.Guests.Update(guest);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Guest muvaffaqiyatli yangilandi");
                return guest.GuestID;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Guestni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Guestni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}