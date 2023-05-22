using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IRoomService
    {
        Task<int> AddRoomAsync(Room room);

        Task<int> UpdateRoomAsync(int id);

        Task<int> DeleteRoomAsync(int id);

        Task<Room> GetRoomByIdAsync(int id);

        Task<List<Room>> GetAllRoomsAsync();
    }
}
