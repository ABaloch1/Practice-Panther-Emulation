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
using System.Windows.Input;

namespace Project.MAUI.ViewModels
{
    class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public Employee SelectedEmployee { get; set; }
        public ICommand SearchCommand { get; set; }
        public string Query { get; set; }

        //public EmployeeViewViewModel()
        //{
        //    SearchCommand = new Command(ExecuteSearchCommand)
        //}

        public ObservableCollection<EmployeeViewModel> getemployeeList
        {
            get
            {
                return
                    new ObservableCollection<EmployeeViewModel>
                    (EmployeeService.Current.Search(Query ?? string.Empty).Select(e => new EmployeeViewModel(e)).ToList());
            }
        }

        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(getemployeeList));
        }

        //notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if(SelectedEmployee != null)
            {
                EmployeeService.Current.Delete(SelectedEmployee.Id);
                SelectedEmployee = null;
                NotifyPropertyChanged(nameof(getemployeeList));
                NotifyPropertyChanged(nameof(SelectedEmployee));
            }
        }
    }
}

//move on to detail view and view
