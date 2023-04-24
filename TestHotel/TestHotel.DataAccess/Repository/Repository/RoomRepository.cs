using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room.RoomNumber;
        }

        public int DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return room.RoomNumber;
        }

        public List<Room> GetAllRooms() => _context.Rooms.Include(u => u.roomType)
            .Include(u => u.bookings).Include(u => u.Hotel).ToList();

        public Room GetRoomById(int roomNumber) => _context.Rooms.Include(u => u.roomType)
            .Include(u => u.bookings).Include(u => u.Hotel).FirstOrDefault(u => u.RoomNumber == roomNumber);

        public int UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return room.RoomNumber;
        }
    }
}
