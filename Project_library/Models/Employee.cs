using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public decimal Rate { get; set; }
        public int Id { get; set; }

        //public override string ToString() => Name ?? string.Empty;

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public Employee()
        {
            Name = string.Empty;

        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }

    }
}
