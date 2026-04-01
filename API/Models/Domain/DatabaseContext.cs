using Microsoft.EntityFrameworkCore;

namespace API.Models.Domain
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }

    }
}
