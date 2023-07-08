using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployeeAsync(Employee employee);

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<List<Employee>> GetAllEmployeesAsync();

        Task<int> UpdateEmployeeAsync(Employee employee);

        Task<int> DeleteEmployeeAsync(Employee employee);
    }
}
