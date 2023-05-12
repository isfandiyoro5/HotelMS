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
            RuleFor(u => u.InvoiceNumber).NotNull();

            RuleFor(u => u.BookingId).NotNull();
            
            RuleFor(u => u.GuestId).NotNull();
            
            RuleFor(u => u.RoomCharge).NotNull();
            
            RuleFor(u => u.RoomService).NotNull();
            
            RuleFor(u => u.RestaurantCharges).NotNull();
            
            RuleFor(u => u.BarCharges).NotNull();
            
            RuleFor(u => u.MiscellaneousCharges).NotNull();
            
            RuleFor(u => u.IfLateCheckout).NotNull();
            
            RuleFor(u => u.PaymentDate).NotNull();
            
            RuleFor(u => u.PaymentMode).NotNull();
            
            RuleFor(u => u.CreditCardNumber).NotNull();
            
            RuleFor(u => u.ExpireDate).NotNull();
            
            RuleFor(u => u.ChequeNumber).NotNull();
        }
    }
}
