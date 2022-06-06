using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Business
{
    public class CompanyBusiness
    {
        private readonly CompanyRepository companyRepository;
        public CompanyBusiness()
        {
            companyRepository = new CompanyRepository();
        }
        public async Task<Company> GetCompanyAsync(int Id)

        {
            var alumnus = await companyRepository.GetById(Id);
            return alumnus;

        }
    }
}

