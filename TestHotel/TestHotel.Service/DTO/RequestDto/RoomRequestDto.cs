using FluentValidation;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoomRequestDto
    {
        public int RoomNumber { get; set; }

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
                .NotEmpty().WithMessage("Room number bo'sh bo'la olmaydi.");

            RuleFor(u => u.RoomTypes)
                .NotNull().WithMessage("Room types ni kiritish kerak.");
        }
    }
}
