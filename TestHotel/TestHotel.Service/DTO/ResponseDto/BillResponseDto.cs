namespace TestHotel.Service.DTO.ResponseDto
{
    public class BillResponseDto
    {
        public int InvoiceNumber { get; set; }

        public int BookingId { get; set; }

        public string GuestFullName { get; set; }

        public int RoomCharge { get; set; }

        public int RoomService { get; set; }

        public int RestaurantCharges { get; set; }

        public int BarCharges { get; set; }

        public int MiscellaneousCharges { get; set; }

        public int ChequeNumber { get; set; }
    }
}
