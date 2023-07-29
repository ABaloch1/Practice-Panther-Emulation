using Project_library.Models;
using Project_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAUI.ViewModels
{
    public class ProjectViewViewModel
    {
        public Client Model { get; set; }
        public ObservableCollection<Projectt> Projects
        {
            get
            {

                //watch lecture to find out wtf is a dto
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<Projectt>(ProjectService.Current.Projects);
                }
                else
                {
                    return new ObservableCollection<Projectt>(ProjectService.Current.Projects.Where(x => x.ClientId == Model.Id));
                }
            }
        }

        public ProjectViewViewModel(int clientId)
        {
            if(clientId > 0)
            {
                Model = ClientService.Current.Get(clientId);
            }
            else
            {
                Model = new Client();
            }
        }
    }
}
