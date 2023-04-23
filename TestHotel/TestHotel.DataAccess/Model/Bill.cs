using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    public class Bill
    {
        public int InvoiceNumber { get; set; }

        public int BookingId { get; set; }

        public int GuestId { get; set; }

        public int RoomCharge { get; set; }

        public int RoomService { get; set; }

        public int RestaurantCharges { get; set; }

        public int BarCharges { get; set; }

        public int MiscellaneousCharges { get; set; }

        public DateTime IfLateCheckout { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMode paymentMode { get; set; }
       
        public int CreditCardNumber { get; set; }
        
        public DateTime ExpireDate { get; set; }
        
        public int ChequeNumber { get; set; }


        public Guest Guest { get; set; }
        
        public Booking Booking { get; set; }
    }

    public enum PaymentMode
    {
        Uzcard,
        Humo,
        VisaCard,
        Cash
    }
}
