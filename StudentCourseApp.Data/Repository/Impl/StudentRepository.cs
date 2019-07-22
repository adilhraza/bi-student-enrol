using StudentCourseApp.Data.Entity;
using StudentCourseApp.Data.Infrastructure;

namespace StudentCourseApp.Data.Repository.Impl
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public string Test()
        {
            return "Testing DI";
        }
    }
}
