using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Business
{
    public class ProjectBusiness
    {
        private readonly ProjectRepository projectRepository;
        public ProjectBusiness()
        {
            this.projectRepository = new ProjectRepository();
        }

        public async Task<List<ProjectGetModel>> GetAllProjectAsync()
        {
            var projects = await projectRepository.GetAllProjectAsync();
            var projectList = new List<ProjectGetModel>();

            foreach (Project project in projects)
            {
                projectList.Add(new ProjectGetModel
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectDesc = project.ProjectDesc,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                });
            }
            return projectList;
        }
    }
}
