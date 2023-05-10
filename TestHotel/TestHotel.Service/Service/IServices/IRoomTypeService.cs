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

        Task<int> UpdateRoomTypeAsync(int id);

        Task<int> DeleteRoomTypeAsync(int id);

        Task<RoomType> GetRoomTypeByIdAsync(int id);

        Task<List<RoomType>> GetAllRoomTypesAsync();
    }
}
