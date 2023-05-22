using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IRoleService
    {
        Task<int> AddRoleAsync(Role role);

        Task<int> UpdateRoleAsync(int id);

        Task<int> DeleteRoleAsync(int id);

        Task<Role> GetRoleByIdAsync(int id);

        Task<List<Role>> GetAllRolesAsync();
    }
}
