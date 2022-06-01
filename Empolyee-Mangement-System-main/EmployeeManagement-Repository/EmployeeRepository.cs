using EmployeeManagement_Web;

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
            var employee = dbContext.Employees.FirstOrDefault(e => e.Id == Id);
            return employee;
        }

        public async Task Delete(int employeeId)
        {
            var employee = await GetById(employeeId);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
            }
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return dbContext.Employees.ToList();
        }
    }
}