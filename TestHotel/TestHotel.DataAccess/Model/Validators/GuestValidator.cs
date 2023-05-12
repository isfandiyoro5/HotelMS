using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class GuestValidator : AbstractValidator<Guest>
    {
        public GuestValidator()
        {
            RuleFor(u => u.GuestId).NotNull();
            
            RuleFor(u => u.BookingId).NotNull();
            
            RuleFor(u => u.GuestPriority).NotNull();
            
            RuleFor(u => u.FirstName).NotNull();
            
            RuleFor(u => u.LastName).NotNull();
            
            RuleFor(u => u.BirthDate).NotNull();
            
            RuleFor(u => u.Gender).NotNull();
            
            RuleFor(u => u.PhoneNumber).NotNull();
            
            RuleFor(u => u.Email).NotNull();
            
            RuleFor(u => u.Password).NotNull();
            
            RuleFor(u => u.PassportNumber).NotNull();
            
            RuleFor(u => u.Address).NotNull();
            
            RuleFor(u => u.City).NotNull();
            
            RuleFor(u => u.Country).NotNull();
        }
    }
}
