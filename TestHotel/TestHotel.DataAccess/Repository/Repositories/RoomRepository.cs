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
            catch
            {
                _logger.LogError("Roomni yaratishda xatolik yuzaga keldi");
                throw new Exception("Room qo'shilmadi");
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
            catch
            {
                _logger.LogError("Roomni o'chirishda xatolik yuzaga keldi");
                throw new Exception("Room o'chirilmadi");
            }
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var allRoomsExist = await _context.Rooms
            .Include(u => u.roomType)
            .Include(u => u.bookings)
            .Include(u => u.Hotel)
            .ToListAsync();
            if(allRoomsExist is not null)
            {
                return allRoomsExist;
            }
            else
            {
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
            catch
            {
                _logger.LogError("RoomByIdni qidirishda xatolik yuzaga keldi");
                throw new Exception("Room ID topilmadi");
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
            catch
            {
                _logger.LogError("Roomni yangilashda xatolik yuzaga keldi");
                throw new Exception("Room o'zgartirilmadi");
            }
        }
    }
}
