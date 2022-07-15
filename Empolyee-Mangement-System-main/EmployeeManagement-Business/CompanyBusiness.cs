using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class CompanyBusiness
    {
        private readonly CompanyRepository companyRepository;
        public CompanyBusiness()
        {
            this.companyRepository = new CompanyRepository();
        }

        public async Task<List<CompanyViewModel>> GetAllComapnyAsync()
        {
            var companies = await companyRepository.GetAllCompanyAsync();
            var comapnyList = new List<CompanyViewModel>();

            foreach (Company company in companies)
            {
                comapnyList.Add(new CompanyViewModel
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    CompanyAddress = company.CompanyAddress,
                    CompanyPhone = company.CompanyPhone
                });
            }
            return comapnyList;
        }

        public async Task<CompanyViewModel> GetCompanyByIdAsync(int Id)
        {
            var company = await companyRepository.GetById(Id);
            if (company != null)
            {
                var companyView = new CompanyViewModel
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    CompanyAddress = company.CompanyAddress,
                    CompanyPhone = company.CompanyPhone,
                };

                return companyView;
            }
            return null;
        }

        public async Task<HttpStatusCode> SaveCompanyAsync(CompanyCreateModel company)
        {
            var status = await companyRepository.Create(new Company
            {
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress,
                CompanyPhone = company.CompanyPhone,
            });

            return status ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> UpdateCompanyAsync(CompanyViewModel companyView)
        {
            var company = new Company
            {
                CompanyId = companyView.CompanyId,
                CompanyName = companyView.CompanyName,
                CompanyAddress = companyView.CompanyAddress,
                CompanyPhone = companyView.CompanyPhone,
            };
            var status = await companyRepository.Update(company);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> DeleteCompanyAsync(int CompanyId)
        {
            var status = await companyRepository.Delete(CompanyId);
            return status ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }

    }
}
