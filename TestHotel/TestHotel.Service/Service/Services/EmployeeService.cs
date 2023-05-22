using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(EmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            try
            {
                return await _employeeRepository.AddEmployeeAsync(employee);
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
                var employeeResult = await GetEmployeeByIdAsync(id);
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

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetAllEmployeesAsync();
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

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _employeeRepository.GetEmployeeByIdAsync(id);
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

        public async Task<int> UpdateEmployeeAsync(int id)
        {
            try
            {
                var employeeResult = await GetEmployeeByIdAsync(id);
                if (employeeResult is not null)
                {
                    return await _employeeRepository.UpdateEmployeeAsync(employeeResult);
                }
                else
                {
                    throw new Exception("Update uchun Employee mavjud emas");
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
