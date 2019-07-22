using StudentCourseApp.Data.Entity;
using StudentCourseApp.Data.Infrastructure;

namespace StudentCourseApp.Data.Repository.Impl
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}