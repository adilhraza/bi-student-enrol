using System.Collections.Generic;
using System.Linq;
using StudentCourseApp.Data.Entity;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services.Mappers
{
    public static class StudentMapper
    {
        public static StudentModel ToModel(this Student entity)
        {
            return new StudentModel
            {
                Id = entity.StudentId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                DateOfBirth = entity.DateOfBirth,
                AddressLine1 = entity.AddressLine1,
                AddressLine2 = entity.AddressLine2,
                AddressLine3 = entity.AddressLine3,
                Courses = entity.Courses?.ToModels()
            };
        }

        public static List<StudentModel> ToModels(this IEnumerable<Student> entities)
        {
            return entities.Select(ToModel).ToList();
        }
    }
}
