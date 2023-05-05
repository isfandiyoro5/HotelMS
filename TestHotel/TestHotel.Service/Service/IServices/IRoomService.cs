using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IRoomService
    {
        Task<int> AddRoomAsync(Room room);

        Task<int> UpdateRoomAsync(int id);

        Task<int> DeleteRoomAsync(int id);

        Task<Room> GetRoomByIdAsync(int id);

        Task<List<Room>> GetAllRoomsAsync();
    }
}
