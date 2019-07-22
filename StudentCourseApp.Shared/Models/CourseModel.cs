using System;
using System.Collections.Generic;

namespace StudentCourseApp.Shared.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public string TeacherName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<StudentModel> Students { get; set; }
    }
}