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
        //finish
        //public ObservableCollection<ProjectViewModel> Projects
        //{
        //}

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

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }
        //exucute commands

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
        }






        //public Client SelectedClient { get; set;}

        //    public ObservableCollection<Client> Clients {
        //        get
        //        {
        //            return new ObservableCollection<Client>(ClientService.Current.getclientList);
        //    }
        //}



        //public void Delete()
        //{
        //    if (SelectedClient != null)
        //    {
        //        ClientService.Current.Delete(SelectedClient.Id);
        //        SelectedClient = null;
        //        NotifyPropertyChanged(nameof(Clients));
        //        NotifyPropertyChanged(nameof(SelectedClient));
        //    }
        //}
    }
}
