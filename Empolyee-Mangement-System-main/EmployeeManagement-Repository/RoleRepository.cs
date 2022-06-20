using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement_Repository.Entities;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository
{
    public class RoleRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public RoleRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task<bool> Create(RoleGetModel role)
        {
            try
            {
                dbContext.Roles.Add(new Role
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    DateCreated = role.DateCreated
                });

                await dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
              return false;
            }
        }
        public async Task<List<Role>> GetAllRolesAsync()
        {
            return dbContext.Roles.ToList();
        }

    }
}

