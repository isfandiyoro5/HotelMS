using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestHotel.DataAccess.Model
{
    public class Bill
    {
        [Required]
        [Key]
        public int InvoiceNumber { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        [ForeignKey("Guest")]
        public int GuestId { get; set; }

        public int RoomCharge { get; set; }

        public int RoomService { get; set; }

        public int RestaurantCharges { get; set; }

        public int BarCharges { get; set; }

        public int MiscellaneousCharges { get; set; }

        public DateTime IfLateCheckout { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public string CreditCardNumber { get; set; }

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
