namespace UserManagement.MAUI.Models
{
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
