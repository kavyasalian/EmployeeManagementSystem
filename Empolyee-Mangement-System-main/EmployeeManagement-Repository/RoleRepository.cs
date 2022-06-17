using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement_Repository.Entities;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class RoleRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public RoleRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
    }
}
