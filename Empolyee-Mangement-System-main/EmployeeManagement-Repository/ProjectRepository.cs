using EmployeeManagement.Data;
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
        public async Task<bool> Create(ProjectCreateModel project)
        {
            try
            {
                _dbContext.Projects.Add(new Project
                {
                    
                    ProjectName=project.ProjectName,
                    ProjectDesc=project.ProjectDesc,
                    StartDate= (DateTime)project.StartDate,
                    EndDate= (DateTime)project.EndDate,

                  
                    
                });

                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

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
    }
}
