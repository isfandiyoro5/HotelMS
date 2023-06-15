using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<HotelService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<HotelRequestDto> _hotelRequestDtoValidator;

        public HotelService(IHotelRepository hotelRepository, ILogger<HotelService> logger, IMapper mapper, IValidator<HotelRequestDto> hotelRequestDtoValidator)
        {
            _hotelRepository = hotelRepository;
            _logger = logger;
            _mapper = mapper;
            _hotelRequestDtoValidator = hotelRequestDtoValidator;
        }

        public async Task<int> AddHotelAsync(HotelRequestDto hotelRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _hotelRequestDtoValidator.ValidateAsync(hotelRequestDto);
                if (!validationResult.IsValid)
                {
                    return await _hotelRepository.AddHotelAsync(_mapper.Map<Hotel>(hotelRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Hotelni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Hotelni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteHotelAsync(int id)
        {
            try
            {
                var hotelResult = await _hotelRepository.GetHotelByIdAsync(id);
                if (hotelResult is not null)
                {
                    return await _hotelRepository.DeleteHotelAsync(hotelResult);
                }
                else
                {
                    throw new Exception("Delete uchun Hotel mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Hotelni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Hotelni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<HotelResponseDto>> GetAllHotelsAsync()
        {
            try
            {
                return _mapper.Map<List<HotelResponseDto>>(await _hotelRepository.GetAllHotelsAsync());
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Hotellarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotellarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Hotellarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotellarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<HotelResponseDto> GetHotelByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<HotelResponseDto>(await _hotelRepository.GetHotelByIdAsync(id));
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan Hotellar boʻyicha Hotelni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan Hotelni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateHotelAsync(int id, HotelRequestDto hotelRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _hotelRequestDtoValidator.ValidateAsync(hotelRequestDto);
                if (!validationResult.IsValid)
                {
                    var hotelResult = await _hotelRepository.GetHotelByIdAsync(id);
                    if (hotelResult is not null)
                    {
                        hotelResult.HotelName = hotelRequestDto.HotelName;
                        hotelResult.Street = hotelRequestDto.Street;
                        hotelResult.City = hotelRequestDto.City;
                        hotelResult.Country = hotelRequestDto.Country;
                        hotelResult.NumberOfRooms = hotelRequestDto.NumberOfRooms;
                        hotelResult.PhoneNumber = hotelRequestDto.PhoneNumber;
                        return await _hotelRepository.UpdateHotelAsync(hotelResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Hotel mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Hotelni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Hotelni yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Hotelni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
