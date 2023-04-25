using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IRoomRepository
    {
        public int AddRoom(Room room);

        public Room GetRoomById(int id);

        public List<Room> GetAllRooms();

        public int UpdateRoom(Room room);

        public int DeleteRoom(Room room);
    }
}
