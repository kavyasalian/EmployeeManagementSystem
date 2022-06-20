using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class RoleBusiness
    {
        private readonly RoleRepository RoleRepository;
        public RoleBusiness()
        {
            this.RoleRepository = new RoleRepository();
        }

        public async Task<HttpStatusCode> UpdateRoleAsync(RoleViewModel roleView)
        {
            var role = new Role
            {
                RoleId = roleView.Id,
                RoleName = roleView.RoleName,
                DateCreated = roleView.DateCreated,
            };
            var status = await RoleRepository.Update(role);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
