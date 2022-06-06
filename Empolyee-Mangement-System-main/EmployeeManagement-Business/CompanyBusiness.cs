using EmployeeManagement_Repository;
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
        public async Task<HttpStatusCode> DeleteCompanyAsync(int CompanyId)
        {
            await companyRepository.Delete(CompanyId);
            return HttpStatusCode.OK;
        }
    }
}
