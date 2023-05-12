using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto.Validators
{
    internal class BillRequestDtoValidator : AbstractValidator<BillRequestDto>
    {
        public BillRequestDtoValidator()
        {
        }
    }
}
