using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        [HttpPost]
        public async Task<int> CreateRoomTypeAsync(RoomType roomType)
        {
            return await _roomTypeRepository.AddRoomTypeAsync(roomType);
        }

        [HttpGet("id")]
        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _roomTypeRepository.GetRoomTypeByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _roomTypeRepository.GetAllRoomTypesAsync();
        }

        [HttpPut]
        public async Task<int> UpdateRoomTypeAsync(RoomType roomType)
        {
            return await _roomTypeRepository.UpdateRoomTypeAsync(roomType);
        }

        [HttpDelete]
        public async Task<int> DeleteRoomTypeAsync(RoomType roomType)
        {
            return await _roomTypeRepository.DeleteRoomTypeAsync(roomType);
        }
    }
}
