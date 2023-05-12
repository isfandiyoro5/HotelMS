using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class RoomTypeValidator : AbstractValidator<RoomType>
    {
        public RoomTypeValidator()
        {
            RuleFor(u => u.RoomTypeId).NotNull();
            
            RuleFor(u => u.RoomTypes).NotNull();
            
            RuleFor(u => u.RoomPrice).NotNull();
            
            RuleFor(u => u.RoomImage).NotNull();
            
            RuleFor(u => u.RoomsDescription).NotNull();
        }
    }
}
