using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services
{
    public interface IStudentService
    {
        StudentModel Get(int id);

        string Test();
    }
}