using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
		BindingContext = new ClientViewModel();
	}
}