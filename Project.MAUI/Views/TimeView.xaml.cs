using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
	{
		InitializeComponent();
	}

    private void Previous(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArrive(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewViewModel();
    }

    private void AddTime(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeDetail");
    }
}