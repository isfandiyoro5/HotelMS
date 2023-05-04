using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
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
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
           
        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Hotel muvaffaqiyatli topildi");
                return await _context.Hotels
                    .Include(u => u.Rooms)
                    .Include(u => u.Bookings)
                    .Include(u => u.Employees)
                    .FirstOrDefaultAsync(u => u.HotelId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}
