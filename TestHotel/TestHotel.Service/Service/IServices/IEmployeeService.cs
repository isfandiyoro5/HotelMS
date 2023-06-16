using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.Service.IServices
{
    public interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(EmployeeRequestDto employeeRequestDto);

        Task<int> UpdateEmployeeAsync(int id, EmployeeRequestDto employeeRequestDto);

        Task<int> DeleteEmployeeAsync(int id);

        Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id);

        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync();
    }
}
