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
            var roleResult = await GetRoleByIdAsync(id);
            if (roleResult is not null)
            {
                return await _roleRepository.DeleteRoleAsync(roleResult);
            }
            else
            {
                throw new Exception("Delete uchun Role mavjud emas");
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

        public async Task<int> UpdateRoleAsync(int id)
        {
            var roleResult = await GetRoleByIdAsync(id);
            if (roleResult is not null)
            {
                return await _roleRepository.UpdateRoleAsync(roleResult);
            }
            else
            {
                throw new Exception("Update uchun Role mavjud emas");
            }
        }
    }
}
