using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddRoom(RoomRequestDto roomRequestDto)
        {
            return await _roomService.AddRoomAsync(roomRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<RoomResponseDto>> GetRoomById(int id)
        {
            return await _roomService.GetRoomByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomResponseDto>>> GetAllRooms()
        {
            return await _roomService.GetAllRoomsAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateRoom(int id, RoomRequestDto roomRequestDto)
        {
            return await _roomService.UpdateRoomAsync(id, roomRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteRoom(int id)
        {
            return await _roomService.DeleteRoomAsync(id);
        }
    }
}
