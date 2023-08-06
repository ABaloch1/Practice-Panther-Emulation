using Project_library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Models
{
    public class Client
    {
       
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<Projectt> Projects { get; set; }
        
        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public Client()
        {
            Name = string.Empty;
            Projects = new List<Projectt>();
        }

        public Client(ClientDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Notes = dto.Notes;
            this.IsActive = dto.IsActive;
            this.OpenDate = dto.OpenDate;
            this.ClosedDate = dto.ClosedDate;
            this.Projects = dto.Projects;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Id}. {Name}";
        }

        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
        public string Property7 { get; set; }
        public string Property8 { get; set; }
        public string Property9 { get; set; }
        public string Property10 { get; set; }
        //after empl get first or default emp.rate * hours
    }
}
