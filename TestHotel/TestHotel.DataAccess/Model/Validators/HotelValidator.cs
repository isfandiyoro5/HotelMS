using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(u => u.HotelName).NotNull();
            
            RuleFor(u => u.HotelName).NotNull();
            
            RuleFor(u => u.Address).NotNull();
            
            RuleFor(u => u.City).NotNull();
            
            RuleFor(u => u.Country).NotNull();
            
            RuleFor(u => u.NumberOfRooms).NotNull();
            
            RuleFor(u => u.PhoneNumber).NotNull();
            
            RuleFor(u => u.StarRating).NotNull();
        }
    }
}
