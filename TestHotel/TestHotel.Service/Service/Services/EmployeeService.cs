using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeerepository)
        {
            _employeeRepository= employeerepository;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var employeeExist = await GetEmployeeByIdAsync(id);
            if(employeeExist != null)
            {
                return await _employeeRepository.DeleteEmployeeAsync(employeeExist);
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
           return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            var employeeExist = await GetEmployeeByIdAsync(employee.EmployeeId);
            if(employeeExist != null)
            {
                return await _employeeRepository.UpdateEmployeeAsync(employee);
            }
            else
            {
                return 0;
            }
        }
    }
}
