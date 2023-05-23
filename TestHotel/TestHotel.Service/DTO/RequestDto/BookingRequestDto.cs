using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto
{
    public class BookingRequestDto
    {
        public DateTime BookingDate { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }
    }

    public class BookingRequestDtoValidator : AbstractValidator<BookingRequestDto>
    {
        public BookingRequestDtoValidator()
        {
            RuleFor(u => u.BookingDate)
                .NotEmpty().WithMessage("Booking date ni kiritish kerak.")
                .GreaterThan(DateTime.UtcNow).WithMessage("Booking date sanasi kelajakda bo'lishi kerak.");

            RuleFor(u => u.BookingTime)
                .NotEmpty().WithMessage("Booking time ni kiritish kerak.");

            RuleFor(u => u.ArrivalDate)
                .NotEmpty().WithMessage("Arrival date ni kiritish kerak.")
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date).WithMessage("Arrival date bugun yoki kelajakda bo'lishi kerak.");

            RuleFor(u => u.DepartureDate)
                .NotEmpty().WithMessage("Departure date ni kiritish kerak.")
                .GreaterThanOrEqualTo(u => u.ArrivalDate).WithMessage("Departure date kelish sanasida yoki undan keyin bo'lishi kerak.");

            RuleFor(u => u.NumberAdults)
                .NotEmpty().WithMessage("Number of adults ni kiritish kerak.")
                .GreaterThan(0).WithMessage("Number of adults soni no'ldan ketta bo'lishi kerak.");

            RuleFor(u => u.NumberChildren)
                .GreaterThanOrEqualTo(0).WithMessage("Number of children no'ldan katta yoki teng bo'lishi kerak.");
        }
    }
}
