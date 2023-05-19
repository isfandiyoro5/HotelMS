using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.Service.IServices
{
    public interface IBookingService
    {
        Task<int> AddBookingAsync(BookingRequestDto bookingRequestDto);

        Task<int> UpdateBookingAsync(int id, BookingRequestDto bookingRequestDto);

        Task<int> DeleteBookingAsync(int id);

        Task<BookingResponseDto> GetBookingByIdAsync(int id);

        Task<List<BookingResponseDto>> GetAllBookingsAsync();
    }
}
