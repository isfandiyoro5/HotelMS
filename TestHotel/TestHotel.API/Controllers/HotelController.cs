using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddHotel(HotelRequestDto hotelRequestDto)
        {
            return await _hotelService.AddHotelAsync(hotelRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<HotelResponseDto>> GetHotelById(int id)
        {
            return await _hotelService.GetHotelByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelResponseDto>>> GetAllHotels()
        {
            return await _hotelService.GetAllHotelsAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateHotel(int id, HotelRequestDto hotelRequestDto)
        {
            return await _hotelService.UpdateHotelAsync(id, hotelRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteHotel(int id)
        {
            return await _hotelService.DeleteHotelAsync(id);
        }
    }
}
