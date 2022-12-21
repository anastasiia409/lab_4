using lab_4.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_4.Data
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; } = null!;
        public DbSet<Project> Project { get; set; } = null!;
        public DbSet<Position> Position { get; set; } = null!;
        public DbSet<EmployeeProject> EmployeeProject { get; set; } = null!;
    }
}
