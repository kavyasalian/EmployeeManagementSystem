using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;
using EmployeeManagement.Data;

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

        public async Task<List<EmployeeGetByIdModel>> GetEmployeeListAsync(int Id)
        {
            var employees = employeeRepository.GetEmployeeByIdAsync(Id);
            var employeeModel = new List<EmployeeGetByIdModel>();
            foreach (var employee in employees)
            {
                var emp = new EmployeeGetByIdModel();
                emp.Firstname = employee.FirstName;
                emp.Lastname = employee.LastName;
                emp.Gender = employee.Gender;
                emp.Email = employee.Email;
                emp.Phone = employee.Phone;
                employeeModel.Add(emp);
            }

            return employeeModel;

        }

        public Task<List<EmployeeGetByIdModel>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> SaveEmployeeAsync(Employee employee)
        {
            await employeeRepository.Create(employee);
            return HttpStatusCode.OK;
        }

        public async Task<List<EmployeeGetByIdModel>> FetchAllEmployeesAsync1(string gender)
        {
            var employees = employeeRepository.GetAllEmployeesAsync();
            var employeeModel = new List<EmployeeGetByIdModel>();
            foreach (var employee in employees)
            {
                var emp = new EmployeeGetByIdModel();
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Gender = employee.Gender;
                emp.Phone = employee.Phone;
                emp.Email = employee.Email;

                employeeModel.Add(emp);
            }
            return employeeModel;
        }

       
        private async Task<HttpStatusCode> DeleteEmployeeAsync1(int Id)
        {
            await employeeRepository.Delete(Id);
            return HttpStatusCode.OK;
        }

        private async Task<HttpStatusCode> UpdateEmployeeAsync1(Employee employee)
        {
            await employeeRepository.Update(employee);
            return HttpStatusCode.OK;

        }

        private async Task<HttpStatusCode> SaveEmployeeAsync1(EmployeeCreateModel employee)
        {
            var status = await employeeRepository.Create(employee);


            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public Task FetchAllEmployeesAsync(string gender)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> SaveEmployeeAsync(EmployeeCreateModel employee)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}