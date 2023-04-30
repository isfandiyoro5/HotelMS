using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost]
        public async Task<int> CreateRoomAsync(Room room)
        {
            return await _roomRepository.AddRoomAsync(room);
        }

        [HttpGet("id")]
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }

        [HttpPut]
        public async Task<int> UpdateRoomAsync(Room room)
        {
            return await _roomRepository.UpdateRoomAsync(room);
        }

        [HttpDelete]
        public async Task<int> DeleteRoomAsync(Room room)
        {
            return await _roomRepository.DeleteRoomAsync(room);
        }
    }
}
