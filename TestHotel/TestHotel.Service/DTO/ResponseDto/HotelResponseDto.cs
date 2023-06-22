using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.ResponseDto
{
    public class HotelResponseDto
    {
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string Address { get; set; }

        public int NumberOfRooms { get; set; }

        public string PhoneNumber { get; set; }

        public StarRating StarRating { get; set; }
    }
}
