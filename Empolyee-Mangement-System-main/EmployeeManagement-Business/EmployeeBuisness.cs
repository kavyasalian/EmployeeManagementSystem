using EmployeeManagement.Data;
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
            var employee = await employeeRepository.GetById(Id);
            return employee;

        }
        public async Task<HttpStatusCode> SaveEmployeeAsync(Employee employee)
        {
            await employeeRepository.Create(employee);
            return HttpStatusCode.OK;
        }
        public async Task<HttpStatusCode> UpdateEmployeeAsync(UpdateModelView employee)
        {
            await employeeRepository.Update(employee);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteEmployeeAsync(int Id)
        {
            await employeeRepository.Delete(Id);
            return HttpStatusCode.OK;
        }
        public async Task<List<EmployeeGetModel>> GetAllEmployeesByIdAsync(int CompanyId)
        {
            var employees = employeeRepository.GetAllEmployeesListAsync(CompanyId);
            var employeeModel = new List<EmployeeGetModel>();
            foreach (var employee in employees)
            {
                var emp = new EmployeeGetModel();
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                employeeModel.Add(emp);

            }
            return employeeModel;
        }
        public async Task<List<Employee>> FetchAllEmployeesAsync(String gender)
        {
            return await employeeRepository.FetchAllEmployeeByGenderAsync(gender);
        }
    }
}


