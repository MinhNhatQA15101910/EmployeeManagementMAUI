using UserManagement.MAUI.ViewModels;

namespace UserManagement.MAUI.Views;

public partial class EmployeeListPage : ContentPage
{
	public EmployeeListPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        {
            ((EmployeeListViewModel)BindingContext).GetEmployeesCommand.Execute(null);
        }

        if (Navigation != null)
        {
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}