using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public CompanyRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }

        public async Task Create(company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();
        }
       
       public async Task Update(company company)
       {
           var existingAmployee = _dbContext.Companies.Where(h => h.CompanyId == company.CompanyId).FirstOrDefault();
          if (existingAmployee != null)
          {
               existingAmployee.CompanyName = company.CompanyName; // update only changeable properties
               await this._dbContext.SaveChangesAsync();
            }
        }
        public async Task<company> GetById(int Id)
        {
            var company = _dbContext.Companies.FirstOrDefault(e => e.CompanyId == Id);
            return company;
        }
        public async Task Delete(int CompanyId)
        {
            var company = await GetById(CompanyId);
            if (company != null)
            {
                _dbContext.Companies.Remove(company);
                await this._dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<company>> GetAllCompanyAsync()
        {
            return _dbContext.Companies.ToList();
        }

    }
}
