using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;


[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
    }

    private void Arrive(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId);
    }

 
}