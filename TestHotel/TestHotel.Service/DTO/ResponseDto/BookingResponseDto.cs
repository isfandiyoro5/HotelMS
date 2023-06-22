namespace TestHotel.Service.DTO.ResponseDto
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }

        public string GuestFullName { get; set; }

        public string HotelName { get; set; }

        public List<int> RoomsNumber { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}
