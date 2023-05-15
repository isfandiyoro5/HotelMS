using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto.Validators
{
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
