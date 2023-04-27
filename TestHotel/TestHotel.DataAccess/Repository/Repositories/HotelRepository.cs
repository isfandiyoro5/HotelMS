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
                _logger.LogInformation("AddHotelAsync() Chaqirildi");
                return hotel.HotelId;
            }
            catch
            {
                _logger.LogError("AddHotelAsync() Qo'shilmadi");
                throw new Exception("Hotel qo'shilmadi");
            }
        }

        public async Task<int> DeleteHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteHotelAsync() Chaqirildi");
                return hotel.HotelId;
            }
            catch
            {
                _logger.LogError("DeleteHotelAsync() O'chirilmadi");
                throw new Exception("Hotel o'chirilmadi");
            }
        }

        public async Task<List<Hotel>> GetAllHotelsAsync() => await _context.Hotels
            .Include(u => u.Rooms)
            .Include(u => u.Bookings)
            .Include(u => u.Employees)
            .ToListAsync();

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetHotelByIdAsync() Chaqirildi");
                return await _context.Hotels
                    .Include(u => u.Rooms)
                    .Include(u => u.Bookings)
                    .Include(u => u.Employees)
                    .FirstOrDefaultAsync(u => u.HotelId == id);
            }
            catch
            {
                _logger.LogError("GetHotelByIdAsync() Topilmadi");
                throw new Exception("Hotel ID topilmadi");
            }
        }

        public async Task<int> UpdateHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateHotelAsync() Chaqirildi");
                return hotel.HotelId;
            }
            catch
            {
                _logger.LogError("UpdateHotelAsync() O'gartirilmadi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
