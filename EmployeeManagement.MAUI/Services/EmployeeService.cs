using UserManagement.MAUI.Models;

namespace UserManagement.MAUI.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<Employee> AddEmployee(Employee employee)
        {
            string baseUrl = "https://employeemanagementapidonhat.azurewebsites.net/api/Employees";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);

                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var employeeResponse = JsonConvert.DeserializeObject<Employee>(responseContent);
                    return employeeResponse;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            string baseUrl = $"https://employeemanagementapidonhat.azurewebsites.net/api/Employees/{id}";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await httpClient.DeleteAsync(baseUrl);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<List<Employee>> GetEmployeesExcept(int id)
        {
            string baseUrl = "https://employeemanagementapidonhat.azurewebsites.net/api/Employees/except/";
            string idText = id.ToString();

            // Encode username and password for safe inclusion in the URL
            string encodedId = HttpUtility.UrlEncode(idText);

            // Construct the complete URL
            string url = $"{baseUrl}{encodedId}";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var httpResponseMessage = await httpClient.GetAsync(new Uri(url));

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                        var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonResponse);
                        return employees;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }

        public async Task<Employee> LoginEmployee(string username, string password)
        {
            string baseUrl = "https://employeemanagementapidonhat.azurewebsites.net/api/Employees/";

            // Construct the complete URL
            string url = $"{baseUrl}{username}/{password}";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var httpResponseMessage = await httpClient.GetAsync(new Uri(url));

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(jsonResponse);
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            string baseUrl = $"https://employeemanagementapidonhat.azurewebsites.net/api/Employees/{id}";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);

                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
