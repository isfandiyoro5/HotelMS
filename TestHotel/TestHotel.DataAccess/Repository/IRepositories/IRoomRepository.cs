using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IRoomRepository
    {
        Task<int> AddRoomAsync(Room room);

        Task<Room> GetRoomByIdAsync(int id);

        Task<List<Room>> GetAllRoomsAsync();

        Task<int> UpdateRoomAsync(Room room);

        Task<int> DeleteRoomAsync(Room room);
    }
}
