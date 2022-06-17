using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository.Entities
{
    public class RoleRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public RoleRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }
        public async Task Create(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

    }
}
