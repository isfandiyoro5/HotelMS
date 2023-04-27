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
                _logger.LogInformation("AddEmployeeAsync() Chaqirildi");
                return employee.EmployeeID;
            }
            catch
            {
                _logger.LogError("AddEmployeeAsync() Qo'shilmadi");
                throw new Exception("Employee qo'shilmadi");
            }
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteEmployeeAsync() Chaqirildi");
                return employee.EmployeeID;
            }
            catch
            {
                _logger.LogError("DeleteEmployeeAsync() O'chirilmadi");
                throw new Exception("Employee o'chirilmadi");
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync() => await _context.Employees
            .Include(u => u.Role)
            .Include(u => u.Hotel)
            .ToListAsync();

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetEmployeeByIdAsync() Chaqirildi");
                return await _context.Employees
                    .Include(u => u.Role)
                    .Include(u => u.Hotel)
                    .FirstOrDefaultAsync(u => u.EmployeeID == id);
            }
            catch
            {
                _logger.LogError("GetEmployeeByIdAsync() Topilmadi");
                throw new Exception("Employee ID topilmadi");
            }
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateEmployeeAsync() Chaqirildi");
                return employee.EmployeeID;
            }
            catch
            {
                _logger.LogError("UpdateEmployeeAsync() O'zgartirilmadi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
