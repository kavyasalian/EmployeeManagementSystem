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

        public async Task<EmployeeGetByIdModel> GetEmployeeAsync(int Id)
        {
            var employee = await employeeRepository.GetById(Id);
            var employeeModel = new EmployeeGetByIdModel();


            if (employee != null)
            {
                employeeModel.FirstName = employee.FirstName;
                employeeModel.LastName = employee.LastName;
                employeeModel.Gender = employee.Gender;
                employeeModel.Email = employee.Email;
                employeeModel.Phone = employee.Phone;
            }
            return employeeModel;

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

        public async Task<List<EmployeeFilterModel>> FetchAllEmployeesAsync(String gender)
        {
            var employees = employeeRepository.GetAllEmployeesAsync(gender);
            var emp = new EmployeeFilterModel();
            var employeesModel = new List<EmployeeFilterModel>();
            foreach (var employee in employees)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Gender = employee.Gender;
                emp.Email = employee.Email;
                emp.companyName = employee.Company.CompanyName;
                emp.companyAddress = employee.Company.CompanyAddress;

                employeesModel.Add(emp);
            }
            return employeesModel;
        }
    }
}