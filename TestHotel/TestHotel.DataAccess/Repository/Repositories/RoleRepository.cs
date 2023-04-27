using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ILogger<RoleRepository> _logger;
        private readonly HotelDbContext _context;

        public RoleRepository(HotelDbContext context, ILogger<RoleRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                _logger.LogInformation("AddRoleAsync() Chaqirildi");
                return role.RoleID;
            }
            catch
            {
                _logger.LogError("AddRoleAsync() Qo'shilmadi");
                throw new Exception("Role qo'shilmadi");
            }
        }

        public async Task<int> DeleteRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteRoleAsync() Chaqirildi");
                return role.RoleID;
            }
            catch
            {
                _logger.LogError("DeleteRoleAsync() O'chirilmadi");
                throw new Exception("Role o'chirilmadi");
            }
        }

        public async Task<List<Role>> GetAllRolesAsync() => await _context.Roles
            .Include(u => u.Employee)
            .ToListAsync();

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetRoleByIdAsync() Chaqirildi");
                return await _context.Roles
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.RoleID == id);
            }
            catch
            {
                _logger.LogError("GetRoleByIdAsync() Topilmadi");
                throw new Exception("Role ID topilmadi");
            }
        }

        public async Task<int> UpdateRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateRoleAsync() Chaqirildi");
                return role.RoleID;
            }
            catch
            {
                _logger.LogError("UpdateRoleAsync() O'zgartirilmadi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
