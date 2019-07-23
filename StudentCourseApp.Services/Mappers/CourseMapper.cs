using System.Collections.Generic;
using System.Linq;
using StudentCourseApp.Data.Entity;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services.Mappers
{
    public static class CourseMapper
    {
        public static CourseModel ToModel(this Course entity)
        {
            return new CourseModel
            {
                Students = entity.Students?.ToModels(),
                CourseCode = entity.CourseCode,
                Id = entity.CourseId,
                CourseName = entity.CourseName,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                TeacherName = entity.TeacherName
            };
        }

        public static List<CourseModel> ToModels(this IEnumerable<Course> entities)
        {
            return entities.Select(ToModel).ToList();
        }
    }
}