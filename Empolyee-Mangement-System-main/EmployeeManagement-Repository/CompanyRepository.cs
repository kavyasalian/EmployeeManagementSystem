using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public CompanyRepository()
        {
            dbContext = new EmployeeManagementContext();
        }
        public async Task<Company> GetById(int Id)
        {
            var company = dbContext.Companies.FirstOrDefault(e => e.CompanyId == Id);
            return company;
        }

    }
}
