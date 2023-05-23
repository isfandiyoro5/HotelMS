using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoomTypeRequestDto
    {
        public RoomTypes RoomTypes { get; set; }

        public string RoomsDescription { get; set; }
    }

    public class RoomTypeRequestDtoValidator : AbstractValidator<RoomTypeRequestDto>
    {
        public RoomTypeRequestDtoValidator()
        {
            RuleFor(u => u.RoomTypes)
                .NotNull().WithMessage("Room types ni kiritish kerak.");

            RuleFor(u => u.RoomsDescription)
                .NotNull().WithMessage("Rooms description ni kiritish kerak.")
                .NotEmpty().WithMessage("Rooms description bo'sh bo'la olmaydi.");
        }
    }
}
