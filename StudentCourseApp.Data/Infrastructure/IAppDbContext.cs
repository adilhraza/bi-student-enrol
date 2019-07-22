using System.Data.Entity;
using StudentCourseApp.Data.Entity;

namespace StudentCourseApp.Data.Infrastructure
{
    public interface IAppDbContext
    {
        DbSet<Student> Categories { get; set; }
        DbSet<Course> Products { get; set; }
    }
}