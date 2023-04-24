using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public interface IRoleRepository
    {
        public int AddRole(Role role);

        public Role GetRoleById(int id);

        public List<Role> GetAllRoles();

        public int UpdateRole(Role role);

        public int DeleteRole(Role role);
    }
}
