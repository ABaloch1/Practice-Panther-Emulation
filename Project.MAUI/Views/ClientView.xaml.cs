using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
		BindingContext = new ClientViewViewModel();
	}

    private void PreviousClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }


    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetail");
    }

    private void EditCommand(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();

    }

    private void ProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }
}