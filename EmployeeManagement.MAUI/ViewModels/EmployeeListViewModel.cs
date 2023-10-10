using UserManagement.MAUI.Models;
using UserManagement.MAUI.Services;
using UserManagement.MAUI.Views;

namespace UserManagement.MAUI.ViewModels
{
    public partial class EmployeeListViewModel : ObservableObject
    {
        private readonly EmployeeListPage _employeeListPage;
        private readonly Employee _employee;
        private readonly IEmployeeService _employeeService = new EmployeeService();

        [ObservableProperty]
        private bool isLoading = true;

        [ObservableProperty]
        private bool isEmployeeListVisible = false;

        public ObservableCollection<Employee> EmployeeList { get; set; } = new ObservableCollection<Employee>();

        public EmployeeListViewModel(EmployeeListPage employeeListPage, Employee employee)
        {
            _employeeListPage = employeeListPage;
            _employee = employee;
        }

        [RelayCommand]
        public async Task GetEmployees()
        {
            IsLoading = true;
            IsEmployeeListVisible = false;
            var employees = await _employeeService.GetEmployeesExcept(_employee.Id);
            if (employees?.Count > 0)
            {
                EmployeeList.Clear();
                foreach (var employee in employees)
                {
                    EmployeeList.Add(employee);
                }
            }
            IsLoading = false;
            IsEmployeeListVisible = true;
        }

        [RelayCommand]
        public async Task NavigateToAddUpdateEmployeePage()
        {
            await _employeeListPage.Navigation.PushAsync(new AddUpdateEmployeePage());
        }

        [RelayCommand]
        public async Task DisplayAction(Employee employee)
        {
            var response = await _employeeListPage.DisplayActionSheet("Select Option", null, null, "Edit", "Delete");

            if (response == "Edit")
            {
                await _employeeListPage.Navigation.PushAsync(new AddUpdateEmployeePage(employee));
            }
            else if (response == "Delete")
            {
                bool delete = await _employeeService.DeleteEmployee(employee.Id);

                if (delete)
                {
                    await GetEmployees();
                }
            }
        }
    }
}
