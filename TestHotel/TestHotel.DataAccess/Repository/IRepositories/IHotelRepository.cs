using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IHotelRepository
    {
        public int AddHotel(Hotel hotel);

        public Hotel GetHotelById(int id);

        public List<Hotel> GetAllHotels();

        public int UpdateHotel(Hotel hotel);

        public int DeleteHotel(Hotel hotel);
    }
}
