using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(u => u.RoomNumber).NotNull();

            RuleFor(u => u.RoomTypes).NotNull();
            
            RuleFor(u => u.RoomTypeId).NotNull();
            
            RuleFor(u => u.HotelId).NotNull();
            
            RuleFor(u => u.Occupancy).NotNull();
        }
    }
}
