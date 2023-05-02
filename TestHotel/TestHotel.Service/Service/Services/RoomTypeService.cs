using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class RoomTypeService:IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<int> AddRoomTypeAsync(RoomType roomType)
        {
            return await _roomTypeRepository.AddRoomTypeAsync(roomType);
        }

        public async Task<int> DeleteRoomTypeAsync(RoomType roomType)
        {
            return await _roomTypeRepository.DeleteRoomTypeAsync(roomType);
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _roomTypeRepository.GetAllRoomTypesAsync();
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _roomTypeRepository.GetRoomTypeByIdAsync(id);
        }

        public async Task<int> UpdateRoomTypeAsync(RoomType roomType)
        {
            return await _roomTypeRepository.UpdateRoomTypeAsync(roomType);
        }
    }
}
