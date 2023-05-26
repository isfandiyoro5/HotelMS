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

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddGuest(GuestRequestDto guestRequestDto)
        {
            return await _guestService.AddGuestAsync(guestRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<GuestResponseDto>> GetGuestId(int id)
        {
            return await _guestService.GetGuestByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<GuestResponseDto>>> GetAllGuests()
        {
            return await _guestService.GetAllGuestsAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateGuest(int id, GuestRequestDto guestRequestDto)
        {
            return await _guestService.UpdateGuestAsync(id, guestRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteGuest(int id)
        {
            return await _guestService.DeleteGuestAsync(id);
        }
    }
}
