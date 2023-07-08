using EmailService;
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
        private readonly IEmailSender _emailSender;

        public EmployeeController(IEmployeeService employeeService, IEmailSender emailSender)
        {
            _employeeService = employeeService;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployee(EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                int result = await _employeeService.AddEmployeeAsync(employeeRequestDto);
                var message = new Message(new string[] { employeeRequestDto.Email }, "HotelMS", "Hotelga yangi Employee qo'shildi"
                    ,$"{employeeRequestDto.FirstName} {employeeRequestDto.LastName}");

                _emailSender.SendEmail(message);
                return result;
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
                int result = await _employeeService.UpdateEmployeeAsync(id, employeeRequestDto);
                var message = new Message(new string[] { employeeRequestDto.Email }, "HotelMS", "Hoteldagi Employee yangilandi"
                    ,$"{employeeRequestDto.FirstName} {employeeRequestDto.LastName}");

                _emailSender.SendEmail(message);
                return result;
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
