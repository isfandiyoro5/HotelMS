using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IGuestService
    {
        Task<int> AddGuestAsync(Guest guest);

        Task<int> UpdateGuestAsync(int id);

        Task<int> DeleteGuestAsync(int id);

        Task<Guest> GetGuestByIdAsync(int id);

        Task<List<Guest>> GetAllGuestsAsync();
    }
}
