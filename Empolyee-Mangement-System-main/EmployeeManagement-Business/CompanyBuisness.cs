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

        public async Task<HttpStatusCode> UpdateCompanyAsync(Company company)
        {
            var status = await _companyRepository.Update(company);
            return status;
        }
    }
}
