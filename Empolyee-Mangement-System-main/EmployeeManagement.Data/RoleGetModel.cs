using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class RoleGetModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
