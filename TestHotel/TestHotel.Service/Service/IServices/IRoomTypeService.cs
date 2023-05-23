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
    public interface IRoomTypeService
    {
        Task<int> AddRoomTypeAsync(RoomTypeRequestDto roomTypeRequestDto);

        Task<int> UpdateRoomTypeAsync(int id, RoomTypeRequestDto roomTypeRequestDto);

        Task<int> DeleteRoomTypeAsync(int id);

        Task<RoomTypeResponseDto> GetRoomTypeByIdAsync(int id);

        Task<List<RoomTypeResponseDto>> GetAllRoomTypesAsync();
    }
}
