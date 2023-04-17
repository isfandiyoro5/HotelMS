using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Bill
    {
        public int InvoiceNo { get; set; }
        public int BookingId{ get; set; }
        public int GuestId { get; set; }
        public int RoomCharge { get; set; }
        public int RoomService { get; set; }
        public int RestaurantCharges { get; set; }
        public int BarCharges { get; set; }
        public int MiscCharges { get; set; }
        public int IfLateCheckout { get; set; }
        public int PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public int CreditCardNo { get; set; }
        public int ExpireDate { get; set; }
        public int ChequeNo { get; set; }

        public Guest Guest { get; set; }
        public Booking Booking { get; set; }
    }
}
