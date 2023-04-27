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
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();
                return hotel.HotelId;
            }
            catch
            {
                throw new Exception("Hotel qo'shilmadi");
            }
        }

        public async Task<int> DeleteHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return hotel.HotelId;
            }
            catch
            {
                throw new Exception("Hotel o'chirilmadi");
            }
        }

        public async Task<List<Hotel>> GetAllHotelsAsync() => await _context.Hotels
            .Include(u => u.Rooms)
            .Include(u => u.Bookings)
            .Include(u => u.Employees)
            .ToListAsync();

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                 return await _context.Hotels
                    .Include(u => u.Rooms)
                    .Include(u => u.Bookings)
                    .Include(u => u.Employees)
                    .FirstOrDefaultAsync(u => u.HotelId == id);
            }
            catch
            {
                throw new Exception("Hotel ID topilmadi");
            }
        }

        public async Task<int> UpdateHotelAsync(Hotel hotel)
        {
            try
            {
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();
                return hotel.HotelId;
            }
            catch
            {
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
