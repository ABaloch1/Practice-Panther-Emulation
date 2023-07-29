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
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }
        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (Model == null || Model.Id == 0) 
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                else
                {
                    return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Projects.
                        Where(p => p.ClientId == Model.Id).Select(x => new ProjectViewModel(x)));
                }
            }
        }

        //setting up constructor
        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();
        }

        public ClientViewModel(Client client) 
        { 
            Model = client; 
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            if (clientId > 0)
            {
                Model = ClientService.Current.Get(clientId);
            } 
            else
            {
                Model = new Client();
            }

            SetupCommands();
        }

        public void AddorUpdate()
        {
            ClientService.Current.AddorUpdate(Model);
        }

        //public void Add()
        //{
        //    ClientService.Current.Add(Model);
        //}

        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        //addcommand
        //list command??
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddProjectCommand { get; private set; }
        public ICommand ShowProjectCommand { get; private set; }

        //change handler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //execute commands
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }
        
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        public void ExecuteAddProject()
        {
            AddorUpdate();
            //finish
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");
        }
        public void ExecuteShowProject(int id)
        {
            Shell.Current.GoToAsync($"//Projects?clientId={id}");
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddProjectCommand = new Command(
                (c) => ExecuteAddProject());
            ShowProjectCommand = new Command(
                (c) => ExecuteShowProject((c as ClientViewModel).Model.Id));
        }
    }
}
