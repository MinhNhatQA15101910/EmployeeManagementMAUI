using UserManagement.MAUI.Models;
using UserManagement.MAUI.Services;
using UserManagement.MAUI.Views;

namespace UserManagement.MAUI.ViewModels
{
    public partial class AddUpdateEmployeeViewModel : ObservableObject
    {
        private readonly IEmployeeService _employeeService = new EmployeeService();
        private readonly AddUpdateEmployeePage _addUpdateEmployeePage;
        private readonly string _job;
        private readonly Employee _employee;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUpdateEmployeeCommand))]
        private string username;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUpdateEmployeeCommand))]
        private string firstName;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUpdateEmployeeCommand))]
        private string lastName;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUpdateEmployeeCommand))] 
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUpdateEmployeeCommand))] 
        private DateTime dateOfBirth;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUpdateEmployeeCommand))] 
        private bool isLoading = false;

        public AddUpdateEmployeeViewModel(AddUpdateEmployeePage addUpdateEmployeePage)
        {
            _addUpdateEmployeePage = addUpdateEmployeePage;
            _job = "Add";
        }

        public AddUpdateEmployeeViewModel(AddUpdateEmployeePage addUpdateEmployeePage, Employee employee)
        {
            _addUpdateEmployeePage = addUpdateEmployeePage;
            Username = employee.Username;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Email = employee.Email;
            DateOfBirth = employee.DateOfBirth;
            _employee = employee;
            _job = "Update";
        }

        [RelayCommand(CanExecute = nameof(CanAddUpdateEmployee))]
        public async Task AddUpdateEmployee()
        {
            IsLoading = true;
            if (_job == "Add")
            {
                string password = Helpers.GeneratePassword();

                string encodedPassword = Helpers.EncryptData(password);

                Employee encodedEmployee = new Employee
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    DateOfBirth = DateOfBirth,
                    Username = Username,
                    Password = encodedPassword
                };

                Employee result = await _employeeService.AddEmployee(encodedEmployee);
                IsLoading = false;

                if (result != null)
                {
                    await _addUpdateEmployeePage.DisplayAlert("Success", "Add employee successfully!\nThe generated password is: " + password, "OK");
                }
            }
            else if (_job == "Update")
            {
                bool result = await _employeeService.UpdateEmployee(_employee.Id, new Employee
                {
                    Id = _employee.Id,
                    Username = Username,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    DateOfBirth = DateOfBirth,
                    Password = _employee.Password
                });
                IsLoading = false;

                if (result)
                {
                    await _addUpdateEmployeePage.DisplayAlert("Success", "Update employee successfully!", "OK");
                }
                else
                {
                    await _addUpdateEmployeePage.DisplayAlert("Error", "Unable to update employeeS!", "OK");
                }
            }
        }

        public bool CanAddUpdateEmployee()
        {
            if (string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(FirstName) ||
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email))
            {
                return false;
            }

            return true;
        }
    }
}
