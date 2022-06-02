using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public CompanyRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }
        public async Task<HttpStatusCode> Update(Company company)
        {
            var existingCompany = _dbContext.Companies.Where(a => a.Id == company.Id).FirstOrDefault();
            if( existingCompany != null)
            {
                existingCompany.OrgName = company.OrgName;
                existingCompany.DateCreated = company.DateCreated;
                existingCompany.DateModified = company.DateModified;
                existingCompany.IsDeleted = company.IsDeleted;
                await _dbContext.SaveChangesAsync();
                return HttpStatusCode.OK;   
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
