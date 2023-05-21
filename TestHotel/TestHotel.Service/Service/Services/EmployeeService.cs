using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.CodeDom;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeRequestDto> _employeeRequestDtoValidator;

        public EmployeeService(EmployeeRepository employeeRepository, ILogger<EmployeeService> logger, IMapper mapper, IValidator<EmployeeRequestDto> employeeRequestDtoValidator)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
            _employeeRequestDtoValidator = employeeRequestDtoValidator;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _employeeRequestDtoValidator.ValidateAsync(employeeRequestDto);
                if (!validationResult.IsValid)
                {
                    return await _employeeRepository.AddEmployeeAsync(_mapper.Map<Employee>(employeeRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Employee qo'shishda databaza xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employee qo'shishda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Employee qo'shishda xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employee qo'shishda xatolik. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employeeResult = await _employeeRepository.GetEmployeeByIdAsync(id);
                if (employeeResult is not null)
                {
                    return await _employeeRepository.DeleteEmployeeAsync(employeeResult);
                }
                else
                {
                    throw new Exception("Delete uchun Employee mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Employeeni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employeeni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Employeeni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employeeni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync()
        {
            try
            {
                return _mapper.Map<List<EmployeeResponseDto>>(await _employeeRepository.GetAllEmployeesAsync());
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada barcha Employeelarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employeelarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Employeelarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employeelarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<EmployeeResponseDto>(await _employeeRepository.GetEmployeeByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan EmployeeByIdlar boʻyicha EmployeeById olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("EmployeeById olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan EmployeeByIdni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("EmployeeByIdni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateEmployeeAsync(int id, EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _employeeRequestDtoValidator.ValidateAsync(employeeRequestDto);
                if (!validationResult.IsValid)
                {
                    var employeeResult = await _employeeRepository.GetEmployeeByIdAsync(id);
                    if (employeeResult is not null)
                    {
                        employeeResult.FirstName = employeeRequestDto.FirstName;
                        employeeResult.LastName = employeeRequestDto.LastName;
                        employeeResult.BirthDate = employeeRequestDto.BirthDate;
                        employeeResult.Gender = employeeRequestDto.Gender;
                        employeeResult.PhoneNumber = employeeRequestDto.PhoneNumber;
                        employeeResult.Email = employeeRequestDto.Email;
                        employeeResult.Password = employeeRequestDto.Password;
                        employeeResult.Salary = employeeRequestDto.Salary;
                        return await _employeeRepository.UpdateEmployeeAsync(employeeResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Employee mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Employeeni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employeeni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Employeeni yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Employeeni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
