using System.Collections.Generic;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services
{
    public interface IStudentService
    {
        StudentModel Get(int id);

        IEnumerable<StudentModel> GetAll();

        void RemoveStudent(int id);

        void UpdateStudent(StudentModel studentModel);

        int AddNew(StudentModel studentModel);
    }
}