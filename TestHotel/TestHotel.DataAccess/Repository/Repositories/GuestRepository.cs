using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _context;

        public GuestRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
            return guest.GuestID;
        }

        public int DeleteGuest(Guest guest)
        {
            _context.Guests.Remove(guest);
            _context.SaveChanges();
            return guest.GuestID;
        }

        public List<Guest> GetAllGuests() => _context.Guests
            .Include(u => u.Bookings)
            .Include(u => u.Bills)
            .ToList();

        public Guest GetGuestById(int id) => _context.Guests
            .Include(u => u.Bookings)
            .Include(u => u.Bills)
            .FirstOrDefault(u => u.GuestID == id);

        public int UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest);
            _context.SaveChanges();
            return guest.GuestID;
        }
    }
}
