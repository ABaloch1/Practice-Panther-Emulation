using Project_library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAUI.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {
        public Bill Model { get; set; }

        public BillViewModel()
        {
            Model = new Bill();
        }

        //private Employee emp;
        //public Employee Employee
        //{
        //    get
        //    {
        //        return emp;
        //    }
        //    set
        //    {
        //        emp = value;
        //        if (emp != null)
        //        {
        //            Model.EmployeeId = emp.Id;
        //        }
        //    }
        //}

        public BillViewModel(decimal amount)
        {
            Model = new Bill() { TotalAmount = amount };
        }





        //notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
