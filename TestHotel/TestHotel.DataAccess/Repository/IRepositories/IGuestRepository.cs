using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
