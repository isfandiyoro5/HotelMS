using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(u => u.BookingId).NotNull();

            RuleFor(u => u.HotelId).NotNull();

            RuleFor(u => u.GuestId).NotNull();

            RuleFor(u => u.RoomNumber).NotNull();

            RuleFor(u => u.BookingDate).NotNull();

            RuleFor(u => u.BookingTime).NotNull();

            RuleFor(u => u.ArrivalDate).NotNull();

            RuleFor(u => u.DepartureDate).NotNull();

            RuleFor(u => u.NumberAdults).NotNull();

            RuleFor(u => u.NumberChildren).NotNull();
        }
    }
}
