using Project.MAUI.ViewModels;
using Project_library.Services;

namespace Project.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
	public ClientDetailView()
	{
		InitializeComponent();
	}
	public int ClientId { get; set; }


    private void AddingClicked(object sender, EventArgs e)
    {
		(BindingContext as ClientViewModel).AddorUpdate();
		Shell.Current.GoToAsync("//getclientList");
    }

    private void clientsonArival(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//getclientList");

    }
}
