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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public RoomTypes AddRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            _context.SaveChanges();
            return roomType.RoomTypes;
        }

        public RoomTypes DeleteRoomType(RoomType roomType)
        {
            _context.RoomTypes.Remove(roomType);
            _context.SaveChanges();
            return roomType.RoomTypes;
        }

        public List<RoomType> GetAllRoomTypes() => _context.RoomTypes.Include(u => u.Room).ToList();

        public RoomType GetRoomTypeById(RoomTypes roomTypes) => _context.RoomTypes
            .Include(u => u.Room).FirstOrDefault(u => u.RoomTypes == roomTypes);

        public RoomTypes UpdateRoomType(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            _context.SaveChanges();
            return roomType.RoomTypes;
        }
    }
}
