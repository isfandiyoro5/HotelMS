using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HotelDbContext _context;

        public RoleRepository(HotelDbContext context)
        {
            _context = context;
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleID;
        }

        public int DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return role.RoleID;
        }

        public List<Role> GetAllRoles() => _context.Roles
            .Include(u => u.Employee).ToList();

        public Role GetRoleById(int id) => _context.Roles
            .Include(u => u.Employee).FirstOrDefault(u => u.RoleID == id);

        public int UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role.RoleID;
        }
    }
}
