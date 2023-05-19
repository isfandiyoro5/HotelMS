using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.Service.IServices;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using AutoMapper;

namespace TestHotel.Service.Service.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly ILogger<RoomTypeService> _logger;
        private readonly IMapper _mapper;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository, ILogger<RoomTypeService> logger, IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> AddRoomTypeAsync(RoomTypeRequestDto roomTypeRequestDto)
        {
            try
            {
                return await _roomTypeRepository.AddRoomTypeAsync(_mapper.Map<RoomType>(roomTypeRequestDto));
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
                var roomTypeResult = await _roomTypeRepository.GetRoomTypeByIdAsync(id);
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

        public async Task<List<RoomTypeResponseDto>> GetAllRoomTypesAsync()
        {
            try
            {
                return _mapper.Map<List<RoomTypeResponseDto>>(await _roomTypeRepository.GetAllRoomTypesAsync());
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

        public async Task<RoomTypeResponseDto> GetRoomTypeByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<RoomTypeResponseDto>(await _roomTypeRepository.GetRoomTypeByIdAsync(id));
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

        public async Task<int> UpdateRoomTypeAsync(int id, RoomTypeRequestDto roomTypeRequestDto)
        {
            try
            {
                var roomTypeResult = await _roomTypeRepository.GetRoomTypeByIdAsync(id);
                if (roomTypeResult is not null)
                {
                    roomTypeResult.RoomTypes = roomTypeResult.RoomTypes;
                    roomTypeResult.RoomsDescription = roomTypeResult.RoomsDescription;
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
