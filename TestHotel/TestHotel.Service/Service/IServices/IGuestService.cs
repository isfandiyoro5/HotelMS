using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.Service.IServices
{
    public interface IGuestService
    {
        Task<int> AddGuestAsync(GuestRequestDto guestRequestDto);

        Task<int> UpdateGuestAsync(int id, GuestRequestDto guestRequestDto);

        Task<int> DeleteGuestAsync(int id);

        Task<GuestResponseDto> GetGuestByIdAsync(int id);

        Task<List<GuestResponseDto>> GetAllGuestsAsync();
    }
}
