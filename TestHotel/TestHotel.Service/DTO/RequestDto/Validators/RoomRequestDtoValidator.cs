using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto.Validators
{
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
