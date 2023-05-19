using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.Service.IServices
{
    public interface IRoomService
    {
        Task<int> AddRoomAsync(RoomRequestDto roomRequestDto);

        Task<int> UpdateRoomAsync(int id, RoomRequestDto roomRequestDto);

        Task<int> DeleteRoomAsync(int id);

        Task<RoomResponseDto> GetRoomByIdAsync(int id);

        Task<List<RoomRequestDto>> GetAllRoomsAsync();
    }
}
