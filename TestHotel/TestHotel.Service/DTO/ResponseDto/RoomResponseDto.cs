namespace TestHotel.Service.DTO.ResponseDto
{
    public class RoomResponseDto
    {
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public string Occupancy { get; set; }

        public string RoomsDescription { get; set; }

        public double RoomPrice { get; set; }
    }
}
