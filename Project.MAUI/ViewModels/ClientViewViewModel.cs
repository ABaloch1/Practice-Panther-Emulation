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
    class ClientViewViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }
        public ICommand SearchCommand { get; set; }
        public string Query { get; set; }

        public ClientViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(getclientList));
        }


        //notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(getclientList));
        }

        public ObservableCollection<ClientViewModel> getclientList
        {
            get
            {
                return
                    new ObservableCollection<ClientViewModel>
                    (ClientService.Current.Search(Query ?? string.Empty).Select(x => new ClientViewModel(x)).ToList());
            }
        }

        public void Delete()
        {
            if(SelectedClient != null)
            {
                ClientService.Current.Delete(SelectedClient.Id);
                SelectedClient = null;
                NotifyPropertyChanged(nameof(getclientList));
                NotifyPropertyChanged(nameof(SelectedClient));
            }
        }       
    }
}
