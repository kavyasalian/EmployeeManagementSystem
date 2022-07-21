using EmployeeManagement.Data;
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
        //public async Task<bool> Create(ProjectCreateModel project)
        //{
        //    try
        //    {
        //        _dbContext.Projects.Add(new Project
        //        {

        //            ProjectName = project.ProjectName,
        //            ProjectDesc = project.ProjectDesc,
        //            StartDate = project.StartDate,
        //            EndDate = project.EndDate,
        //         });
        //          await _dbContext.SaveChangesAsync();
        //          return true;
        //         }
        //         catch (Exception ex)
        //        {
        //        return false;
        //        }

        //}
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
    }
}
