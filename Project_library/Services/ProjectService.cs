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
                new Projectt {Id = 1, Name ="Test for Client 1" , ClientId = 1},
                new Projectt{Id = 2, Name ="Test2 for Client 2" , ClientId=2}
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

        public void Delete(int id)
        {
            var remove = Get(id);
            if (remove != null)
            {
                Projects.Remove(remove);
            }
        }

        public void Delete(Projectt pr)
        {
            Delete(pr.Id);
        }

        public IEnumerable<Projectt> Search(string query)
        {
            return Projects.Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(p => p.Id).Max() : 0;
            }
        }

        public void AddorUpdate(Projectt project)
        {
            if (project.Id == 0)
            {
                project.Id = LastId + 1;
                ProjectList.Add(project);
            }
        }

    }
}
