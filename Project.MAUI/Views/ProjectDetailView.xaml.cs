using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;


[QueryProperty(nameof(ClientId), "clientId")]
[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }
    public int ProjectId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
    }

    private void Arrive(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId, ProjectId);
    }

    private void AddingClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).ExecuteAddorUpdate();
        var clId = (BindingContext as ProjectViewModel).Model.ClientId;
        Shell.Current.GoToAsync($"//Projects?clientId={clId}");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        var clId = (BindingContext as ProjectViewModel).Model.ClientId;
        Shell.Current.GoToAsync($"//Projects?clientId={clId}");
    }
}