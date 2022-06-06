using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Business
{
    internal class CompanyBusiness
    {
        public class CompanyBuisness
        {
            private readonly CompanyRepository companyRepository;

            public EmployeeRepository CompanyRepository { get; }
            public object CompanyId { get; }

            public CompanyBuisness()
            {
                this.companyRepository = new CompanyRepository();
            }
            public Task<List<Company>> GetAllComapnyAsync()
            {
                throw new NotImplementedException();
            }

            public Task GetCompanyAsync(int companyId)
            {
                throw new NotImplementedException();
            }

            public Task<HttpStatusCode> SaveCompanyAsync(company company)
            {
                throw new NotImplementedException();
            }

            public async Task<HttpStatusCode> UpdateCompanyAsync(company company)
            {
                await companyRepository.Update(company);
                return HttpStatusCode.OK;
            }

            public async Task<HttpStatusCode> DeleteCompanyAsync(int companyId)
            {
                await companyRepository.Delete(companyId);
                return HttpStatusCode.OK;
            }
        }
    }
}
