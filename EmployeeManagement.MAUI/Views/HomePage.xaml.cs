using UserManagement.MAUI.Models;
using UserManagement.MAUI.ViewModels;

namespace UserManagement.MAUI.Views;

public partial class HomePage : TabbedPage
{
	public HomePage(Employee employee)
	{
		InitializeComponent();

		foreach (var page in Children)
		{
			if (page is CurrentEmployeeInfoPage)
			{
				CurrentEmployeeInfoPage currentEmployeeInfoPage = (CurrentEmployeeInfoPage)page;
                currentEmployeeInfoPage.BindingContext = new CurrentEmployeeInfoViewModel(currentEmployeeInfoPage, employee);
			}
			else if (page is EmployeeListPage)
			{
				EmployeeListPage employeeListPage = (EmployeeListPage)page;
                employeeListPage.BindingContext = new EmployeeListViewModel(employeeListPage, employee);
			}
		}
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		if (Navigation != null)
		{
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}