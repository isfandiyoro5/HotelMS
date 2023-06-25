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

        public DbSet<BookingRoom> BookingRooms { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingRoom>()
                .HasKey(br => new { br.BookingId, br.RoomId });
            modelBuilder.Entity<BookingRoom>()
                .HasOne(b => b.Booking)
                .WithMany(br => br.BookingRooms)
                .HasForeignKey(b => b.BookingId);
            modelBuilder.Entity<BookingRoom>()
                .HasOne(b => b.Room)
                .WithMany(br => br.BookingRooms)
                .HasForeignKey(b => b.RoomId);
        }
    }
}
