using StudentCourseApp.Data.Repository;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Test()
        {
            return _studentRepository.Test();
        }
    }
}
