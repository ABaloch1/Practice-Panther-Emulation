using Project_library.Models;
using Project_library.Services;
using Project.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project.MAUI.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged 
    {
        public Projectt Model { get; set; }

        public ProjectViewModel()
        {
            Model = new Projectt();
            SetupCommands();
        }

        public ProjectViewModel(int clientId, int projectId)
        {
            //Model = new Projectt { ClientId = id };
            //SetupCommands();
            if (projectId > 0)
            {
                Model = ProjectService.Current.Get(projectId);
            }
            else
            {
                Model = new Projectt();
                Model.ClientId = clientId;
            }
            SetupCommands();
        }

        public ProjectViewModel(Projectt model)
        {
            Model = model;
            SetupCommands();
        }

        public ICommand AddorUpdateCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public void ExecuteDelete(int id)
        {
            ProjectService.Current.Delete(id);
        }

        public void ExecuteEdit(int projectId)
        {
            Shell.Current.GoToAsync($"//ProjectDetail?projectId={projectId}");
        }


        private void SetupCommands()
        {
            //AddCommand = new Command(ExecuteAdd);
            //TimerCommand = new Command(ExecuteTimer);
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ProjectViewModel).Model.Id));
            AddorUpdateCommand = new Command(
                (p) => ExecuteAddorUpdate());
            EditCommand = new Command(
                (p) => ExecuteEdit((p as ProjectViewModel).Model.Id));

        }
        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        public void ExecuteAddorUpdate()
        {
            ProjectService.Current.AddorUpdate(Model);
            //Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
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
    //change handler
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
}
