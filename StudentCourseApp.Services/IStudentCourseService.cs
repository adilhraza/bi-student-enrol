namespace StudentCourseApp.Services
{
    public interface IStudentCourseService
    {
        void AddCourseToStudent(int courseId, int studentId);

        void RemoveCourseFromStudent(int courseId, int studentId);
    }
}