using Microsoft.AspNetCore.Mvc;
using EmailService;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IGuestService _guestService;
        private readonly IEmailSender _emailSender;

        public BookingController(IBookingService bookingService, IEmailSender emailSender, IGuestService guestService)
        {
            _bookingService = bookingService;
            _emailSender = emailSender;
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBooking(BookingRequestDto bookingRequestDto)
        {
            try
            {
                int result = await _bookingService.AddBookingAsync(bookingRequestDto);
                var guestResponseDto = await _guestService.GetGuestByIdAsync(bookingRequestDto.GuestId);
                var message = new Message(new string[] {guestResponseDto.Email}, "HotelMS", "Hotelga yangi Booking qoshildi" 
                    ,guestResponseDto.FullName);

                _emailSender.SendEmail(message);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<BookingResponseDto>> GetBookingById(int id)
        {
            try
            {
                return await _bookingService.GetBookingByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingResponseDto>>> GetAllBookings()
        {
            try
            {
                return await _bookingService.GetAllBookingsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateBooking(int id, BookingRequestDto bookingRequestDto)
        {
            try
            {
                int result = await _bookingService.UpdateBookingAsync(id, bookingRequestDto);
                var guestResponseDto = await _guestService.GetGuestByIdAsync(bookingRequestDto.GuestId);
                var message = new Message(new string[] { guestResponseDto.Email }, "HotelMS", "Hoteldagi Booking yangilandi"
                    ,guestResponseDto.FullName);

                _emailSender.SendEmail(message);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteBooking(int id)
        {
            try
            {
                return await _bookingService.DeleteBookingAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
