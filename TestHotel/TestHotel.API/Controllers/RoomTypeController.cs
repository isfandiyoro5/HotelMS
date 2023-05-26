using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddRoomType(RoomTypeRequestDto roomTypeRequestDto)
        {
            return await _roomTypeService.AddRoomTypeAsync(roomTypeRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<RoomTypeResponseDto>> GetRoomTypeById(int id)
        {
            return await _roomTypeService.GetRoomTypeByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomTypeResponseDto>>> GetAllRoomTypes()
        {
            return await _roomTypeService.GetAllRoomTypesAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateRoomType(int id, RoomTypeRequestDto roomTypeRequestDto)
        {
            return await _roomTypeService.UpdateRoomTypeAsync(id, roomTypeRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteRoomType(int id)
        {
            return await _roomTypeService.DeleteRoomTypeAsync(id);
        }
    }
}
