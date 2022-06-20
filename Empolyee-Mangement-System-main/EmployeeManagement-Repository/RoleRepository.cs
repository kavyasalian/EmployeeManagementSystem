using EmployeeManagement_Repository.Entities;
namespace EmployeeManagement_Repository
{
    public class RoleRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public RoleRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }

        public async Task<bool> Update(Role role)
        {
            var existingRole = dbContext.Roles.FirstOrDefault(r => r.RoleId == role.RoleId);
            if(existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                existingRole.DateCreated = role.DateCreated;
                var effectedRows = await dbContext.SaveChangesAsync();
                return effectedRows > 0;
            }
            return false;
        }
    }
}
