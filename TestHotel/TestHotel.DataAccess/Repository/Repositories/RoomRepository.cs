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
            try
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room.RoomNumber;
            }
            catch
            {
                throw new Exception("Room qo'shilmadi");
            }
        }

        public async Task<int> DeleteRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return room.RoomNumber;
            }
            catch
            {
                throw new Exception("Room o'chirilmadi");
            }
        }

        public async Task<List<Room>> GetAllRoomsAsync() => await _context.Rooms
            .Include(u => u.roomType)
            .Include(u => u.bookings)
            .Include(u => u.Hotel)
            .ToListAsync();

        public async Task<Room> GetRoomByIdAsync(int roomNumber)
        {
            try
            {
                return await _context.Rooms
                    .Include(u => u.roomType)
                    .Include(u => u.bookings)
                    .Include(u => u.Hotel)
                    .FirstOrDefaultAsync(u => u.RoomNumber == roomNumber);
            }
            catch
            {
                throw new Exception("Room ID topilmadi");
            }
        }
            
        public async Task<int> UpdateRoomAsync(Room room)
        {
            try
            {
                _context.Rooms.Update(room);
                await _context.SaveChangesAsync();
                return room.RoomNumber;
            }
            catch
            {
                throw new Exception("Room o'zgartirilmadi");
            }
        }
    }
}
