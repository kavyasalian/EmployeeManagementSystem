using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository
{
    public class ProjectRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public ProjectRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            return _dbContext.Projects.ToList();
        }
    }
}
