using Project_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.DTO
{
    public class ClientDTO
    {
        public ClientDTO()
        {
            Name = string.Empty;
            IsActive = true;
            Notes = string.Empty;
            OpenDate = DateTime.Today;
            ClosedDate = DateTime.Today;
            Projects = new List<Projectt>();
        }
        public ClientDTO(Client c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.Notes = c.Notes;
            this.IsActive = c.IsActive;
            this.OpenDate = c.OpenDate;
            this.ClosedDate = c.ClosedDate;
            this.Projects = c.Projects;
        }

        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<Projectt> Projects { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
