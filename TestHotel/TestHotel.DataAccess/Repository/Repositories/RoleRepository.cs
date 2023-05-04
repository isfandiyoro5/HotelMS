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
                _logger.LogInformation("Role muvaffaqiyatli qo'shildi");
                return role.RoleID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> DeleteRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Role muvaffaqiyatli o'chirildi");
                return role.RoleID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            try
            {
                return await _context.Roles
                    .Include(u => u.Employee)
                    .ToListAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
          
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("RoleById muvaffaqiyatli topildi");
                return await _context.Roles
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.RoleID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        public async Task<int> UpdateRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Role muvaffaqiyatli yangilandi");
                return role.RoleID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}
