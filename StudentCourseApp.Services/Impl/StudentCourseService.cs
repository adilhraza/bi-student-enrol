using System.IO;
using System.Linq;
using StudentCourseApp.Data.Repository;

namespace StudentCourseApp.Services.Impl
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentCourseService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public void AddCourseToStudent(int courseId, int studentId)
        {
            if (courseId == 0 || studentId == 0)
            {
                // for this operation to complete we need both studentId and courseId 
                // if we don't get these we get invalid data
                throw new InvalidDataException();
            }

            var student = _studentRepository.Get(studentId);

            if (student != null && student.Courses.Count < 5)
            {
                var course = _courseRepository.Get(courseId);

                if (!student.Courses.Contains(course))
                {
                    student.Courses.Add(course);
                    _studentRepository.Save();
                }
            }
        }

        public void RemoveCourseFromStudent(int courseId, int studentId)
        {
            if (courseId == 0 || studentId == 0)
            {
                throw new InvalidDataException();
            }

            var student = _studentRepository.Get(studentId);

            if (student != null && student.Courses.Any())
            {
                var course = _courseRepository.Get(courseId);
                student.Courses.Remove(course);
                _studentRepository.Save();
            }
        }
    }
}
