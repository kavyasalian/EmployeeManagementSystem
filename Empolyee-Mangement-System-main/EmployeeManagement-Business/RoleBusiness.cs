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

        public async Task<RoleGetByIdModel> GetRoleAsync(int Id)
        {
            var role = await RoleRepository.GetById(Id);
            var roleModel = new RoleGetByIdModel();

            if (role != null)
            {
                roleModel.RoleId = role.RoleId;
                roleModel.RoleName = role.RoleName;
                roleModel.DateCreated = role.DateCreated;
            }
            return roleModel;
        }
        public async Task<HttpStatusCode> DeleteRoleAsync(int Id)
        {
            await RoleRepository.Delete(Id);
            return HttpStatusCode.OK;
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
