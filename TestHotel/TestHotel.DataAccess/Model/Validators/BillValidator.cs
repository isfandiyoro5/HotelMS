using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestHotel.DataAccess.Model.Validators
{
    public class BillValidator : AbstractValidator<Bill>
    {
        public BillValidator()
        {
        }
    }
}
