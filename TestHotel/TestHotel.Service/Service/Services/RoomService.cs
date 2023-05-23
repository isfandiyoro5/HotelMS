using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace TestHotel.Service.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ILogger<RoomService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<RoomRequestDto> _roomRequestDtoValidator;

        public RoomService(IRoomRepository roomRepository, ILogger<RoomService> logger, IMapper mapper, IValidator<RoomRequestDto> roomRequestDtoValidator)
        {
            _roomRepository = roomRepository;
            _logger = logger;
            _mapper = mapper;
            _roomRequestDtoValidator = roomRequestDtoValidator;
        }

        public async Task<int> AddRoomAsync(RoomRequestDto roomRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _roomRequestDtoValidator.ValidateAsync(roomRequestDto);
                if (!validationResult.IsValid)
                {
                    return await _roomRepository.AddRoomAsync(_mapper.Map<Room>(roomRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Roomni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }

            catch (Exception ex)
            {
                _logger.LogError("Roomni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roomni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteRoomAsync(int id)
        {
            try
            {
                var roomResult = await _roomRepository.GetRoomByIdAsync(id);
                if (roomResult is not null)
                {
                    return await _roomRepository.DeleteRoomAsync(roomResult);
                }
                else
                {
                    throw new Exception("Delete uchun Room mavjud emas");
                }
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

        public async Task<List<RoomResponseDto>> GetAllRoomsAsync()
        {
            try
            {
                return _mapper.Map<List<RoomResponseDto>>(await _roomRepository.GetAllRoomsAsync());
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

        public async Task<RoomResponseDto> GetRoomByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<RoomResponseDto>(await _roomRepository.GetRoomByIdAsync(id));
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

        public async Task<int> UpdateRoomAsync(int id, RoomRequestDto roomRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _roomRequestDtoValidator.ValidateAsync(roomRequestDto);
                if (!validationResult.IsValid)
                {
                    var roomResult = await _roomRepository.GetRoomByIdAsync(id);
                    if (roomResult is not null)
                    {
                        roomResult.RoomNumber = roomResult.RoomNumber;
                        roomResult.roomType = roomResult.roomType;
                        return await _roomRepository.UpdateRoomAsync(roomResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Room mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
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
