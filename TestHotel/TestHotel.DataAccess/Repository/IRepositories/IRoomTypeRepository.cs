using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IRoomTypeRepository
    {
        Task<int> AddRoomTypeAsync(RoomType roomType);

        Task<RoomType> GetRoomTypeByIdAsync(int roomTypeId);

        Task<List<RoomType>> GetAllRoomTypesAsync();

        Task<int> UpdateRoomTypeAsync(RoomType roomType);

        Task<int> DeleteRoomTypeAsync(RoomType roomType);
    }
}
