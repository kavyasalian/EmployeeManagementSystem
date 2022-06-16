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
        public async Task<List<EmployeeViewModel>> GetEmployeeListAsync(int Id)
        {
            var employees =employeeRepository.GetEmployeeByIdAsync(Id);
            var employeeModel = new List<EmployeeViewModel>();
            foreach(var employee in employees)
            {
                var emp = new EmployeeViewModel();
                emp.Firstname = employee.FirstName;
                emp.Lastname = employee.LastName;
                emp.Gender = employee.Gender;
                emp.Email = employee.Email;
                emp.Phone = employee.Phone;
                employeeModel.Add(emp);
            }

            return employeeModel;

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

        public async Task<List<Employee>> FetchAllEmployeesAsync(String gender)
        {
            return await employeeRepository.FetchAllEmployeeByGenderAsync(gender);
        }
    }
}