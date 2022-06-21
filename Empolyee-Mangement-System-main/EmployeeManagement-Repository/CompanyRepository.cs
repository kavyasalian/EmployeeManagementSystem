    using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;

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
            var effectedRow = _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();
            return ( effectedRow != null ) ? true:false;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return _dbContext.Companies.Include(a => a.CompanyId).ToList();
        }

        public async Task<Company> GetById(int Id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.CompanyId == Id);
            return company;
        }

        public async Task<bool> Update(Company company)
        {
            var existingCompany = _dbContext.Companies.Where(c => c.CompanyId == company.CompanyId).FirstOrDefault();
            if (existingCompany != null)
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
        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return _dbContext.Companies.ToList();
        }

    }
}

