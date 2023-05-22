using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(Employee employee);

        Task<int> UpdateEmployeeAsync(int id);

        Task<int> DeleteEmployeeAsync(int id);

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
