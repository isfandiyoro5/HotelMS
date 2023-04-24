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
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return hotel.HotelId;
        }

        public int DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
            return hotel.HotelId;
        }

        public List<Hotel> GetAllHotels() => _context.Hotels.Include(u => u.Rooms)
            .Include(u => u.Bookings).Include(u => u.Employees).ToList();

        public Hotel GetHotelById(int id) => _context.Hotels.Include(u => u.Rooms)
            .Include(u => u.Bookings).Include(u => u.Employees).FirstOrDefault(u => u.HotelId == id);

        public int UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
            return hotel.HotelId;
        }
    }
}
