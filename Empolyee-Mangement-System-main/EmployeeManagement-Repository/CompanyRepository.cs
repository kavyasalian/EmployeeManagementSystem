using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public CompanyRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }

        public async Task<bool> Create(Company company)
        {
            _dbContext.Companies.Add(company);
            var effectedRows =  await _dbContext.SaveChangesAsync();
            return effectedRows > 0;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return _dbContext.Companies.ToList();
        }

        public async Task<Company> GetById(int Id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.CompanyId == Id);
            return company;
        }

        public async Task<bool> Update(Company company)
        {
            var existingCompany = _dbContext.Companies.Where(c => c.CompanyId == company.CompanyId).FirstOrDefault();
            if( existingCompany != null)
            {
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.CompanyPhone = company.CompanyPhone;
                existingCompany.CompanyAddress = company.CompanyAddress;
                var effectedRows = await _dbContext.SaveChangesAsync();
                return effectedRows > 0;   
            }
            return false;
        }

        public async Task<bool> Delete(int companyId)
        {
            var company = await GetById(companyId);
            if (company != null)
            {
                _dbContext.Companies.Remove(company);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
