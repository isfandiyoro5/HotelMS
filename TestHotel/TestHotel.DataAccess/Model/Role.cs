using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.DataAccess.Model
{
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleTitle { get; set; }
        
        public string RoleDescription { get; set; }


        public List<Employee> Employee { get; set; }
    }
}
