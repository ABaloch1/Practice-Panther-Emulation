using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

public partial class TimeDetailView : ContentPage
{
	public TimeDetailView()
	{
		InitializeComponent();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//gettimeList");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddorUpdate();
        Shell.Current.GoToAsync("//gettimeList");
    }
}