using Project.MAUI.ViewModels;

namespace Project.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeDetailView : ContentPage
{
	public int EmployeeId { get; set; }
	public EmployeeDetailView()
	{
		InitializeComponent();
	}

    private void EmpOnArrival(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new EmployeeViewModel(EmployeeId); 
    }

    private void Previous(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//getemployeeList");
    }

    private void Confirm(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).ExecuteAddorUpdate();
        Shell.Current.GoToAsync("//getemployeeList");
    }
}