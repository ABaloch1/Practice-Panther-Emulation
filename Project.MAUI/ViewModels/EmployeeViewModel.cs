using Project_library.Models;
using Project_library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.MAUI.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public Employee Model { get; set; }
        
        //public void AddorUpdate()
        //{
        //    EmployeeService.Current.AddorUpdate(Model);
        //}

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddorUpdateCommand { get; private set; }

        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={id}");
        }
        public void ExecuteAddorUpdate()
        {
            EmployeeService.Current.AddorUpdate(Model);
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (e) => ExecuteDelete((e as EmployeeViewModel).Model.Id));
            AddorUpdateCommand = new Command(
                (e) => ExecuteAddorUpdate());
            EditCommand = new Command(
                (e) => ExecuteEdit((e as EmployeeViewModel).Model.Id));
        }

        public EmployeeViewModel()
        {
            Model = new Employee();
            SetupCommands();
        }

        public EmployeeViewModel(Employee e)
        {
            Model = e;
            SetupCommands();
        }

        public EmployeeViewModel(int id)
        {
            if (id > 0)
            {
                Model = EmployeeService.Current.Get(id);
            }
            else
            {
                Model = new Employee();
            }
            SetupCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
