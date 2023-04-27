using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IRoleRepository
    {
        Task<int> AddRoleAsync(Role role);

        Task<Role> GetRoleByIdAsync(int id);

        Task<List<Role>> GetAllRolesAsync();

        Task<int> UpdateRoleAsync(Role role);

        Task<int> DeleteRoleAsync(Role role);
    }
}
