using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHotel.Service.DTO.RequestDto
{
    public class RoleRequestDto
    {
        public string RoleTitle { get; set; }

        public string RoleDescription { get; set; }
    }
}
