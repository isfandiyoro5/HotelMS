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
            try
            {
                return await _employeeService.AddEmployeeAsync(employeeRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeByid(int id)
        {
            try
            {
                return await _employeeService.GetEmployeeByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees()
        {
            try
            {
                return await _employeeService.GetAllEmployeesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateEmployee(int id, EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                return await _employeeService.UpdateEmployeeAsync(id, employeeRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteEmployee(int id)
        {
            try
            {
                return await _employeeService.DeleteEmployeeAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
