using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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

        public async Task<int> DeleteRoomTypeAsync(int id)
        {
            var roomTypeResult = await GetRoomTypeByIdAsync(id);
            if (roomTypeResult is not null)
            {
                return await _roomTypeRepository.DeleteRoomTypeAsync(roomTypeResult);
            }
            else
            {
                throw new Exception("Delete uchun RoomType mavjud emas");
            }
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _roomTypeRepository.GetAllRoomTypesAsync();
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _roomTypeRepository.GetRoomTypeByIdAsync(id);
        }

        public async Task<int> UpdateRoomTypeAsync(int id)
        {
            var roomTypeResult = await GetRoomTypeByIdAsync(id);
            if (roomTypeResult is not null)
            {
                return await _roomTypeRepository.UpdateRoomTypeAsync(roomTypeResult);
            }
            else
            {
                throw new Exception("Update uchun RoomType mavjud emas");
            }
        }
    }
}
