using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
		BindingContext = new ClientViewModel();
	}

    private void PreviousClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }


    private void Delete(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Delete();
    }
}