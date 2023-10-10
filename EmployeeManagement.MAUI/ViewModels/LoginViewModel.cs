using UserManagement.MAUI.Models;
using UserManagement.MAUI.Services;
using UserManagement.MAUI.Views;

namespace UserManagement.MAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly LoginPage _loginPage;
        private readonly IEmployeeService _employeeService = new EmployeeService();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginEmployeeCommand))]
        private string username;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginEmployeeCommand))]
        private string password;

        [ObservableProperty]
        private bool isLoading = false;

        public LoginViewModel(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [RelayCommand(CanExecute = nameof(CanLoginEmployee))]
        public async Task LoginEmployee()
        {
            IsLoading = true;
            Employee employee = await _employeeService.LoginEmployee(Username, Helpers.EncryptData(Password));
            IsLoading = false;
            if (employee != null)
            {
                Username = "";
                Password = "";

                var navParam = new Dictionary<string, object>();
                navParam.Add("CurrentEmployee", employee);
                await _loginPage.Navigation.PushAsync(new HomePage(employee));
            }
            else
            {
                await _loginPage.DisplayAlert("Error", "Incorrect Username or Password. Please try again.", "OK");
            }
        }

        public bool CanLoginEmployee()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            if (Password.Length < 8)
            {
                return false;
            }

            return true;
        }
    }
}
