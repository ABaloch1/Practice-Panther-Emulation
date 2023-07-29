using Project_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Services
{
    public class EmployeeService
    {
        public static EmployeeService? intstance;
        public static EmployeeService Current
        {
            get
            {
                if (intstance == null)
                {
                    intstance = new EmployeeService();
                }
                return intstance;
            }
        }

        private List<Employee> employeelist;
        public List<Employee> getemployeeList
        {
            get
            {
                return employeelist;
            }
        }

        private EmployeeService()
        {
            employeelist = new List<Employee>
            {
                new Employee { Id = 1, Name = "Sorgalim", Rate = 100 }

            };
        }

        public Employee? Get(int id)
        { 
            return getemployeeList.FirstOrDefault(e => e.Id == id);
        }

        private int LastId
        {
            get
            {
                return getemployeeList.Any() ? getemployeeList.Select(e => e.Id).Max() : 0;
            }
        }

        public void AddorUpdate(Employee employee)
        {
            if(employee.Id == 0)
            {
                employee.Id = LastId + 1;
                getemployeeList.Add(employee);
            }
        }

        public IEnumerable<Employee> Search(string query)
        {
            return getemployeeList.Where(e => e.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void Delete(int id)
        {
            var remove = Get(id);
            if (remove != null)
            {
                getemployeeList.Remove(remove);
            }
        }

        public void Delete(Employee e)
        {
            Delete(e.Id);
        }
    }
}
