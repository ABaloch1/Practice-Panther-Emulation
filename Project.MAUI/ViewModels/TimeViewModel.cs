using Project_library.Models;
using Project_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAUI.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; set; }

        private Employee emp;
        public Employee Employee
        {
            get
            {
                return emp;
            }
            set
            {
                emp = value;
                if (emp != null)
                {
                    Model.EmployeeId = emp.Id;
                }               
            }
        }
        public string EmpDisplay => Employee?.Name ?? string.Empty;
        private Projectt proj;
        public Projectt Project
        {
            get
            {
                return proj;
            }
            set
            {
                proj = value;
                if (proj != null)
                {
                    Model.ProjectId = proj.Id;
                }
            }
        }
        public string ProjDisplay => Project?.Name ?? string.Empty;
        
        public string HourDisplay
        {
            get
            {
                return Model.Hours.ToString();
            }
            set
            {
                if(decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        public TimeViewModel()
        {
            Model = new Time();
        }

        public ObservableCollection<Employee> getemployeeList
        {
            get
            {
                return new ObservableCollection<Employee>(EmployeeService.Current.getemployeeList);
            }
        }

        public ObservableCollection<Projectt> Projects
        {
            get
            {
                return new ObservableCollection<Projectt>(ProjectService.Current.Projects);
            }
        }

        public TimeViewModel(Time time)
        {
            Model = time;
            var emp = EmployeeService.Current.Get(time.EmployeeId);
            if (emp != null)
            {
                Employee = emp;
            }
            var proj = ProjectService.Current.Get(time.ProjectId);
            if (proj != null)
            {
                Project = proj;
            }

        }

        public void AddorUpdate()
        {
            TimeService.Current.AddOrUpdate(Model);
        }

        //notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
