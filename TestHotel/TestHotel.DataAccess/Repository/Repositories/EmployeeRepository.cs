using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly HotelDbContext _context;

        public EmployeeRepository(HotelDbContext context, ILogger<EmployeeRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee muvaffaqiyatli qo'shildi");
                return employee.EmployeeId;
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

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee muvaffaqiyatli o'chirildi");
                return employee.EmployeeId;
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
                return await _context.Employees
                    .Include(u => u.Role)
                    .Include(u => u.Hotel)
                    .AsSplitQuery()
                    .ToListAsync();
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
                _logger.LogInformation("Employee muvaffaqiyatli topildi");
                return await _context.Employees
                    .Include(u => u.Role)
                    .Include(u => u.Hotel)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.EmployeeId == id);
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

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee muvaffaqiyatli yangilandi");
                return employee.EmployeeId;
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