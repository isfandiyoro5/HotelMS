using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddRole(RoleRequestDto roleRequestDto)
        {
            return await _roleService.AddRoleAsync(roleRequestDto);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<RoleResponseDto>> GetRoleById(int id)
        {
            return await _roleService.GetRoleByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleResponseDto>>> GetAllRoles()
        {
            return await _roleService.GetAllRolesAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateRole(int id, RoleRequestDto roleRequestDto)
        {
            return await _roleService.UpdateRoleAsync(id, roleRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteRole(int id)
        {
            return await _roleService.DeleteRoleAsync(id);
        }
    }
}
