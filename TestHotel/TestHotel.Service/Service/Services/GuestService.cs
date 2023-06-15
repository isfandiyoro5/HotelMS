using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<GuestService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<GuestRequestDto> _guestRequestDtoValidator;

        public GuestService(IGuestRepository guestRepository, ILogger<GuestService> logger, IMapper mapper, IValidator<GuestRequestDto> guestRequestDtoValidator)
        {
            _guestRepository = guestRepository;
            _logger = logger;
            _mapper = mapper;
            _guestRequestDtoValidator = guestRequestDtoValidator;
        }

        public async Task<int> AddGuestAsync(GuestRequestDto guestRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _guestRequestDtoValidator.ValidateAsync(guestRequestDto);
                if (!validationResult.IsValid)
                {
                    return await _guestRepository.AddGuestAsync(_mapper.Map<Guest>(guestRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Guestni databazaga qoʻshishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni databazaga qoʻshishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Guestni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteGuestAsync(int id)
        {
            try
            {
                var guestResult = await _guestRepository.GetGuestByIdAsync(id);
                if (guestResult is not null)
                {
                    return await _guestRepository.DeleteGuestAsync(guestResult);
                }
                else
                {
                    throw new Exception("Delete uchun Guest mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Guestni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Guestni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<GuestResponseDto>> GetAllGuestsAsync()
        {
            try
            {
                return _mapper.Map<List<GuestResponseDto>>(await _guestRepository.GetAllGuestsAsync());
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Guestlarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestlarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Guestlarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestlarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<GuestResponseDto> GetGuestByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<GuestResponseDto>(await _guestRepository.GetGuestByIdAsync(id));
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError("ArgumentNullException in GetGuestByIdAsync: {0}StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan GetGuestByIdAsync boʻyicha Billni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("GetGuestByIdAsync olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan GetGuestByIdAsync olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("GetGuestByIdAsync olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateGuestAsync(int id, GuestRequestDto guestRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _guestRequestDtoValidator.ValidateAsync(guestRequestDto);
                if (!validationResult.IsValid)
                {
                    var guestResult = await _guestRepository.GetGuestByIdAsync(id);
                    if (guestResult is not null)
                    {
                        guestResult.GuestPriority = guestRequestDto.GuestPriority;
                        guestResult.FirstName = guestRequestDto.FirstName;
                        guestResult.LastName = guestRequestDto.LastName;
                        guestResult.BirthDate = guestRequestDto.BirthDate;
                        guestResult.Gender = guestRequestDto.Gender;
                        guestResult.PhoneNumber = guestRequestDto.PhoneNumber;
                        guestResult.Email = guestRequestDto.Email;
                        guestResult.Password = guestRequestDto.Password;
                        guestResult.PassportNumber = guestRequestDto.PassportNumber;
                        guestResult.Address = guestRequestDto.Address;
                        guestResult.City = guestRequestDto.City;
                        guestResult.Country = guestRequestDto.Country;
                        return await _guestRepository.UpdateGuestAsync(guestResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Guest mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Guestni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Guestni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
