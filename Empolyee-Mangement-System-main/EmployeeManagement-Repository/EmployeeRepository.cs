﻿using EmployeeManagement.Data;
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

        public async Task<bool> Create(EmployeeCreateModel employee)
        {
            try
            {
                dbContext.Employees.Add( new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    DateCreated = employee.DateCreated,
                    DateModified = employee.DateModified,
                    CompanyId = employee.CompanyId,
                });

                await dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Update(UpdateModelView employee)
        {

            var existingEmployee = dbContext.Employees.Where(a => a.Id == employee.Id).FirstOrDefault();
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Phone = employee.Phone;
                existingEmployee.DateCreated = employee.DateCreated;
                existingEmployee.DateCreated = employee.DateCreated;
                existingEmployee.DateModified = employee.DateModified;
                existingEmployee.CompanyId = employee.CompanyId;
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Employee> GetById(int Id)
        {
            return dbContext.Employees.FirstOrDefault(x => x.Id == Id);
        }
        public List<Employee> GetAllEmployeesAsync(string gender)

        {
            var employees = dbContext.Employees.Where(h => h.Gender == gender).Include(a => a.Company).ToList();
            return employees;
        }

        public List<Employee> GetAllEmployees()

        {
            var employees = dbContext.Employees.Include(a => a.Company).ToList();
            return employees;
        }
        public async Task Delete(int employeeId)
        {
            var employee = await GetById(employeeId);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                this.dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Employee>> GetAllEmployeesListAsync()
        {
            return  dbContext.Employees.Include(x=>x.Company).ToList();
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
        public Employee SearchByName(string employeeName)
        {
            return dbContext.Employees.Include(x => x.Company).FirstOrDefault(a => a.FirstName == employeeName);
        }

    }

}



