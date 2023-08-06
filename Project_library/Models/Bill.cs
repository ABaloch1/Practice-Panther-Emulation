using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Models
{
    public class Bill
    {
        public decimal TotalAmount { get; set; }

        public DateTime DueDate { get; set; }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public Bill()
        {
            TotalAmount = 0;
            DueDate = DateTime.Today;
        }


        public override string ToString()
        {
            return $"{Id}.  {TotalAmount}  {DueDate}";
        }
    }
}
