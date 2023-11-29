using System.Collections.Generic;
using TODOLIST.Data.Entities;

namespace TODOLIST.Services.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int projectId);
        int CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
    }
}
