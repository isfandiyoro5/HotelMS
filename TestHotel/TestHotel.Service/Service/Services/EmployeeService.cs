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

namespace TestHotel.Service.Service.Services
{
    internal class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var employeeResult = await GetEmployeeByIdAsync(id);
            if(employeeResult is not null)
            {
                return await _employeeRepository.DeleteEmployeeAsync(employeeResult);
            }
            else
            {
                throw new Exception("Delete uchun Employee mavjud emas");
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

        public async Task<int> UpdateEmployeeAsync(int id)
        {
            var employeeResult = await GetEmployeeByIdAsync(id);
            if(employeeResult is not  null)
            {
                return await _employeeRepository.UpdateEmployeeAsync(employeeResult);
            }
            else
            {
                throw new Exception("Update uchun Employee mavjud emas");
            }
        }
    }
}
