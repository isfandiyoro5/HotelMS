using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HotelDbContext _context;

        public EmployeeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.EmployeeID;
        }

        public int DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return employee.EmployeeID;
        }

        public List<Employee> GetAllEmployees() => _context.Employees
            .Include(u => u.Role).Include(u => u.Hotel).ToList();

        public Employee GetEmployeeById(int id) => _context.Employees
            .Include(u => u.Role).Include(u => u.Hotel).FirstOrDefault(u => u.EmployeeID == id);

        public int UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee.EmployeeID;
        }
    }
}
