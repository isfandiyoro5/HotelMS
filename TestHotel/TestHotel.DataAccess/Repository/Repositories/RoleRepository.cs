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
            catch
            {
                _logger.LogError("Roleni yaratishda xatolik yuzaga keldi");
                throw new Exception("Role qo'shilmadi");
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
            catch
            {
                _logger.LogError("Roleni o'chirishda xatolik yuzaga keldi");
                throw new Exception("Role o'chirilmadi");
            }
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            var allRolesExist = await _context.Roles
            .Include(u => u.Employee)
            .ToListAsync();
            if (allRolesExist is not null)
            {
                return allRolesExist;
            }
            else
            {
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
            catch
            {
                _logger.LogError("RoleByIdni qidirishda xatolik yuzaga keldi");
                throw new Exception("Role ID topilmadi");
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
            catch
            {
                _logger.LogError("Roleni yangilashda xatolik yuzaga keldi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
