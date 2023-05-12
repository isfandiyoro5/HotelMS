using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(u => u.EmployeeId).NotNull();
            
            RuleFor(u => u.HotelId).NotNull();
            
            RuleFor(u => u.RoleId).NotNull();
            
            RuleFor(u => u.FirstName).NotNull();
            
            RuleFor(u => u.LastName).NotNull();
            
            RuleFor(u => u.BirthDate).NotNull();
            
            RuleFor(u => u.Gender).NotNull();
            
            RuleFor(u => u.PhoneNumber).NotNull();
            
            RuleFor(u => u.Email).NotNull();
            
            RuleFor(u => u.Password).NotNull();
            
            RuleFor(u => u.Salary).NotNull();
        }
    }
}
