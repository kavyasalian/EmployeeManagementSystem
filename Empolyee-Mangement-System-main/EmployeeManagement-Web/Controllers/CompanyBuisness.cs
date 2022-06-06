using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    public class CompanyBuisness
    {
        private readonly CompanyRepository companyRepository;

        public EmployeeRepository CompanyRepository { get; }

        public CompanyBuisness()
        {
            this.companyRepository = new CompanyRepository();
        }
        public async Task<List<company>> GetAllComapnyAsync()
        {
            return await companyRepository.GetAllCompanyAsync();
        }

        public async Task<company> GetCompanyAsync(int companyId)
        {
            var company = await companyRepository.GetById(companyId);
            return company;
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