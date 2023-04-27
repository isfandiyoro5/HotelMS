using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HotelDbContext _context;

        public RoleRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return role.RoleID;
            }
            catch
            {
                throw new Exception("Role qo'shilmadi");
            }
        }

        public async Task<int> DeleteRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return role.RoleID;
            }
            catch
            {
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
                return await _context.Roles
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.RoleID == id);
            }
            catch
            {
                throw new Exception("Role ID topilmadi");
            }
        }

        public async Task<int> UpdateRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                return role.RoleID;
            }
            catch
            {
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
