using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployee(EmployeeRequestDto employeeRequestDto)
        {
            return await _employeeService.AddEmployeeAsync(employeeRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeByid(int id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees()
        {
            return await _employeeService.GetAllEmployeesAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateEmployee(int id, EmployeeRequestDto employeeRequestDto)
        {
            return await _employeeService.UpdateEmployeeAsync(id, employeeRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployeeAsync(id);
        }
    }
}
