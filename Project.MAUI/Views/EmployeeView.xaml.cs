using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewViewModel();
	}

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void EditCommand(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void PreviousClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void DeleteCommand(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeDetail");
    }
}