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
                _logger.LogInformation("Guest muvaffaqiyatli qo'shildi");
                return guest.GuestID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            try
            {
                return await _context.Guests
                    .Include(u => u.Bookings)
                    .Include(u => u.Bills)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
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
                    .FirstOrDefaultAsync(u => u.GuestID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}
