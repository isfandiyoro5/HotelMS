using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(u => u.RoleId).NotNull();

            RuleFor(u => u.RoleTitle).NotNull();
            
            RuleFor(u => u.RoleDescription).NotNull();
        }
    }
}
