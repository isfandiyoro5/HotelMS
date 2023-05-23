using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoleRequestDto
    {
        public string RoleTitle { get; set; }

        public string RoleDescription { get; set; }
    }

    public class RoleRequestDtoValidator : AbstractValidator<RoleRequestDto>
    {
        public RoleRequestDtoValidator()
        {
            RuleFor(u => u.RoleTitle)
                .NotNull().WithMessage("Role title ni kiritish kerak.")
                .NotEmpty().WithMessage("Role title bo'sh bo'la olmaydi.");

            RuleFor(u => u.RoleDescription)
                .NotNull().WithMessage("Role description ni kiritish kerak.")
                .NotEmpty().WithMessage("Role description bo'sh bo'la olmaydi.");
        }
    }
}
