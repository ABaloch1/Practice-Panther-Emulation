using Project.MAUI.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices; 

namespace Project.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }



        private void ClientClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//getclientList");
        }
    }

    
}