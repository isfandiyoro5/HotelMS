using FluentValidation;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class BillRequestDto
    {
        public int BookingId { get; set; }

        public int GuestId { get; set; }

        public DateTime IfLateCheckout { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public string CreditCardNumber { get; set; }

        public DateTime ExpireDate { get; set; }
    }

    public class BillRequestDtoValidator : AbstractValidator<BillRequestDto>
    {
        public BillRequestDtoValidator()
        {
            RuleFor(u => u.IfLateCheckout)
                .NotNull().WithMessage("Late checkout ni kiritish kerak.");

            RuleFor(u => u.PaymentDate)
                .NotNull().WithMessage("Payment date ni kiritish kerak.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Payment date bugun yoki bugundan keyin bo'lishi kerak.");

            RuleFor(u => u.PaymentMode)
                .NotNull().WithMessage("Payment mode ni kiritish kerak.");

            RuleFor(u => u.CreditCardNumber)
                .NotNull().WithMessage("Credit card number ni kiritish kerak.")
                .NotEmpty().WithMessage("Credit card number bo'sh bo'lishi mumkin emas.");

            RuleFor(u => u.ExpireDate)
                .NotNull().WithMessage("Expiration date ni kiritish kerak.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Expiration date bugun yoki bugundan keyin bo'lishi kerak.");
        }
    }
}
