namespace UserManagement.MAUI.Views;

public partial class CurrentEmployeeInfoPage : ContentPage
{
	public CurrentEmployeeInfoPage()
	{
		InitializeComponent();
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