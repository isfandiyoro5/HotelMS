using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.DTO.RequestDto
{
    internal class BillRequestDto
    {
        public DateTime IfLateCheckout { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMode paymentMode { get; set; }

        public int CreditCardNumber { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
