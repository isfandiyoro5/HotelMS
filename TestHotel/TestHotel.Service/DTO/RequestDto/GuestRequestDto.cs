using FluentValidation;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class GuestRequestDto
    {
        public GuestPriority GuestPriority { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PassportNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }

    public class GuestRequestDtoValidator : AbstractValidator<GuestRequestDto>
    {
        public GuestRequestDtoValidator()
        {
            RuleFor(u => u.GuestPriority)
                .NotNull().WithMessage("Guest priority ni kiritish kerak.");

            RuleFor(u => u.FirstName)
                .NotNull().WithMessage("First name ni kiritish kerak.")
                .NotEmpty().WithMessage("First name bo'sh bo'la olmaydi.");

            RuleFor(u => u.LastName)
                .NotNull().WithMessage("Last name ni kiritish kerak.")
                .NotEmpty().WithMessage("Last name bo'sh bo'la olmaydi.");

            RuleFor(u => u.BirthDate)
                .NotNull().WithMessage("Birth date ni kiritish kerak.")
                .LessThan(DateTime.Today).WithMessage("Birth date sanasi o'tmishda bo'lishi kerak.");

            RuleFor(u => u.Gender)
                .NotNull().WithMessage("Gender ni kiritish kerak.")
                .IsInEnum().WithMessage("Noto'g'ri gender.");

            RuleFor(u => u.PhoneNumber)
                .NotNull().WithMessage("Phone number ni kiritish kerak.")
                .NotEmpty().WithMessage("Phone number bo'sh bo'la olmaydi.");
                /*.Matches(@"^[0-9]{10}$").WithMessage("Telefon raqami not'g'ri kiritilgan.");*/

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Email ni kiritish kerak.")
                .NotEmpty().WithMessage("Email bo'sh bo'la olmaydi.")
                .EmailAddress().WithMessage("Noto'g'ri Email manzil kiritilgan.");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password ni kiritish kerak.")
                .NotEmpty().WithMessage("Password bo'sh bo'la olmaydi.")
                .MinimumLength(8).WithMessage("Password ning uzunligi kamida 8 ta belgidan iborat bo'lishi kerak.");

            RuleFor(u => u.PassportNumber)
                .NotNull().WithMessage("Passport number ni kiritish kerak.")
                .NotEmpty().WithMessage("Passport number bo'sh bo'la olmaydi.");

            RuleFor(u => u.Street)
                .NotNull().WithMessage("Address ni kiritish kerak.")
                .NotEmpty().WithMessage("Address bo'sh bo'la olmaydi.");

            RuleFor(u => u.City)
                .NotNull().WithMessage("City ni kiritish kerak.")
                .NotEmpty().WithMessage("City bo'sh bo'la olmaydi.");

            RuleFor(u => u.Country)
                .NotNull().WithMessage("Country ni kiritish kerak.")
                .NotEmpty().WithMessage("Country bo'sh bo'la olmaydi.");
        }
    }
}
