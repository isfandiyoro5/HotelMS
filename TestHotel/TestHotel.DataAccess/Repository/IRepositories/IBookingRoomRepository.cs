using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IBookingRoomRepository
    {
        Task AddBookingRoomAsync(BookingRoom bookingRoom);

        Task UpdateBookingRoomAsync(BookingRoom bookingRoom);

        Task DeleteBookingRoomAsync(BookingRoom bookingRoom);
    }
}
