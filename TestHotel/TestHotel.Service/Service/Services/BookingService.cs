using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ILogger<BookingService> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<BookingRequestDto> _bookingRequestDtoValidator;

        public BookingService(IBookingRepository bookingRepository, ILogger<BookingService> logger, IMapper mapper, IValidator<BookingRequestDto> bookingRequestDtoValidator)
        {
            _bookingRepository = bookingRepository;
            _logger = logger;
            _mapper = mapper;
            _bookingRequestDtoValidator = bookingRequestDtoValidator;
        }

        public async Task<int> AddBookingAsync(BookingRequestDto bookingRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _bookingRequestDtoValidator.ValidateAsync(bookingRequestDto);
                if (!validationResult.IsValid)
                {
                    return await _bookingRepository.AddBookingAsync(_mapper.Map<Booking>(bookingRequestDto));
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Bookingni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bookingni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> UpdateBookingAsync(int id, BookingRequestDto bookingRequestDto)
        {
            try
            {
                ValidationResult validationResult = await _bookingRequestDtoValidator.ValidateAsync(bookingRequestDto);
                if (!validationResult.IsValid)
                {
                    var bookingResult = await _bookingRepository.GetBookingByIdAsync(id);
                    if (bookingResult is not null)
                    {
                        bookingResult.BookingDate = bookingRequestDto.BookingDate;
                        bookingResult.BookingTime = bookingRequestDto.BookingTime;
                        bookingResult.ArrivalDate = bookingRequestDto.ArrivalDate;
                        bookingResult.DepartureDate = bookingRequestDto.DepartureDate;
                        bookingResult.NumberAdults = bookingRequestDto.NumberAdults;
                        bookingResult.NumberChildren = bookingRequestDto.NumberChildren;
                        return await _bookingRepository.UpdateBookingAsync(bookingResult);
                    }
                    else
                    {
                        throw new Exception("Update uchun Booking mavjud emas");
                    }
                }
                else
                {
                    throw new Exception("Qiymatlarni noto'g'ri yoki chala kiritgansiz, qaytadan barchasini to'g'ri va to'liq kiritishga urinib ko'ring");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Bookingni databazaga yangilashda xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni yangilashda xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bookingni yangilashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni yangilashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteBookingAsync(int id)
        {
            try
            {
                var bookingResult = await _bookingRepository.GetBookingByIdAsync(id);
                if (bookingResult is not null)
                {
                    return await _bookingRepository.DeleteBookingAsync(bookingResult);
                }
                else
                {
                    throw new Exception("Delet uchun Booking mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Bookingni databazadan o'chirishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni o'chirishda xatolik bor. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bookingni o'chirishda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Bookingni o'chirishda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<BookingResponseDto>(await _bookingRepository.GetBookingByIdAsync(id));
            }
            catch (DbException ex)
            {
                _logger.LogError("BookingById ni databazadan olishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingById ni olishda xatolik bor. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("BookingById ni olishda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("BookingById ni olishda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<BookingResponseDto>> GetAllBookingsAsync()
        {
            try
            {
                return _mapper.Map<List<BookingResponseDto>>(await _bookingRepository.GetAllBookingsAsync());
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Barcha Bookinglarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Barcha Bookinglarni olishda xatolik yuz berdi. Iltimos qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Bookinglarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Barcha Bookinglarni olishda xatolik yuz berdi. Iltimos qayta urinib ko'ring");
            }
        }
    }
}
