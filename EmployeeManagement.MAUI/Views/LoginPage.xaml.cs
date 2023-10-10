using UserManagement.MAUI.ViewModels;

namespace UserManagement.MAUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(this);
	}
}