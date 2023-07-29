using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
	public int ClientId;
	public ProjectView()
	{
		InitializeComponent();
	}

    private void ProjecctsArriving(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new ProjectViewViewModel(ClientId);
    }
}