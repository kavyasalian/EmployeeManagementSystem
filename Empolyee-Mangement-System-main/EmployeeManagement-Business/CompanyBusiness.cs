using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class CompanyBusiness
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyBusiness()
        {
            this._companyRepository = new CompanyRepository();
        }

        public async Task<HttpStatusCode> SaveCompanyAsync(Company company)
        {
            await _companyRepository.Create(company);
            return HttpStatusCode.OK;

        }

        public async Task<Company> GetCompanyAsync(int Id)
        {
            var company = await _companyRepository.GetById(Id);
            return company;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }

        public async Task<HttpStatusCode> UpdateCompanyAsync(Company company)
        {
            var status = await _companyRepository.Update(company);
            if (status)
        {
            await _companyRepository.Create(company);
            return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> DeleteCompanyAsync(int Id)
        {
            var status = await _companyRepository.Delete(Id);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
