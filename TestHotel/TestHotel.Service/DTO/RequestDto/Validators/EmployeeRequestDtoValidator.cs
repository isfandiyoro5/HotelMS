using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto.Validators
{
    public class EmployeeRequestDtoValidator : AbstractValidator<EmployeeRequestDto>
    {
        public EmployeeRequestDtoValidator()
        {
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
                .IsInEnum().WithMessage("Noto'g'ri Gender.");

            RuleFor(u => u.PhoneNumber)
                .NotNull().WithMessage("Phone number ni kiritish kerak.")
                .NotEmpty().WithMessage("Phone number bo'sh bo'la olmaydi.")
                .Matches(@"^[0-9]{10}$").WithMessage("Telefon raqami noto'g'ri kiritilgan.");

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Email ni kiritish kerak.")
                .NotEmpty().WithMessage("Email bo'sh bo'la olmaydi.")
                .EmailAddress().WithMessage("Noto'g'ri Email manzil kiritilgan.");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password ni kiritish kerak.")
                .NotEmpty().WithMessage("Password bo'sh bo'la olmaydi.")
                .MinimumLength(8).WithMessage("Password ning uzunligi kamida 8 ta belgidan iborat bo'lishi kerak.");

            RuleFor(u => u.Salary)
                .NotNull().WithMessage("Salary ni kiritish kerak.")
                .GreaterThan(0).WithMessage("Salary no'l dan katta bo'lishi kerak.");
        }
    }
}
