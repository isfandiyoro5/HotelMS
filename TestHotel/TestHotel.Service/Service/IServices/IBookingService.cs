using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IBookingService
    {
        Task<int> AddBookingAsync(Booking booking);

        Task<int> UpdateBookingAsync(Booking booking);

        Task<int> DeleteBookingAsync(Booking booking);

        Task<Booking> GetBookingByIdAsync(int id);

        Task<List<Booking>> GetAllBookingsAsync();
    }
}
