using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IHotelService
    {
        Task<int> AddHotelAsync(Hotel hotel);

        Task<int> UpdateHotelAsync(Hotel hotel);

        Task<int> DeleteHotelAsync(int id);

        Task<Hotel> GetHotelByIdAsync(int id);

        Task<List<Hotel>> GetAllHotelsAsync();
    }
}
