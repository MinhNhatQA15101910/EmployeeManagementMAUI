using UserManagement.MAUI.Models;
using UserManagement.MAUI.Views;

namespace UserManagement.MAUI.ViewModels
{
    public partial class CurrentEmployeeInfoViewModel : ObservableObject
    {
        private readonly CurrentEmployeeInfoPage _currentEmployeeInfoPage;

        [ObservableProperty]
        private Employee employee;

        public CurrentEmployeeInfoViewModel(CurrentEmployeeInfoPage currentEmployeeInfoPage, Employee employee)
        {
            _currentEmployeeInfoPage = currentEmployeeInfoPage;
            this.employee = employee;
        }

        [RelayCommand]
        public async Task Logout()
        {
            bool response = await _currentEmployeeInfoPage.DisplayAlert("Warning!", "Do you want to log out?", "Yes", "No");
            if (response)
            {
                await _currentEmployeeInfoPage.Navigation.PopAsync();
            }
        }
    }
}
