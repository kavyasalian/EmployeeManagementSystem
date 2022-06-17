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
        public async Task<HttpStatusCode> SaveEmployeeAsync(EmployeeCreateModel employee)
        {
            var status = await employeeRepository.Create(employee);

            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
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
        public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync()
        {
            var employees = employeeRepository.GetAllEmployeesAsync();

            var employeeModel = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                var emp = new EmployeeViewModel();
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Gender = employee.Gender;
                emp.Phone = employee.Phone;
                emp.Email = employee.Email;
                emp.CompanyName = employee.Company.CompanyName;
                emp.CompanyAddress = employee.Company.CompanyAddress;
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