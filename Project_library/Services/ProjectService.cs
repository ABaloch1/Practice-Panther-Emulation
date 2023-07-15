using Project_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Services
{
    public class ProjectService
    {
        private List<Project> ProjectList;
        public List<Project> Projects
        {
            get
            { return ProjectList; }
        }

        private ProjectService()
        {
            ProjectList = new List<Project>();
        }

        private Project? Get(int Id)
        {
            return Projects.FirstOrDefault(p => p.Id == Id);
        }

        private static ProjectService? instance;
        public static ProjectService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }
                return instance;
            }
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(p => p.Id).Max() : 0;
            }
        }

        public void Add(Project project)
        {
            if (project.Id == 0)
            {
                project.Id = LastId + 1;
            }
            ProjectList.Add(project);
        }

    }
}
