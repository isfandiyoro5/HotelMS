using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ILogger<RoomRepository> _logger;
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context, ILogger<RoomRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                _logger.LogInformation("AddRoomAsync() Chaqirildi");
                return room.RoomNumber;
            }
            catch
            {
                _logger.LogError("AddRoomAsync() Qo'shilmadi");
                throw new Exception("Room qo'shilmadi");
            }
        }

        public async Task<int> DeleteRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteRoomAsync() Chaqirildi");
                return room.RoomNumber;
            }
            catch
            {
                _logger.LogError("DeleteRoomAsync() O'chirilmadi");
                throw new Exception("Room o'chirilmadi");
            }
        }

        public async Task<List<Room>> GetAllRoomsAsync() => await _context.Rooms
            .Include(u => u.roomType)
            .Include(u => u.bookings)
            .Include(u => u.Hotel)
            .ToListAsync();

        public async Task<Room> GetRoomByIdAsync(int roomNumber)
        {
            try
            {
                _logger.LogInformation("GetRoomByIdAsync() Chaqirildi");
                return await _context.Rooms
                    .Include(u => u.roomType)
                    .Include(u => u.bookings)
                    .Include(u => u.Hotel)
                    .FirstOrDefaultAsync(u => u.RoomNumber == roomNumber);
            }
            catch
            {
                _logger.LogError("GetRoomByIdAsync() Topilmadi");
                throw new Exception("Room ID topilmadi");
            }
        }

        public async Task<int> UpdateRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Update(room);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateRoomAsync() Chaqirildi");
                return room.RoomNumber;
            }
            catch
            {
                _logger.LogError("UpdateRoomAsync() O'zgartirilmadi");
                throw new Exception("Room o'zgartirilmadi");
            }
        }
    }
}
