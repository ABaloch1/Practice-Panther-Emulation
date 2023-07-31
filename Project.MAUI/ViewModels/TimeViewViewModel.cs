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

namespace Project.MAUI.ViewModels
{
    public class TimeViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TimeViewModel> gettimeList
        {
            get
            {
                return new ObservableCollection<TimeViewModel>
                    (TimeService.Current.gettimeList.Select(t => new TimeViewModel(t)));
            }
        }

        public void RefreshTimes()
        {
            NotifyPropertyChanged("gettimeList");
        }

        //notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
