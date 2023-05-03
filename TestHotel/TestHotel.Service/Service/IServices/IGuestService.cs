using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IGuestService
    {
        Task<int> AddGuestAsync(Guest guest);

        Task<int> UpdateGuestAsync(Guest guest);

        Task<int> DeleteGuestAsync(int id);

        Task<Guest> GetGuestByIdAsync(int id);

        Task<List<Guest>> GetAllGuestsAsync();
    }
}
