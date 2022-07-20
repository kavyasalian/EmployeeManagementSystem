using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

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
        public async Task<HttpStatusCode> SaveProjectAsync(ProjectCreateModel project)
        {
            project.StartDate = DateTime.Now;
            project.EndDate = DateTime.Now;
            var status = await projectRepository.Create(project);

            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public Task SaveProjectAsync(ProjectGetModel project)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> UpdateProjectAsync(ProjectGetModel projectView)
        {
            var project = new Project
            {   ProjectId = projectView.ProjectId,
                ProjectName = projectView.ProjectName,
                ProjectDesc = projectView.ProjectDesc,
                StartDate = (DateTime)projectView.StartDate,
                EndDate = (DateTime)projectView.EndDate,
            };
            var status = await projectRepository.Update(project);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
