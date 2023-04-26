using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IBookingRepository
    {
        Task<int> AddBookingAsync(Booking booking);

        Task<Booking> GetBookingByIdAsync(int id);

        Task<List<Booking>> GetAllBookingsAsync();

        Task<int> UpdateBookingAsync(Booking booking);

        Task<int> DeleteBookingAsync(Booking booking);
    }
}
