using FluentValidation;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoomRequestDto
    {
        public int RoomNumber { get; set; }

        public int HotelId { get; set; }

        public RoomTypes RoomTypes { get; set; }

        public Occupancy Occupancy { get; set; }

        public double RoomPrice { get; set; }

        public string RoomImage { get; set; }

        public string RoomsDescription { get; set; }
    }

    public class RoomRequestDtoValidator : AbstractValidator<RoomRequestDto>
    {
        public RoomRequestDtoValidator()
        {
            RuleFor(u => u.RoomNumber)
                .NotNull().WithMessage("Room number ni kiritish kerak.")
                .NotEmpty().WithMessage("Room number bo'sh bo'la olmaydi.")
                .GreaterThan(0).WithMessage("Room number 0dan katta bo'lishi kerak.");
            
            RuleFor(u => u.RoomTypes)
                .NotNull().WithMessage("Room types ni kiritish kerak.");

            RuleFor(u => u.Occupancy)
                .NotNull().WithMessage("Occupancy ni kiritish kerak.");

            RuleFor(u => u.RoomPrice)
                .NotNull().WithMessage("Room price ni kiritish kerak.")
                .NotEmpty().WithMessage("Room price bo'sh bo'la olmaydi.")
                .GreaterThan(0).WithMessage("Room price 0dan katta bo'lishi kerak.");
        }
    }
}
