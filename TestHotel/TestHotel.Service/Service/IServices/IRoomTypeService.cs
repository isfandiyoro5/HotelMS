using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IRoomTypeService
    {
        Task<int> AddRoomTypeAsync(RoomType roomType);

        Task<int> UpdateRoomTypeAsync(int id);

        Task<int> DeleteRoomTypeAsync(int id);

        Task<RoomType> GetRoomTypeByIdAsync(int id);

        Task<List<RoomType>> GetAllRoomTypesAsync();
    }
}
