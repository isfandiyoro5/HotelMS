using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpPost]
        public async Task<int> CreateRoleAsync(Role role)
        {
            return await _roleRepository.AddRoleAsync(role);
        }

        [HttpGet("id")]
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetRoleByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        [HttpPut]
        public async Task<int> UpdateRoleAsync(Role role)
        {
            return await _roleRepository.UpdateRoleAsync(role);
        }

        [HttpDelete]
        public async Task<int> DeleteRoleAsync(Role role)
        {
            return await _roleRepository.DeleteRoleAsync(role);
        }
    }
}
