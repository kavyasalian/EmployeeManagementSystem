using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class RoleCreateModel
    {
        public String RoleName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
    }
}
