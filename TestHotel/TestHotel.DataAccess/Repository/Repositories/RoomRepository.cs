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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Roomni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }

            catch (Exception ex)
            {
                _logger.LogError("Roomni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception($"Roomni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.{ex.Message}, {ex.StackTrace}");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Roomni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Roomni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            try
            {
                return await _context.Rooms
                    .Include(u => u.BookingRooms)
                    .Include(u => u.Hotel)
                    .AsSplitQuery()
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Roomni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomlarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Roomlarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomlarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("RoomById muvaffaqiyatli topildi");
                return await _context.Rooms
                    .Include(u => u.BookingRooms)
                    .Include(u => u.Hotel)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.RoomId == id);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan Roomlar boʻyicha Roomni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan Roomni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Roomni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Roomni yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
