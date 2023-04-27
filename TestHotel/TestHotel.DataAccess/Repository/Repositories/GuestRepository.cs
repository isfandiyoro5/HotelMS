using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                _logger.LogInformation("AddGuestAsync() Chaqirildi");
                return guest.GuestID;
            }
            catch
            {
                _logger.LogError("AddGuestAsync() Qo'shilmadi");
                throw new Exception("Guest qo'shilmadi");
            }
        }

        public async Task<int> DeleteGuestAsync(Guest guest)
        {
            try
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteGuestAsync() Chaqirildi");
                return guest.GuestID;
            }
            catch
            {
                _logger.LogError("DeleteGuestAsync() O'chirilmadi");
                throw new Exception("Guest o'chirilmadi");
            }
        }

        public async Task<List<Guest>> GetAllGuestsAsync() => await _context.Guests
            .Include(u => u.Bookings)
            .Include(u => u.Bills)
            .ToListAsync();

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetGuestByIdAsync() Chaqirildi");
                return await _context.Guests
                    .Include(u => u.Bookings)
                    .Include(u => u.Bills)
                    .FirstOrDefaultAsync(u => u.GuestID == id);
            }
            catch
            {
                _logger.LogError("GetGuestByIdAsync() Topilmadi");
                throw new Exception("Guest ID topilmadi");
            }
        }

        public async Task<int> UpdateGuestAsync(Guest guest)
        {
            try
            {
                _context.Guests.Update(guest);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateGuestAsync() Chaqirildi");
                return guest.GuestID;
            }
            catch
            {
                _logger.LogError("UpdateGuestAsync() O'zartirilmadi");
                throw new Exception("Guest o'zgartirilmadi");
            }
        }
    }
}
