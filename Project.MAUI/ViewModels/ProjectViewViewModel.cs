using Project_library.Models;
using Project_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAUI.ViewModels
{
    public class ProjectViewViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }
        public Projectt SelectedProject { get; set; }
        public string Query {get; set;}



        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {

                //watch lecture to find out dto
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Projects.Select(x => new ProjectViewModel(x)).ToList());
                }
                else
                {
                    return new ObservableCollection<ProjectViewModel>
                         (ProjectService.Current.Search(Query ?? string.Empty)
                         .Where(x => x.ClientId == Model.Id)
                         .Select(x => new ProjectViewModel(x)).ToList());
                    //return new ObservableCollection<Projectt>(ProjectService.Current.Projects.Where(x => x.ClientId == Model.Id));
                }
            }
        }

        public ProjectViewViewModel(int clientId)
        {
            if (clientId > 0)
            {
                Model = ClientService.Current.Get(clientId);
            }
            else
            {
                Model = new Client();
            }
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public void Delete()
        {
            if(SelectedProject != null)
            {
                ProjectService.Current.Delete(SelectedProject.ClientId);
                SelectedProject = null;
                NotifyPropertyChanged(nameof(Projects));
                NotifyPropertyChanged(nameof(SelectedProject));
            }
        }


        //notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
