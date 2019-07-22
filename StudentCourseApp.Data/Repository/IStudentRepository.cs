using StudentCourseApp.Data.Entity;

namespace StudentCourseApp.Data.Repository
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        string Test();
    }
}