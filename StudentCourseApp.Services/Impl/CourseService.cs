using System.Collections.Generic;
using StudentCourseApp.Data.Entity;
using StudentCourseApp.Data.Repository;
using StudentCourseApp.Services.Mappers;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services.Impl
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public CourseModel Get(int id)
        {
            return _courseRepository.Get(id).ToModel();
        }

        public IEnumerable<CourseModel> GetAll()
        {
            return _courseRepository.GetAll().ToModels();
        }

        public void RemoveCourse(int id)
        {
            var course = _courseRepository.Get(id);

            if (course == null) return;
            
            _courseRepository.Remove(course);
        }

        public void UpdateCourse(CourseModel courseModel)
        {
            var course = _courseRepository.Get(courseModel.Id);
            course.CourseName = courseModel.CourseName;
            course.CourseCode = courseModel.CourseCode;
            course.StartDate = courseModel.StartDate;
            course.EndDate = courseModel.EndDate;
            course.TeacherName = courseModel.TeacherName;

            _courseRepository.Update(course);
            _courseRepository.Save();
        }

        public int AddNew(CourseModel courseModel)
        {
            var course = new Course
            {
                CourseName = courseModel.CourseName,
                CourseCode = courseModel.CourseCode,
                StartDate = courseModel.StartDate,
                EndDate = courseModel.EndDate,
                TeacherName = courseModel.TeacherName
            };

            _courseRepository.Add(course);
            _courseRepository.Save();

            return course.CourseId;
        }
    }
}
