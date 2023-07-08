using TestHotel.DataAccess.Model;

namespace TestHotel.Service.DTO.ResponseDto
{
    public class GuestResponseDto
    {
        public int GuestId { get; set; }

        public string FullName { get; set; }

        public GuestPriority GuestPriority { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
