using StudentCourseApp.Data.Entity;
using StudentCourseApp.Data.Infrastructure;

namespace StudentCourseApp.Data.Repository.Impl
{
    public class StudentRepository : BaseRepository<Student>
    {
       public StudentRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
