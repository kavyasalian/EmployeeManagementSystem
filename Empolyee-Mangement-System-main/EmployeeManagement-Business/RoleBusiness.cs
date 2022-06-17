using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Business
{
    public class RoleBusiness
    {
        private readonly RoleRepository RoleRepository;
        public RoleBusiness()
        {
            this.RoleRepository = new RoleRepository();
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(Role role)
        {
            await RoleRepository.Create(role);
            return HttpStatusCode.OK;

        }
    }
}
