using Xunit;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using FluentAssertions;

namespace HotelMSUnitTest.DataAccessTest.RepositoresTest
{
    public class BillRepositoryTest
    {
        private IBillRepository _billRepository;

        public BillRepositoryTest(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [Fact]
        public void AddBillAsync_TogriBillKiritganimizda_BillningIDsiniChiqarish()
        {
            // Arrenge
            var toliqBill = new Bill
            {
                BookingId = 0,
                GuestId = 0,
                RoomCharge = 12,
                RoomService = 123,
                RestaurantCharges = 123,
                BarCharges = 123,
                MiscellaneousCharges = 0,
                IfLateCheckout = DateTime.Now,
                PaymentDate = DateTime.Now,
                PaymentMode = PaymentMode.Humo,
                CreditCardNumber = 0,
                ExpireDate = DateTime.Now,
                ChequeNumber = 0,
            };

            // Act
            var result = _billRepository.AddBillAsync(toliqBill);

            // Assert
            result.Should().Be(toliqBill.InvoiceNumber);
        }
    }
}
