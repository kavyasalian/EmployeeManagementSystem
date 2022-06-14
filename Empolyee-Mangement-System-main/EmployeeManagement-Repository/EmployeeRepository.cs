using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository
{
    public class EmployeeRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public EmployeeRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }

        public async Task Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            var existingAmployee = dbContext.Employees.Where(h => h.Id == employee.Id).FirstOrDefault();
            if (existingAmployee != null)
            {
                existingAmployee.FirstName = employee.FirstName; // update only changeable properties
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetById(int Id)
        {
            var result = from employee in dbContext.Employees
                         from company in dbContext.Companies
                         where employee.Id == Id
                         orderby employee.FirstName descending
                         select new Employee
                         {
                             Id = employee.Id,
                             FirstName = employee.FirstName,
                             LastName = employee.LastName,
                             Gender = employee.Gender,
                             Email = employee.Email,
                             Phone = employee.Phone,
                             DateCreated = employee.DateCreated,
                             DateModified = employee.DateModified,
                             CompanyId = employee.CompanyId,
                             Company = employee.Company,
                         };
            return result.FirstOrDefault();
        }

        public async Task Delete(int employeeId)
        {
            var employee = await GetById(employeeId);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await this.dbContext.SaveChangesAsync();
            }
        }
        public List<Employee> GetAllEmployeesAsync()
        {
            var emp = (dbContext.Employees.Include(x => x.Company)).ToList();
            return emp;
        }
        public async Task<List<Employee>> FetchAllEmployeeByGenderAsync(String gender)
        {
            var result = from employee in dbContext.Employees.Where(a => a.Gender == gender)
                         from company in dbContext.Companies
                         where employee.CompanyId == company.CompanyId
                         orderby employee.FirstName
                         select new Employee
                         {
                             Id = employee.Id,
                             FirstName = employee.FirstName,
                             LastName = employee.LastName,
                             Gender = employee.Gender,
                             Email = employee.Email,
                             Phone = employee.Phone,
                             DateCreated = employee.DateCreated,
                             DateModified = employee.DateModified,
                             CompanyId = employee.CompanyId,
                             Company = employee.Company
                         };
            return result.ToList();
        }
    }
}