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
        public async Task<Role> GetById(int Id)
        {
            return dbContext.Roles.FirstOrDefault(a => a.RoleId == Id);
        }
        public async Task Delete(int roleId)
        {
            var role = await GetById(roleId);
            if (role != null)
            {
                dbContext.Roles.Remove(role);
                this.dbContext.SaveChangesAsync();
            }
        }
    }
}
