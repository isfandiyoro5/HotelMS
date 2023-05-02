using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class RoomService: IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            return await _roomRepository.AddRoomAsync(room);
        }

        public async Task<int> DeleteRoomAsync(Room room)
        {
            return await _roomRepository.DeleteRoomAsync(room);
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task<int> UpdateRoomAsync(Room room)
        {
            return await _roomRepository.UpdateRoomAsync(room);
        }
    }
}
