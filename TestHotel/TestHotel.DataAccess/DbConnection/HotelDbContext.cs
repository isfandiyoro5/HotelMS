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

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
