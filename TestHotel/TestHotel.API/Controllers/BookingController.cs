using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Model;
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
        public readonly IBookingService _bookingService;
        public readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingService bookingService, IBookingRepository bookingRepository)
        {
            _bookingService = bookingService;
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBooking(BookingRequestDto bookingRequestDto)
        {
            try
            {
                return await _bookingService.AddBookingAsync(bookingRequestDto);
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
                return await _bookingService.UpdateBookingAsync(id, bookingRequestDto);
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

        [HttpGet("IdTest")]
        public async Task<ActionResult<Booking>> GetBookingByIdTest(int id)
        {
            try
            {
                return await _bookingRepository.GetBookingByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
