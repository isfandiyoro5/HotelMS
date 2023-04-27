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

        public async Task<int> AddGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest.GuestID;
        }

        public async Task<int> DeleteGuestAsync(Guest guest)
        {
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return guest.GuestID;
        }

        public async Task<List<Guest>> GetAllGuestsAsync() => await _context.Guests
            .Include(u => u.Bookings)
            .Include(u => u.Bills)
            .ToListAsync();

        public async Task<Guest> GetGuestByIdAsync(int id) => await _context.Guests
            .Include(u => u.Bookings)
            .Include(u => u.Bills)
            .FirstOrDefaultAsync(u => u.GuestID == id);

        public async Task<int> UpdateGuestAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
            return guest.GuestID;
        }
    }
}
