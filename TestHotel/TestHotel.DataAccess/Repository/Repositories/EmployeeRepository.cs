using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HotelDbContext _context;

        public EmployeeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee.EmployeeID;
            }
            catch
            {
                throw new Exception("Employee qo'shilmadi");
            }
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee.EmployeeID;
            }
            catch
            {
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
                return await _context.Employees
                    .Include(u => u.Role)
                    .Include(u => u.Hotel)
                    .FirstOrDefaultAsync(u => u.EmployeeID == id);
            }
            catch
            {
                throw new Exception("Employee ID topilmadi");
            }
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return employee.EmployeeID;
            }
            catch
            {
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
