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
                return employee.EmployeeID;
            }
            catch
            {
                _logger.LogError("Employeeni qo'shilishida xatolik yuzaga keldi");
                throw new Exception("Employee qo'shilmadi");
            }
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee muvaffaqiyatli o'chirildi");
                return employee.EmployeeID;
            }
            catch
            {
                _logger.LogError("Employeeni o'chirishda xatolik yuzaga keldi");
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
                _logger.LogInformation("Employee muvaffaqiyatli topildi");
                return await _context.Employees
                    .Include(u => u.Role)
                    .Include(u => u.Hotel)
                    .FirstOrDefaultAsync(u => u.EmployeeID == id);
            }
            catch
            {
                _logger.LogError("EmployeeByIdni qidirishda xatolik yuzaga keldi");
                throw new Exception("Employee ID topilmadi");
            }
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee muvaffaqiyatli yangilandi");
                return employee.EmployeeID;
            }
            catch
            {
                _logger.LogError("Employeeni yangilashda xatolik yuzaga keldi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
