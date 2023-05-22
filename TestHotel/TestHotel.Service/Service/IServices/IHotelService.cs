using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IHotelService
    {
        Task<int> AddHotelAsync(Hotel hotel);

        Task<int> UpdateHotelAsync(int id);

        Task<int> DeleteHotelAsync(int id);

        Task<Hotel> GetHotelByIdAsync(int id);

        Task<List<Hotel>> GetAllHotelsAsync();
    }
}
