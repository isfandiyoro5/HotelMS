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
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room.RoomNumber;
        }

        public async Task<int> DeleteRoomAsync(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room.RoomNumber;
        }

        public async Task<List<Room>> GetAllRoomsAsync() => await _context.Rooms
            .Include(u => u.roomType)
            .Include(u => u.bookings)
            .Include(u => u.Hotel)
            .ToListAsync();

        public async Task<Room> GetRoomByIdAsync(int roomNumber) => await _context.Rooms
            .Include(u => u.roomType)
            .Include(u => u.bookings)
            .Include(u => u.Hotel)
            .FirstOrDefaultAsync(u => u.RoomNumber == roomNumber);

        public async Task<int> UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room.RoomNumber;
        }
    }
}
