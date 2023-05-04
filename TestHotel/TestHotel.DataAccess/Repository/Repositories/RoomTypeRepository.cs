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
                _logger.LogInformation("RoomType muvaffaqiyatli qo'shildi");
                return roomType.RoomTypeId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> DeleteRoomTypeAsync(RoomType roomType)
        {
            try
            {
                _context.RoomTypes.Remove(roomType);
                await _context.SaveChangesAsync();
                _logger.LogInformation("RoomType muvaffaqiyatli o'chirildi");
                return roomType.RoomTypeId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            try
            {
                return await _context.RoomTypes
                    .Include(u => u.Room)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(RoomTypes roomTypes)
        {
            try
            {
                _logger.LogInformation("RoomTypeById muvaffaqiyatli topildi");
                return await _context.RoomTypes
                    .Include(u => u.Room)
                    .FirstOrDefaultAsync(u => u.RoomTypes == roomTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> UpdateRoomTypeAsync(RoomType roomType)
        {
            try
            {
                _context.RoomTypes.Update(roomType);
                await _context.SaveChangesAsync();
                _logger.LogInformation("RoomType muvaffaqiyatli yangilandi");
                return roomType.RoomTypeId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}
