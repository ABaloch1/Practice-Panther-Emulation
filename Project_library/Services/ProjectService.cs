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
        private List<Projectt> ProjectList;
        public List<Projectt> Projects
        {
            get
            { return ProjectList; }
        }

        private ProjectService()
        {
            ProjectList = new List<Projectt>
            {
                new Projectt {Id = 1, Name ="Test" , ClientId = 1}
            };
        }

        public Projectt? Get(int Id)
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

        public void Add(Projectt project)
        {
            if (project.Id == 0)
            {
                project.Id = LastId + 1;
            }
            ProjectList.Add(project);
        }

    }
}
