using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository;

namespace EmployeeManagement_Business
{
    public class RoleBusiness
    {
     private readonly RoleRepository roleRepository;
        public RoleBusiness()
        {
            roleRepository = new RoleRepository();  
        }
    }
}
