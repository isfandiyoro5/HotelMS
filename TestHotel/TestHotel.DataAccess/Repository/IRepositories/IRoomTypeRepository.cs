using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IRoomTypeRepository
    {
        public int AddRoomType(RoomType roomType);

        public RoomType GetRoomTypeById(RoomTypes roomTypes);

        public List<RoomType> GetAllRoomTypes();

        public int UpdateRoomType(RoomType roomType);

        public int DeleteRoomType(RoomType roomType);
    }
}
