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

        public override string ToString()
        {
            //return base.ToString();
            return $"{Id} {Name} ";
        }
        
        //after empl get first or default emp.rate * hours
    }
}
