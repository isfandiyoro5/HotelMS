using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    internal class Role
    {
        public int RoleID { get; set; }
        
        public string RoleTitle { get; set; }
        
        public string RoleDescription { get; set; }


        public List<Employee> Employee { get; set; }
    }
}
