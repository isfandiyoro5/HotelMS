using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly ILogger<RoomTypeService> _logger;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository, ILogger<RoomTypeService> logger)
        {
            _roomTypeRepository = roomTypeRepository;
            _logger = logger;
        }

        public async Task<int> AddRoomTypeAsync(RoomType roomType)
        {
            try
            {
                return await _roomTypeRepository.AddRoomTypeAsync(roomType);
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

        public async Task<int> DeleteRoomTypeAsync(int id)
        {
            try
            {
                var roomTypeResult = await GetRoomTypeByIdAsync(id);
                if (roomTypeResult is not null)
                {
                    return await _roomTypeRepository.DeleteRoomTypeAsync(roomTypeResult);
                }
                else
                {
                    throw new Exception("Delete uchun RoomType mavjud emas");
                }
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
                return await _roomTypeRepository.GetAllRoomTypesAsync();
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

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            try
            {
                return await _roomTypeRepository.GetRoomTypeByIdAsync(id);
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

        public async Task<int> UpdateRoomTypeAsync(int id)
        {
            try
            {
                var roomTypeResult = await GetRoomTypeByIdAsync(id);
                if (roomTypeResult is not null)
                {
                    return await _roomTypeRepository.UpdateRoomTypeAsync(roomTypeResult);
                }
                else
                {
                    throw new Exception("Update uchun RoomType mavjud emas");
                }
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
