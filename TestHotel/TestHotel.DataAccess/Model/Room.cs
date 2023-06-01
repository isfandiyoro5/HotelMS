using System.ComponentModel.DataAnnotations;

namespace TestHotel.DataAccess.Model
{
    public class Room
    {
        [Required]
        [Key]
        public int RoomNumber { get; set; }

        public RoomTypes RoomTypes { get; set; }

        public int RoomTypeId { get; set; }

        public int HotelId { get; set; }

        public string Occupancy { get; set; }


        public List<RoomType> roomType { get; set; }

        public List<Booking> bookings { get; set; }

        public Hotel Hotel { get; set; }
    }

    public enum RoomTypes
    {
        Standard,
        Deluxe,
        JuniorSuite,
        SeniorSuite
    }
}
