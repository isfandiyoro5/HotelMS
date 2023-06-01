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
            try
            {
                return await _roomTypeService.AddRoomTypeAsync(roomTypeRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<RoomTypeResponseDto>> GetRoomTypeById(int id)
        {
            try
            {
                return await _roomTypeService.GetRoomTypeByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomTypeResponseDto>>> GetAllRoomTypes()
        {
            try
            {
                return await _roomTypeService.GetAllRoomTypesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateRoomType(int id, RoomTypeRequestDto roomTypeRequestDto)
        {
            try
            {
                return await _roomTypeService.UpdateRoomTypeAsync(id, roomTypeRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteRoomType(int id)
        {
            try
            {
                return await _roomTypeService.DeleteRoomTypeAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
