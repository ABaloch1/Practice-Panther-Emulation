using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
	public int ClientId {get; set;}
	public ProjectView()
	{
		InitializeComponent();
        //BindingContext = new ProjectViewViewModel();
	}

    private void ProjecctsArriving(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new ProjectViewViewModel(ClientId);
        //(BindingContext as ProjectViewViewModel).RefreshProjectList();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//getclientList");
    }

    private void EditCommand(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }

    private void DeleteCommand(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ProjectDetail?clientId={ClientId}");
    }
}