using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            return await _bookingRepository.AddBookingAsync(booking);
        }

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            var bookingExist = GetBookingByIdAsync(booking.BookingId);
            if (bookingExist != null)
            {
                return await _bookingRepository.UpdateBookingAsync(booking);
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> DeleteBookingAsync(int id)
        {
            var bookingExist = await GetBookingByIdAsync(id);
            if (bookingExist != null)
            {
                return await _bookingRepository.DeleteBookingAsync(bookingExist);

            }
            else
            {
                return 0;
            }
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
           return await _bookingRepository.GetAllBookingsAsync();
        }
    }
}
