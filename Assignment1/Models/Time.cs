using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Time
    {
        public DateOnly Date { get; set; } 
        public string Narrative { get; set; }
        public TimeOnly TimeOnly { get; set; }


        //this might replace dateonly and timeonly
        public DateTime DateTime { get; set; }

        public int ProjectId { get; set; }
        public int EmpoyeeId { get; set; }
    }
}
