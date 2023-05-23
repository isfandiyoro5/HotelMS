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
    public interface IHotelService
    {
        Task<int> AddHotelAsync(HotelRequestDto hotelRequestDto);

        Task<int> UpdateHotelAsync(int id, HotelRequestDto hotelRequestDto);

        Task<int> DeleteHotelAsync(int id);

        Task<HotelResponseDto> GetHotelByIdAsync(int id);

        Task<List<HotelResponseDto>> GetAllHotelsAsync();
    }
}
