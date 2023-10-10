using UserManagement.MAUI.Models;
using UserManagement.MAUI.ViewModels;

namespace UserManagement.MAUI.Views;

public partial class AddUpdateEmployeePage : ContentPage
{
	public AddUpdateEmployeePage()
	{
		InitializeComponent();
		BindingContext = new AddUpdateEmployeeViewModel(this);
	}

    public AddUpdateEmployeePage(Employee employee)
    {
        InitializeComponent();
        BindingContext = new AddUpdateEmployeeViewModel(this, employee);
    }
}