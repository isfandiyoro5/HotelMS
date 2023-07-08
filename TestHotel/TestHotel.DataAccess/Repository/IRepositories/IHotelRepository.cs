using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IHotelRepository
    {
        Task<int> AddHotelAsync(Hotel hotel);

        Task<Hotel> GetHotelByIdAsync(int id);

        Task<List<Hotel>> GetAllHotelsAsync();

        Task<int> UpdateHotelAsync(Hotel hotel);

        Task<int> DeleteHotelAsync(Hotel hotel);
    }
}
