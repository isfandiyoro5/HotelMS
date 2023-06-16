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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<RoleService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<RoleRequestDto> _roleRequestDtoValidator;

        public RoleService(IRoleRepository roleRepository, ILogger<RoleService> logger, IMapper mapper, IValidator<RoleRequestDto> roleRequestDtoValidator)
        {
            _roleRepository = roleRepository;
            _logger = logger;
            _mapper = mapper;
            _roleRequestDtoValidator = roleRequestDtoValidator;
        }

        public async Task<int> AddRoleAsync(RoleRequestDto roleRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _roleRequestDtoValidator.ValidateAsync(roleRequestDto);
                if (validationResult.IsValid)
                {
                    return await _roleRepository.AddRoleAsync(_mapper.Map<Role>(roleRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Roleni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }

            catch (Exception ex)
            {
                _logger.LogError("Roleni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteRoleAsync(int id)
        {
            try
            {
                var roleResult = await _roleRepository.GetRoleByIdAsync(id);
                if (roleResult is not null)
                {
                    return await _roleRepository.DeleteRoleAsync(roleResult);
                }
                else
                {
                    throw new Exception("Delete uchun Role mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Roleni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Roleni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<RoleResponseDto>> GetAllRolesAsync()
        {
            try
            {
                return _mapper.Map<List<RoleResponseDto>>(await _roleRepository.GetAllRolesAsync());
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Rolelarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Rolelarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Rolelarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Rolelarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<RoleResponseDto> GetRoleByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<RoleResponseDto>(await _roleRepository.GetRoleByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan Rolelar boʻyicha Roleni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan Roleni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateRoleAsync(int id, RoleRequestDto roleRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _roleRequestDtoValidator.ValidateAsync(roleRequestDto);
                if (validationResult.IsValid)
                {
                    var roleResult = await _roleRepository.GetRoleByIdAsync(id);
                    if (roleResult is not null)
                    {
                        roleResult.RoleTitle = roleRequestDto.RoleTitle;
                        roleResult.RoleDescription = roleRequestDto.RoleDescription;
                        return await _roleRepository.UpdateRoleAsync(roleResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Role mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Roleni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Roleni yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Roleni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
