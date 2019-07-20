using System.Data.Entity;
using StudentCourseApp.Data.Entity;

namespace StudentCourseApp.Data.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("StudentEnrollDbConnection") {}

        public DbSet<Student> Categories { get; set; }
        public DbSet<Course> Products { get; set; }
    }
}
