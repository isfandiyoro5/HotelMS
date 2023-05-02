using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IRoomTypeService
    {
        Task<int> AddRoomTypeAsync(RoomType roomType);

        Task<int> UpdateRoomTypeAsync(RoomType roomType);

        Task<int> DeleteRoomTypeAsync(RoomType roomType);

        Task<RoomType> GetRoomTypeByIdAsync(int id);

        Task<List<RoomType>> GetAllRoomTypesAsync();
    }
}
