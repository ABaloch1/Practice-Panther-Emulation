using Project_library.Models;
using Project_library.Services;
using Project.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public Projectt Model { get; set; }

        public ProjectViewModel()
        {
            Model = new Projectt();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {
            Model = new Projectt { ClientId = clientId };
            SetupCommands();
        }

        public ProjectViewModel(Projectt model)
        {
            Model = model;
            SetupCommands();
        }

        public ICommand AddCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }


        public void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
        }
        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.Add(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }

        private void ExecuteTimer()
        {
            ////copied from git
            //var window = new Window()
            //{
            //    Width = 250,
            //    Height = 350,
            //    X = 0,
            //    Y = 0
            //};
            //var view = new TimerView(Model.Id, window);
            //window.Page = view;
            //Application.Current.OpenWindow(window);
        }

        
    }
}
