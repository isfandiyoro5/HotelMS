using Microsoft.EntityFrameworkCore;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.DbConnection
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) :
            base(options)
        {
        }

        DbSet<Bill> Bills { get; set; }

        DbSet<Booking> Bookings { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Guest> Guests { get; set; }

        DbSet<Hotel> Hotels { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<Room> Rooms { get; set; }

        DbSet<RoomType> RoomTypes { get; set; }
    }
}
