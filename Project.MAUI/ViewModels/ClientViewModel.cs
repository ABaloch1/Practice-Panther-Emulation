using Project_library.Models;
using Project_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAUI.ViewModels
{
    public class ClientViewModel
    {
        public ObservableCollection<Client> Clients {
            get
            {
                return new ObservableCollection<Client>(ClientService.Current.getclientList);
            }
        }
    }
}
