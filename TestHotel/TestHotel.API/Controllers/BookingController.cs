using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;
using TestHotel.Service.Service.Services;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IBookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBooking(BookingRequestDto bookingRequestDto)
        {
            return await _bookingService.AddBookingAsync(bookingRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<BookingResponseDto>> GetBookingById(int id)
        {
            return await _bookingService.GetBookingByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingResponseDto>>> GetAllBookings()
        {
            return await _bookingService.GetAllBookingsAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateBooking(int id, BookingRequestDto bookingRequestDto)
        {
            return await _bookingService.UpdateBookingAsync(id, bookingRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteBooking(int id)
        {
            return await _bookingService.DeleteBookingAsync(id);
        }
    }
}
