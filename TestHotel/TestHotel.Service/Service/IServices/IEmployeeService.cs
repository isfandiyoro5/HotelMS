using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(Employee employee);

        Task<int> UpdateEmployeeAsync(Employee employee);

        Task<int> DeleteEmployeeAsync(int id);

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
