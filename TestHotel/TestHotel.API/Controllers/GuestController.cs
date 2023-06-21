using EmailService;
using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly IEmailSender _emailSender;

        public GuestController(IGuestService guestService, IEmailSender emailSender)
        {
            _guestService = guestService;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddGuest(GuestRequestDto guestRequestDto)
        {
            try
            {
                int result = await _guestService.AddGuestAsync(guestRequestDto);
                var message = new Message(new string[] { guestRequestDto.Email }, "HotelMS", "Hotelga yangi Guest qo'shildi"
                    ,$"{guestRequestDto.FirstName} {guestRequestDto.LastName}");

                _emailSender.SendEmail(message);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<GuestResponseDto>> GetGuestId(int id)
        {
            try
            {
                return await _guestService.GetGuestByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<GuestResponseDto>>> GetAllGuests()
        {
            try
            {
                return await _guestService.GetAllGuestsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateGuest(int id, GuestRequestDto guestRequestDto)
        {
            try
            {
                int result = await _guestService.UpdateGuestAsync(id, guestRequestDto);
                var message = new Message(new string[] { guestRequestDto.Email }, "HotelMS", "Hoteldagi Guest yangilandi"
                    ,$"{guestRequestDto.FirstName} {guestRequestDto.LastName}");

                _emailSender.SendEmail(message);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteGuest(int id)
        {
            try
            {
                return await _guestService.DeleteGuestAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
