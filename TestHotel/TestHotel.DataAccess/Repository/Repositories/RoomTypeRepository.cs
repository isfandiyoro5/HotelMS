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
            catch (DbUpdateException ex)
            {
                _logger.LogError("RoomTypeni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }

            catch (Exception ex)
            {
                _logger.LogError("RoomTypeni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError("RoomTypeni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("RoomTypeni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            try
            {
                return await _context.RoomTypes
                    .Include(u => u.Room)
                    .AsSplitQuery()
                    .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada barcha RoomTypelarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypelarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha RoomTypelarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypelarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int roomTypeId)
        {
            try
            {
                _logger.LogInformation("RoomTypeById muvaffaqiyatli topildi");
                return await _context.RoomTypes
                    .Include(u => u.Room)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.RoomTypeId == roomTypeId);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan RoomTypelar boʻyicha RoomTypeni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan RoomTypeni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada RoomTypeni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada RoomTypeni yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("RoomTypeni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
