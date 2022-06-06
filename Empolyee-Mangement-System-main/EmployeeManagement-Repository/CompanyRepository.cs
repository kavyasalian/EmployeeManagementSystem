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
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task Create(Company company)
        {
            dbContext.Companies.Add(company);
            await dbContext.SaveChangesAsync();
        }

    }
}
