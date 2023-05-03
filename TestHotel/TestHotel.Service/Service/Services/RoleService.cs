using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            return await _roleRepository.AddRoleAsync(role);
        }

        public async Task<int> DeleteRoleAsync(int id)
        {
            var roleExist = await GetRoleByIdAsync(id);
            if (roleExist != null)
            {
                return await _roleRepository.DeleteRoleAsync(roleExist);
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetRoleByIdAsync(id);
        }

        public async Task<int> UpdateRoleAsync(Role role)
        {
            var roleExist = await GetRoleByIdAsync(role.RoleId);
            if (roleExist != null)
            {
                return await _roleRepository.UpdateRoleAsync(roleExist);
            }
            else
            {
                return 0;
            }
        }
    }
}
