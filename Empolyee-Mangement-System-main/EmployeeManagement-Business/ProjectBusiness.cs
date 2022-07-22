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
            var status = await projectRepository.Create(new Project
            {
                ProjectName = project.ProjectName,
                ProjectDesc = project.ProjectDesc,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
            });

            return status ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> UpdateProjectAsync(ProjectGetModel projectView)
        {
            var project = new Project
            {
                ProjectId = projectView.ProjectId,
                ProjectName = projectView.ProjectName,
                ProjectDesc = projectView.ProjectDesc,
                StartDate= projectView.StartDate,
                EndDate= projectView.EndDate,
                

            };
            var status = await projectRepository.Update(project);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> DeleteProjectAsync(int ProjectId)
        {
            var status = await projectRepository.Delete(ProjectId);
            return status ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }
    }
}
