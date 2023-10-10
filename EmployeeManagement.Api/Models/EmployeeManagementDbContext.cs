using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
