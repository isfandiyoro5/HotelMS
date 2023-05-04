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
                _logger.LogInformation("Room muvaffaqiyatli qo'shildi");
                return room.RoomNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> DeleteRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Room muvaffaqiyatli o'chirildi");
                return room.RoomNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            try
            {
                return await _context.Rooms
                    .Include(u => u.roomType)
                    .Include(u => u.bookings)
                    .Include(u => u.Hotel)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
            
        public async Task<Room> GetRoomByIdAsync(int roomNumber)
        {
            try
            {
                _logger.LogInformation("RoomById muvaffaqiyatli topildi");
                return await _context.Rooms
                    .Include(u => u.roomType)
                    .Include(u => u.bookings)
                    .Include(u => u.Hotel)
                    .FirstOrDefaultAsync(u => u.RoomNumber == roomNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> UpdateRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Update(room);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Room muvaffaqiyatli yangilandi");
                return room.RoomNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}
