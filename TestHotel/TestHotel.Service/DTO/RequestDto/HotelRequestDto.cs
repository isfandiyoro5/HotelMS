using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto
{
    public class HotelRequestDto
    {
        public string HotelName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int NumberOfRooms { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class HotelRequestDtoValidator : AbstractValidator<HotelRequestDto>
    {
        public HotelRequestDtoValidator()
        {
            RuleFor(u => u.HotelName)
                .NotNull().WithMessage("Hotel name ni kiritish kerak.")
                .NotEmpty().WithMessage("Hotel name bo'sh bo'la olmaydi.");

            RuleFor(u => u.Address)
                .NotNull().WithMessage("Address ni kiritish kerak.")
                .NotEmpty().WithMessage("Address bo'sh bo'la olmaydi.");

            RuleFor(u => u.City)
                .NotNull().WithMessage("City ni kiritish kerak.")
                .NotEmpty().WithMessage("City bo'sh bo'la olmaydi.");

            RuleFor(u => u.Country)
                .NotNull().WithMessage("Country ni kkiritish kerak.")
                .NotEmpty().WithMessage("Country bo'sh bo'la olmaydi.");

            RuleFor(u => u.NumberOfRooms)
                .NotNull().WithMessage("Number of rooms ni kiritish kerak.")
                .GreaterThan(0).WithMessage("Number of rooms no'ldan katta bo'lishi kerak.");

            RuleFor(u => u.PhoneNumber)
                .NotNull().WithMessage("Phone number ni kiritish kerak.")
                .NotEmpty().WithMessage("Phone number bo'sh bo'la olmaydi.")
                .Matches(@"^[0-9]{10}$").WithMessage("Telefon raqami noto'g'ri kiritilgan.");
        }
    }
}
