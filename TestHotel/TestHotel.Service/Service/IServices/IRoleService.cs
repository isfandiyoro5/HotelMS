using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.Service.IServices
{
    public interface IRoleService
    {
        Task<int> AddRoleAsync(RoleRequestDto roleRequestDto);

        Task<int> UpdateRoleAsync(int id, RoleRequestDto roleRequestDto);

        Task<int> DeleteRoleAsync(int id);

        Task<RoleResponseDto> GetRoleByIdAsync(int id);

        Task<List<RoleResponseDto>> GetAllRolesAsync();
    }
}
