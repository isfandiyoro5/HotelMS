using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.RequestDto
{
    public class BillRequestDto
    {
        public DateTime IfLateCheckout { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public int CreditCardNumber { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
