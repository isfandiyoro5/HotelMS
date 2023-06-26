using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IGuestRepository
    {
        Task<int> AddGuestAsync(Guest guest);

        Task<Guest> GetGuestByIdAsync(int id);

        Task<List<Guest>> GetAllGuestsAsync();

        Task<int> UpdateGuestAsync(Guest guest);

        Task<int> DeleteGuestAsync(Guest guest);
    }
}
