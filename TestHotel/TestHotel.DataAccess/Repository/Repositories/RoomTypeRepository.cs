using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ILogger<RoomTypeRepository> _logger;
        private readonly HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext context, ILogger<RoomTypeRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddRoomTypeAsync(RoomType roomType)
        {
            try
            {
                _context.RoomTypes.Add(roomType);
                await _context.SaveChangesAsync();
                _logger.LogInformation("AddRoomtypeAsync() Chaqirildi");
                return roomType.RoomTypeId;
            }
            catch
            {
                _logger.LogError("AddRoomTypeAsync() Qo'shilmadi");
                throw new Exception("Room Type qo'shilmadi");
            }
        }

        public async Task<int> DeleteRoomTypeAsync(RoomType roomType)
        {
            try
            {
                _context.RoomTypes.Remove(roomType);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteRoomTypeAsync() Chaqirildi");
                return roomType.RoomTypeId;
            }
            catch
            {
                _logger.LogError("DeleteRoomTypeAsync() O'chirilmadi");
                throw new Exception("Room Type o'chirilmadi");
            }
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync() => await _context.RoomTypes
            .Include(u => u.Room)
            .ToListAsync();

        public async Task<RoomType> GetRoomTypeByIdAsync(RoomTypes roomTypes)
        {
            try
            {
                _logger.LogInformation("GetRoomTypeByIdAsync() Chaqirildi");
                return await _context.RoomTypes
                    .Include(u => u.Room)
                    .FirstOrDefaultAsync(u => u.RoomTypes == roomTypes);
            }
            catch
            {
                _logger.LogError("GetRoomTypeByIdAsync() Topilmadi");
                throw new Exception("Room Type ID topilmadi");
            }
        }

        public async Task<int> UpdateRoomTypeAsync(RoomType roomType)
        {
            try
            {
                _context.RoomTypes.Update(roomType);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateRoomTypeAsync() Chaqirildi");
                return roomType.RoomTypeId;
            }
            catch
            {
                _logger.LogError("UpdateRoomTypeAsync() O'zgartirilmadi");
                throw new Exception("Room Type o'zgartirilmadi");
            }
        }
    }
}
