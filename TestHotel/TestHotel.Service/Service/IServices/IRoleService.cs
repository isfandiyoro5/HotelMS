using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IRoleService
    {
        Task<int> AddRoleAsync(Role role);

        Task<int> UpdateRoleAsync(Role role);

        Task<int> DeleteRoleAsync(int id);

        Task<Role> GetRoleByIdAsync(int id);

        Task<List<Role>> GetAllRolesAsync();
    }
}
