using System.Collections.Generic;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services
{
    public interface ICourseService
    {
        CourseModel Get(int id);

        IEnumerable<CourseModel> GetAll();

        void RemoveCourse(int id);

        void UpdateCourse(CourseModel courseModel);

        void AddNew(CourseModel courseModel);
    }
}