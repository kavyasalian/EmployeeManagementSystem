using EmployeeManagement_Repository.Entities;

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

        public async Task<bool> Create(Project project)
        {
            var effectedRow = _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return (effectedRow != null) ? true : false;
        }

        public async Task<bool> Update(Project project)
        {
            var existingProject = _dbContext.Projects.Where(c => c.ProjectId == project.ProjectId).FirstOrDefault();
            if (existingProject != null)
            {
                existingProject.ProjectName = project.ProjectName;
                existingProject.ProjectDesc = project.ProjectDesc;
                existingProject.StartDate = project.StartDate;
                existingProject.EndDate = project.EndDate;
                var effectedRows = await _dbContext.SaveChangesAsync();
                return effectedRows > 0;
            }
            return false;
        }

        public async Task<Project> GetById(int Id)
        {
            var project = _dbContext.Projects.FirstOrDefault(c => c.ProjectId == Id);
            return project;
        }

        public async Task<bool> Delete(int companyId)
        {
            var project = await GetById(companyId);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
