using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class CompanyBuisness
    {
        private readonly CompanyRepository CompanyRepository;
        public CompanyBuisness()
        {
            this.CompanyRepository = new CompanyRepository();
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(Company company)
        {
            await CompanyRepository.Create(company);
            return HttpStatusCode.OK;

        }
    }
}
