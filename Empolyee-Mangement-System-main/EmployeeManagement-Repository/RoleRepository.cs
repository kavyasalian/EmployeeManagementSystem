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

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return dbContext.Roles.ToList();
        }

        public async Task<Role> GetById(int Id)
        {
            return dbContext.Roles.FirstOrDefault(a => a.RoleId == Id);
        }

        public async Task<bool> Create(Role role)
        {
            try
            {
                _ = dbContext.Roles.Add(new Role
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

        public async Task<bool> Update(Role role)
        {
            var existingRole = dbContext.Roles.FirstOrDefault(r => r.RoleId == role.RoleId);
            if (existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                existingRole.DateCreated = role.DateCreated;
                var effectedRows = await dbContext.SaveChangesAsync();
                return effectedRows > 0;
            }
            return false;
        }

        public async Task<bool> Delete(int roleId)
        {
            var role = await GetById(roleId);
            if (role != null)
            {
                dbContext.Roles.Remove(role);
                this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}

