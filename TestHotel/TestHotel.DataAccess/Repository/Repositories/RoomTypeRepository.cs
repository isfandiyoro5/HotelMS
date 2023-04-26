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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRoomTypeAsync(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();
            return roomType.RoomTypeId;
        }

        public async Task<int> DeleteRoomTypeAsync(RoomType roomType)
        {
            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();
            return roomType.RoomTypeId;
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync() => await _context.RoomTypes
            .Include(u => u.Room)
            .ToListAsync();

        public async Task<RoomType> GetRoomTypeByIdAsync(RoomTypes roomTypes) => await _context.RoomTypes
            .Include(u => u.Room)
            .FirstOrDefaultAsync(u => u.RoomTypes == roomTypes);

        public async Task<int> UpdateRoomTypeAsync(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();
            return roomType.RoomTypeId;
        }
    }
}
