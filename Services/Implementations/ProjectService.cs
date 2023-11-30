﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TODOLIST.Data.Entities;
using TODOLIST.DBContext;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ToDoContext _context;

        public ProjectService(ToDoContext context)
        {
            _context = context;
        }

        public List<Project> GetAllProjects()
        {
            return _context.Project.ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Project.Find(projectId);
        }
        
        public Project CreateProject(Project project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();
            return project;
        }

        public Project UpdateProject(int projectId, Project updatedProject)
        {
            var existingProject =_context.Project.Find(projectId);
            if (existingProject == null) 
            {
                return null;
            }
            existingProject.Name = updatedProject.Name;
            existingProject.StartDate = updatedProject.StartDate;
            existingProject.EndDate = updatedProject.EndDate;
            existingProject.Description = updatedProject.Description;
            
            _context.SaveChanges();
            return existingProject;
        }

        public void DeleteProject(int projectId)
        {
            var project = _context.Project.Find(projectId);
            if (project != null)
            {
                _context.Project.Remove(project);
                _context.SaveChanges();
            }
        }
    }
}
