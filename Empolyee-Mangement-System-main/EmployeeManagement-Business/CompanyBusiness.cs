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
    public class CompanyBusiness
    {
        private readonly CompanyRepository companyRepository;
        public CompanyBusiness()
        {
            this.companyRepository = new CompanyRepository();
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(Company company)
        {
            await companyRepository.Create(company);
            return HttpStatusCode.OK;

        }

        public async Task<Company> GetCompanyAsync(int Id)
        {
            var company = await companyRepository.GetById(Id);
            return company;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await companyRepository.GetAllCompaniesAsync();
        }

        public async Task<HttpStatusCode> UpdateCompanyAsync(Company company)
        {
            var status = await companyRepository.Update(company);
            if (status)
            {
                await companyRepository.Create(company);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
        public async Task<HttpStatusCode> DeleteCompanyAsync(int CompanyId)
        {
            await companyRepository.Delete(CompanyId);
            return HttpStatusCode.OK;
        }
    }
}
