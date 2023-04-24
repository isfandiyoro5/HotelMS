using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public interface IRoomTypeRepository
    {
        public RoomTypes AddRoomType(RoomType roomType);

        public RoomType GetRoomTypeById(RoomTypes roomTypes);

        public List<RoomType> GetAllRoomTypes();

        public RoomTypes UpdateRoomType(RoomType roomType);

        public RoomTypes DeleteRoomType(RoomType roomType);
    }
}
