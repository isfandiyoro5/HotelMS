using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        public async Task<int> CreateBookingAsync(Booking booking)
        {
            return await _bookingRepository.AddBookingAsync(booking);
        }

        [HttpGet("id")]
        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }

        [HttpGet]
        private async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }

        [HttpPut]
        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            return await _bookingRepository.UpdateBookingAsync(booking);
        }

        [HttpDelete]
        public async Task<int> DeleteBookingAsync(Booking booking)
        {
            return await _bookingRepository.DeleteBookingAsync(booking);
        }
    }
}
