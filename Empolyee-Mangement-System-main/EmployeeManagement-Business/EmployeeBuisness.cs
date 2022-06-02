using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class EmployeeBuisness
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeBuisness()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            var alumnus = await employeeRepository.GetById(Id);
            return alumnus;

        }
        public async Task<HttpStatusCode> SaveEmployeeAsync(Employee employee)
        {
             await employeeRepository.Create(employee);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> UpdateEmployeeAsync(Employee employee)
        {
            await employeeRepository.Update(employee);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteEmployeeAsync(int Id)
        {
             await employeeRepository.Delete(Id);
            return HttpStatusCode.OK;
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await employeeRepository.GetAllEmployeesAsync();
        }
    }
}