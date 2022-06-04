using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Business
{
    public class CompanyBuisness
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyBuisness()
        {
            this._companyRepository = new CompanyRepository();
        }

        public async Task<HttpStatusCode> AddCompanyAsync(Company company)
        {
            var status = await _companyRepository.Create(company);
            if(status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
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
